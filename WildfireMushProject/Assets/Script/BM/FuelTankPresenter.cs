using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelTankPresenter : MonoBehaviour
{
    [SerializeField] private Slider _fuelTankSlider;

    [SerializeField] private PlayerFuel _playerFuel;
    void Start()
    {
        SetMaxFuel(_playerFuel.maxFuel);
    }

    // Update is called once per frame
    void Update()
    {
        
        SetCurrentFuel(_playerFuel.currentFuel);
        
    }

    public void SetMaxFuel(float maxfuel)
    {
        _fuelTankSlider.maxValue = maxfuel;
        SetCurrentFuel(maxfuel);
    }

    public void SetCurrentFuel (float currentFuel)
    {
        _fuelTankSlider.value = currentFuel;
    }
}
