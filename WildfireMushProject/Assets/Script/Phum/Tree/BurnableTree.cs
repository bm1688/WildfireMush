using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BurnableTree : MonoBehaviour, IDamageable
{
    [Header("HP")]
    [SerializeField] private float maxHP = 100f;
    [SerializeField] private float damagedThreshold = 70f;

    [Header("Burn Damage Over Time")]
    [SerializeField] private float burnDamagePerSecond = 10f;

    [Header("Tree Visual")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite treeSprite;
    [SerializeField] private Color damagedColor = new Color(1f, 0.5f, 0f, 1f);

    [Header("Ash Visual")]
    [SerializeField] private GameObject ashVisual;

    [Header("Spawn Point")]
    [SerializeField] private Transform groundPoint;

    [Header("Mushroom Spawn")]
    [SerializeField] private GameObject mushroomPrefab;
    [SerializeField] private float spawnDelay = 5f;

    [Header("Smoke Zone")]
    [SerializeField] private SmokeZoneScaler smokeZoneScaler;

    [Header("Burning Kill")]
    [SerializeField] private bool killPlayerOnTouchWhileBurning = true;
    [SerializeField] private GameOver gameOverScript;

    [Header("Respawn Time")]
    [SerializeField] private float respawnTime = 10f;

    private float hp;
    private bool isDead;
    private bool isBurning;
    private Color originalColor;
    private Collider2D treeCollider;

    private Coroutine spawnRoutine;
    private Coroutine respawnRoutine;

    private void Awake()
    {
        hp = maxHP;

        treeCollider = GetComponent<Collider2D>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        originalColor = spriteRenderer.color;

        if (ashVisual != null)
            ashVisual.SetActive(false);

        if (smokeZoneScaler != null)
            smokeZoneScaler.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isDead) return;
        if (!isBurning) return;

        hp -= burnDamagePerSecond * Time.deltaTime;

        if (hp < 0f)
            hp = 0f;

        if (hp <= 0f)
            BecomeAsh();
    }

    public void ApplyDamage(float damage)
    {
        if (isDead) return;

        hp -= damage;

        if (hp < 0f)
            hp = 0f;

        if (hp <= damagedThreshold && !isBurning)
        {
            StartBurning();
        }
        else if (!isBurning)
        {
            spriteRenderer.color = originalColor;
        }

        if (hp <= 0f)
            BecomeAsh();
    }

    private void StartBurning()
    {
        isBurning = true;
        AudioManager.instance.PlaySFX("burning");
        spriteRenderer.color = damagedColor;

        if (smokeZoneScaler != null)
            smokeZoneScaler.StartExpand();
    }

    private void BecomeAsh()
    {
        if (isDead) return;

        isDead = true;
        isBurning = false;

        if (treeCollider != null)
            treeCollider.enabled = false;

        if (smokeZoneScaler != null)
            smokeZoneScaler.StartShrink();

        // Hide tree visual
        spriteRenderer.enabled = false;

        // Show ash at bottom-middle point
        if (ashVisual != null)
        {
            if (groundPoint != null)
                ashVisual.transform.position = groundPoint.position;

            ashVisual.SetActive(true);
        }

        if (spawnRoutine != null)
            StopCoroutine(spawnRoutine);

        spawnRoutine = StartCoroutine(SpawnMushroomAfterDelay());
    }

    private IEnumerator SpawnMushroomAfterDelay()
    {
        yield return new WaitForSeconds(spawnDelay);

        Vector3 spawnPosition = transform.position;

        if (groundPoint != null)
            spawnPosition = groundPoint.position;

        // Hide ash when mushroom appears
        if (ashVisual != null)
            ashVisual.SetActive(false);

        if (mushroomPrefab != null)
        {
            GameObject mushroomObject = Instantiate(mushroomPrefab, spawnPosition, Quaternion.identity);

            Score scoreScript = mushroomObject.GetComponent<Score>();

            if (scoreScript != null)
            {
                scoreScript.OnCollected += StartRespawnAfterMushroomCollected;
            }
            else
            {
                Debug.LogWarning("Mushroom prefab does not have Score script.");
            }
        }
    }

    private void StartRespawnAfterMushroomCollected()
    {
        if (respawnRoutine != null)
            StopCoroutine(respawnRoutine);

        respawnRoutine = StartCoroutine(RespawnAfterDelay());
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnTime);

        RespawnTree();
    }

    private void RespawnTree()
    {
        hp = maxHP;
        isDead = false;
        isBurning = false;

        spriteRenderer.sprite = treeSprite;
        spriteRenderer.color = originalColor;
        spriteRenderer.enabled = true;

        if (treeCollider != null)
            treeCollider.enabled = true;

        if (ashVisual != null)
            ashVisual.SetActive(false);

        if (smokeZoneScaler != null)
            smokeZoneScaler.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandlePlayerTouch(other);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandlePlayerTouch(collision.collider);
    }

    private void HandlePlayerTouch(Collider2D other)
    {
        if (!killPlayerOnTouchWhileBurning) return;
        if (!isBurning) return;

        if (!other.CompareTag("Player")) return;

        if (gameOverScript != null)
            gameOverScript.GameOverScreen();
    }
}
