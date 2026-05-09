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
        _fuelTankSlider.maxValue = _playerFuel.maxFuel;
        _fuelTankSlider.value = _playerFuel.currentFuel;
    }

    // Update is called once per frame
    void Update()
    {
        _fuelTankSlider.value = _playerFuel.currentFuel;
    }
}
