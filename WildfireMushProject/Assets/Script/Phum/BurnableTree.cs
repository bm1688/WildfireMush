using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BurnableTree : MonoBehaviour, IDamageable
{
    [Header("HP")]
    [SerializeField] private float maxHP = 100f;
    [SerializeField] private float damagedThreshold = 70f;

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

    private float hp;
    private bool isDead;
    private bool isBurning;
    private Color originalColor;
    private Coroutine spawnRoutine;
    private Collider2D treeCollider;

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

    public void ApplyDamage(float damage)
    {
        if (isDead) return;

        hp -= damage;
        if (hp < 0f) hp = 0f;

        if (hp <= damagedThreshold && !isBurning)
        {
            isBurning = true;
            spriteRenderer.color = damagedColor;

            if (smokeZoneScaler != null)
                smokeZoneScaler.StartExpand();
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

    private void BecomeAsh()
    {
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

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
