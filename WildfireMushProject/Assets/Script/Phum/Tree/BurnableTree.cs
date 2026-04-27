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

    [Header("Visual")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite ashSprite;
    [SerializeField] private Color damagedColor = new Color(1f, 0.5f, 0f, 1f);

    [Header("Mushroom Spawn")]
    [SerializeField] private GameObject mushroomPrefab;
    [SerializeField] private float spawnDelay = 5f;

    [Header("Smoke Zone")]
    [SerializeField] private SmokeZoneScaler smokeZoneScaler;

    [Header("Burning Kill")]
    [SerializeField] private bool killPlayerOnTouchWhileBurning = true;

    [Header("Respawn time")]
    [SerializeField] private float respawnTime = 30f;

    private float hp;
    private bool isDead;
    private bool isBurning;
    private Color originalColor;
    private Coroutine spawnRoutine;
    private Collider2D treeCollider;
    [SerializeField] private GameOver GameOverScript;

    private void Awake()
    {
        hp = maxHP;

        treeCollider = GetComponent<Collider2D>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        originalColor = spriteRenderer.color;

        if (smokeZoneScaler != null)
            smokeZoneScaler.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isDead) return;
        if (!isBurning) return;

        hp -= burnDamagePerSecond * Time.deltaTime;

        if (hp < 0f) hp = 0f;

        if (hp <= 0f)
        {
            BecomeAsh();
        }
    }

    public void ApplyDamage(float damage)
    {
        if (isDead) return;

        hp -= damage;
        if (hp < 0f) hp = 0f;

        if (hp <= damagedThreshold && !isBurning)
        {
            StartBurning();
        }
        else if (!isBurning)
        {
            spriteRenderer.color = originalColor;
        }

        if (hp <= 0f)
        {
            BecomeAsh();
        }
    }

    private void StartBurning()
    {
        isBurning = true;
        spriteRenderer.color = damagedColor;

        if (smokeZoneScaler != null)
            smokeZoneScaler.StartExpand();
    }

    private void BecomeAsh()
    {
        if (isDead) return;

        isDead = true;
        isBurning = false;

        spriteRenderer.sprite = ashSprite;
        spriteRenderer.color = Color.white;

        if (treeCollider != null)
            treeCollider.enabled = false;

        if (smokeZoneScaler != null)
            smokeZoneScaler.StartShrink();

        if (spawnRoutine != null)
            StopCoroutine(spawnRoutine);

        spawnRoutine = StartCoroutine(SpawnMushroomAfterDelay());
        
        StartCoroutine(RespawnAfterDelay());
    }

    private IEnumerator SpawnMushroomAfterDelay()
    {
        yield return new WaitForSeconds(spawnDelay);

        if (mushroomPrefab != null)
            Instantiate(mushroomPrefab, transform.position, Quaternion.identity);

        gameObject.SetActive(false);
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

        Debug.Log("Player died from touching a burning tree! Loading GameOver screen");
        GameOverScript.GameOverScreen();
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
        spriteRenderer.sprite = null;
        spriteRenderer.color = originalColor;
        if (treeCollider != null)
            treeCollider.enabled = true;
        if (smokeZoneScaler != null)
            smokeZoneScaler.gameObject.SetActive(false);
    }
}
