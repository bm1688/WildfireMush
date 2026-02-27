using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private float hp;
    private bool isDead;
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
    }

    public void ApplyDamage(float damage)
    {
        if (isDead) return;

        hp -= damage;
        if (hp < 0f) hp = 0f;

        if (hp <= damagedThreshold)
            spriteRenderer.color = damagedColor;
        else
            spriteRenderer.color = originalColor;

        if (hp <= 0f)
        {
            BecomeAsh();
        }
    }

    private void BecomeAsh()
    {
        isDead = true;

        spriteRenderer.sprite = ashSprite;

        spriteRenderer.color = Color.white;

        if (treeCollider != null)
            treeCollider.enabled = false;

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
}
