using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Score : MonoBehaviour
{
    public Action OnCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            AudioManager.instance.PlaySFX("mushroom");
            ScoreManager.instance.AddScore(20);

            OnCollected?.Invoke();

            Destroy(gameObject);
        }
    }
}
