using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadoutUIController : MonoBehaviour
{
    [SerializeField] private LoadoutManager loadoutManager;

    [Header("O2 Tanks (3)")]
    [SerializeField] private O2TankSO o2_01;
    [SerializeField] private O2TankSO o2_02;
    [SerializeField] private O2TankSO o2_03;

    [Header("Fuel Tanks (3)")]
    [SerializeField] private FuelTankSO fuel_01;
    [SerializeField] private FuelTankSO fuel_02;
    [SerializeField] private FuelTankSO fuel_03;

    [Header("Shoes (3)")]
    [SerializeField] private ShoeSO shoe_01;
    [SerializeField] private ShoeSO shoe_02;
    [SerializeField] private ShoeSO shoe_03;

    private void Awake()
    {
        if (loadoutManager == null)
            loadoutManager = FindObjectOfType<LoadoutManager>();
    }

    public void SelectO2_01() { loadoutManager.SelectO2Tank(o2_01); }
    public void SelectO2_02() { loadoutManager.SelectO2Tank(o2_02); }
    public void SelectO2_03() { loadoutManager.SelectO2Tank(o2_03); }

    public void SelectFuel_01() { loadoutManager.SelectFuelTank(fuel_01); }
    public void SelectFuel_02() { loadoutManager.SelectFuelTank(fuel_02); }
    public void SelectFuel_03() { loadoutManager.SelectFuelTank(fuel_03); }

    public void SelectShoe_01() { loadoutManager.SelectShoe(shoe_01); }
    public void SelectShoe_02() { loadoutManager.SelectShoe(shoe_02); }
    public void SelectShoe_03() { loadoutManager.SelectShoe(shoe_03); }
}
