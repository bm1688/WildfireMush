using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadoutManager : MonoBehaviour
{
    [Header("Default Parts")]
    [SerializeField] private O2TankSO defaultO2Tank;
    [SerializeField] private FuelTankSO defaultFuelTank;
    [SerializeField] private ShoeSO defaultShoe;

    [Header("Current Selection (runtime)")]
    [SerializeField] private O2TankSO currentO2Tank;
    [SerializeField] private FuelTankSO currentFuelTank;
    [SerializeField] private ShoeSO currentShoe;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (currentO2Tank == null) currentO2Tank = defaultO2Tank;
        if (currentFuelTank == null) currentFuelTank = defaultFuelTank;
        if (currentShoe == null) currentShoe = defaultShoe;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        ApplyToPlayerIfFound();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ApplyToPlayerIfFound();
    }

    public void SelectO2Tank(O2TankSO tank)
    {
        currentO2Tank = tank;
        ApplyToPlayerIfFound();
    }

    public void SelectFuelTank(FuelTankSO tank)
    {
        currentFuelTank = tank;
        ApplyToPlayerIfFound();
    }

    public void SelectShoe(ShoeSO shoe)
    {
        currentShoe = shoe;
        ApplyToPlayerIfFound();
    }

    private void ApplyToPlayerIfFound()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj == null) return;

        PlayerO2 o2 = playerObj.GetComponent<PlayerO2>();
        if (o2 != null)
            o2.ApplyO2Tank(currentO2Tank, true);

        PlayerFuel fuel = playerObj.GetComponent<PlayerFuel>();
        if (fuel != null)
            fuel.ApplyFuelTank(currentFuelTank, true);

        PlayerMovement move = playerObj.GetComponent<PlayerMovement>();
        if (move != null && currentShoe != null)
            move.SetSpeed(currentShoe.moveSpeed);
    }
}
