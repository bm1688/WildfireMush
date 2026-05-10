using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFuel : MonoBehaviour
{
// when player presses R key, it called ScoreManager to minus score by 10, then called FuelTankSO to add fuel by according to loadout type


    [SerializeField] private LoadoutManager loadoutManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private FuelTankSO fuelTankSO;
    [SerializeField] private int price = 50;

    private void Awake()
    {
        if (loadoutManager == null)
        {
            loadoutManager = FindObjectOfType<LoadoutManager>();
        }
        if (scoreManager == null)
        {
            scoreManager = FindObjectOfType<ScoreManager>();
        }
        if (fuelTankSO == null)
        {
            fuelTankSO = FindObjectOfType<FuelTankSO>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
           if(scoreManager.CurrentScore >= price)
            {
                ScoreManager.instance.AddScore(-price);
                // call player fuel tank to add fuel according to loadout type
                PlayerFuel playerFuel = FindObjectOfType<PlayerFuel>();
                if (playerFuel != null)
                {
                    playerFuel.Refill();
                }
            }


        }
    }

}
