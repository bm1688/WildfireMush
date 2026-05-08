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
            ScoreManager.instance.AddScore(1);

            OnCollected?.Invoke();

            Destroy(gameObject);
        }
    }
}
