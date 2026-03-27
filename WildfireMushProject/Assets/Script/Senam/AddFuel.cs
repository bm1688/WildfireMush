using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFuel : MonoBehaviour
{
// when player presses R key, it called ScoreManager to minus score by 10, then called FuelTankSO to add fuel by according to loadout type


    [SerializeField] private LoadoutManager loadoutManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private FuelTankSO fuelTankSO;
    [SerializeField] private int price = 10;
    [SerializeField] private int fuelAmountToAdd = 10;

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
            ScoreManager.instance.AddScore(-price);
            FuelTankSO.Instance.AddFuel(fuelAmountToAdd); //place holder, need to get fuel amount from loadout manager according to current loadout
            // FuelTankSO.Instance.AddFuel(LoadoutManager.Instance.GetCurrentLoadout().fuelAmount);
        }
    }

}
