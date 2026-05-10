using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFuel : MonoBehaviour
{


    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private int price = 50;

    private void Awake()
    {

        if (scoreManager == null)
        {
            scoreManager = FindObjectOfType<ScoreManager>();
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
           if(scoreManager.CurrentScore >= price)
            {
                ScoreManager.instance.AddScore(-price);
                PlayerFuel playerFuel = FindObjectOfType<PlayerFuel>();
                if (playerFuel != null)
                {
                    playerFuel.Refill();
                }
            }


        }
    }

}
