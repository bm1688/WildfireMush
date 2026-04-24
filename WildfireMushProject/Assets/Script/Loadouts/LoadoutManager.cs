using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadoutManager : MonoBehaviour
{
    public static LoadoutManager Instance { get; private set; }

    [Header("All Parts Database")]
    [SerializeField] private List<O2TankSO> allO2Tanks = new List<O2TankSO>();
    [SerializeField] private List<FuelTankSO> allFuelTanks = new List<FuelTankSO>();
    [SerializeField] private List<ShoeSO> allShoes = new List<ShoeSO>();

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
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (currentO2Tank == null) currentO2Tank = defaultO2Tank;
        if (currentFuelTank == null) currentFuelTank = defaultFuelTank;
        if (currentShoe == null) currentShoe = defaultShoe;

        SceneManager.sceneLoaded += OnSceneLoaded;
        Debug.Log("LoadoutManager Instance ID: " + GetInstanceID());
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

    public void GetCurrentSelectionIds(out string o2Id, out string fuelId, out string shoeId)
    {
        o2Id = currentO2Tank != null ? currentO2Tank.id : "";
        fuelId = currentFuelTank != null ? currentFuelTank.id : "";
        shoeId = currentShoe != null ? currentShoe.id : "";
    }

    public void SetSelectedByIds(string o2Id, string fuelId, string shoeId)
    {
        Debug.Log("SetSelectedByIds called");
        Debug.Log("Wanted O2 = " + o2Id);
        Debug.Log("Wanted Fuel = " + fuelId);
        Debug.Log("Wanted Shoe = " + shoeId);

        O2TankSO foundO2 = FindO2TankById(o2Id);
        FuelTankSO foundFuel = FindFuelTankById(fuelId);
        ShoeSO foundShoe = FindShoeById(shoeId);

        Debug.Log("Found O2 = " + (foundO2 != null ? foundO2.id : "NULL"));
        Debug.Log("Found Fuel = " + (foundFuel != null ? foundFuel.id : "NULL"));
        Debug.Log("Found Shoe = " + (foundShoe != null ? foundShoe.id : "NULL"));

        if (foundO2 != null) currentO2Tank = foundO2;
        if (foundFuel != null) currentFuelTank = foundFuel;
        if (foundShoe != null) currentShoe = foundShoe;

        Debug.Log("Current O2 after set = " + (currentO2Tank != null ? currentO2Tank.id : "NULL"));
        Debug.Log("Current Fuel after set = " + (currentFuelTank != null ? currentFuelTank.id : "NULL"));
        Debug.Log("Current Shoe after set = " + (currentShoe != null ? currentShoe.id : "NULL"));

        ApplyToPlayerIfFound();
    }

    private O2TankSO FindO2TankById(string id)
    {
        for (int i = 0; i < allO2Tanks.Count; i++)
        {
            if (allO2Tanks[i] != null && allO2Tanks[i].id == id)
                return allO2Tanks[i];
        }
        return null;
    }

    private FuelTankSO FindFuelTankById(string id)
    {
        for (int i = 0; i < allFuelTanks.Count; i++)
        {
            if (allFuelTanks[i] != null && allFuelTanks[i].id == id)
                return allFuelTanks[i];
        }
        return null;
    }

    private ShoeSO FindShoeById(string id)
    {
        for (int i = 0; i < allShoes.Count; i++)
        {
            if (allShoes[i] != null && allShoes[i].id == id)
                return allShoes[i];
        }
        return null;
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
