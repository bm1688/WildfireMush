using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // when touch this script item will tell the score manager to add score by 1
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScoreManager.instance.AddScore(1);
            Destroy(gameObject);
        }

    }
}
