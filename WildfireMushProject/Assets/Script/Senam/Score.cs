using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    private void OnTriggerEnter2D  (Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            ScoreManager.instance.AddScore(1);
            Destroy(gameObject);
        }

    }
}
