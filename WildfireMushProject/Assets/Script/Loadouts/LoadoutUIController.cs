using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadoutUIController : MonoBehaviour
{
    private LoadoutManager loadoutManager;

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

    [Header("O2 Buttons")]
    [SerializeField] private Button o2Button01;
    [SerializeField] private Button o2Button02;
    [SerializeField] private Button o2Button03;

    [Header("Fuel Buttons")]
    [SerializeField] private Button fuelButton01;
    [SerializeField] private Button fuelButton02;
    [SerializeField] private Button fuelButton03;

    [Header("Shoe Buttons")]
    [SerializeField] private Button shoeButton01;
    [SerializeField] private Button shoeButton02;
    [SerializeField] private Button shoeButton03;

    [Header("Loadout Slot Buttons")]
    [SerializeField] private Button loadLoadoutButton1;
    [SerializeField] private Button loadLoadoutButton2;
    [SerializeField] private Button loadLoadoutButton3;

    [Header("Selected Color")]
    [SerializeField] private Color selectedColor = Color.gray;

    private Color o2Button01DefaultColor;
    private Color o2Button02DefaultColor;
    private Color o2Button03DefaultColor;

    private Color fuelButton01DefaultColor;
    private Color fuelButton02DefaultColor;
    private Color fuelButton03DefaultColor;

    private Color shoeButton01DefaultColor;
    private Color shoeButton02DefaultColor;
    private Color shoeButton03DefaultColor;

    private Color loadLoadoutButton1DefaultColor;
    private Color loadLoadoutButton2DefaultColor;
    private Color loadLoadoutButton3DefaultColor;

    private void Awake()
    {
        loadoutManager = FindObjectOfType<LoadoutManager>();

        SaveDefaultButtonColors();
    }

    private void Start()
    {
        if (loadoutManager != null)
        {
            loadoutManager.OnLoadoutChanged += RefreshSelectedButtons;
        }

        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.OnSelectedLoadoutSlotChanged += RefreshSelectedButtons;
        }

        RefreshSelectedButtons();
    }

    private void OnDestroy()
    {
        if (loadoutManager != null)
        {
            loadoutManager.OnLoadoutChanged -= RefreshSelectedButtons;
        }

        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.OnSelectedLoadoutSlotChanged -= RefreshSelectedButtons;
        }
    }

    private void SaveDefaultButtonColors()
    {
        o2Button01DefaultColor = GetButtonColor(o2Button01);
        o2Button02DefaultColor = GetButtonColor(o2Button02);
        o2Button03DefaultColor = GetButtonColor(o2Button03);

        fuelButton01DefaultColor = GetButtonColor(fuelButton01);
        fuelButton02DefaultColor = GetButtonColor(fuelButton02);
        fuelButton03DefaultColor = GetButtonColor(fuelButton03);

        shoeButton01DefaultColor = GetButtonColor(shoeButton01);
        shoeButton02DefaultColor = GetButtonColor(shoeButton02);
        shoeButton03DefaultColor = GetButtonColor(shoeButton03);

        loadLoadoutButton1DefaultColor = GetButtonColor(loadLoadoutButton1);
        loadLoadoutButton2DefaultColor = GetButtonColor(loadLoadoutButton2);
        loadLoadoutButton3DefaultColor = GetButtonColor(loadLoadoutButton3);
    }

    private Color GetButtonColor(Button button)
    {
        if (button == null) return Color.white;

        Image image = button.GetComponent<Image>();
        if (image == null) return Color.white;

        return image.color;
    }

    public void SelectO2_01()
    {
        if (loadoutManager == null) return;

        ClearSelectedLoadoutSlot();
        loadoutManager.SelectO2Tank(o2_01);
    }

    public void SelectO2_02()
    {
        if (loadoutManager == null) return;

        ClearSelectedLoadoutSlot();
        loadoutManager.SelectO2Tank(o2_02);
    }

    public void SelectO2_03()
    {
        if (loadoutManager == null) return;

        ClearSelectedLoadoutSlot();
        loadoutManager.SelectO2Tank(o2_03);
    }

    public void SelectFuel_01()
    {
        if (loadoutManager == null) return;

        ClearSelectedLoadoutSlot();
        loadoutManager.SelectFuelTank(fuel_01);
    }

    public void SelectFuel_02()
    {
        if (loadoutManager == null) return;

        ClearSelectedLoadoutSlot();
        loadoutManager.SelectFuelTank(fuel_02);
    }

    public void SelectFuel_03()
    {
        if (loadoutManager == null) return;

        ClearSelectedLoadoutSlot();
        loadoutManager.SelectFuelTank(fuel_03);
    }

    public void SelectShoe_01()
    {
        if (loadoutManager == null) return;

        ClearSelectedLoadoutSlot();
        loadoutManager.SelectShoe(shoe_01);
    }

    public void SelectShoe_02()
    {
        if (loadoutManager == null) return;

        ClearSelectedLoadoutSlot();
        loadoutManager.SelectShoe(shoe_02);
    }

    public void SelectShoe_03()
    {
        if (loadoutManager == null) return;

        ClearSelectedLoadoutSlot();
        loadoutManager.SelectShoe(shoe_03);
    }

    public void RefreshSelectedButtons()
    {
        if (loadoutManager == null) return;

        loadoutManager.GetCurrentSelectionObjects(
            out O2TankSO currentO2,
            out FuelTankSO currentFuel,
            out ShoeSO currentShoe
        );

        SetButtonSelected(o2Button01, currentO2 == o2_01, o2Button01DefaultColor);
        SetButtonSelected(o2Button02, currentO2 == o2_02, o2Button02DefaultColor);
        SetButtonSelected(o2Button03, currentO2 == o2_03, o2Button03DefaultColor);

        SetButtonSelected(fuelButton01, currentFuel == fuel_01, fuelButton01DefaultColor);
        SetButtonSelected(fuelButton02, currentFuel == fuel_02, fuelButton02DefaultColor);
        SetButtonSelected(fuelButton03, currentFuel == fuel_03, fuelButton03DefaultColor);

        SetButtonSelected(shoeButton01, currentShoe == shoe_01, shoeButton01DefaultColor);
        SetButtonSelected(shoeButton02, currentShoe == shoe_02, shoeButton02DefaultColor);
        SetButtonSelected(shoeButton03, currentShoe == shoe_03, shoeButton03DefaultColor);

        RefreshLoadoutSlotButtons();
    }

    public void RefreshLoadoutSlotButtons()
    {
        int selectedSlot = 0;

        if (SaveManager.Instance != null)
        {
            selectedSlot = SaveManager.Instance.CurrentSelectedLoadoutSlot;
        }

        SetButtonSelected(loadLoadoutButton1, selectedSlot == 1, loadLoadoutButton1DefaultColor);
        SetButtonSelected(loadLoadoutButton2, selectedSlot == 2, loadLoadoutButton2DefaultColor);
        SetButtonSelected(loadLoadoutButton3, selectedSlot == 3, loadLoadoutButton3DefaultColor);
    }

    private void ClearSelectedLoadoutSlot()
    {
        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.ClearSelectedLoadoutSlot();
        }
    }

    private void SetButtonSelected(Button button, bool selected, Color defaultColor)
    {
        if (button == null) return;

        Image image = button.GetComponent<Image>();
        if (image == null) return;

        image.color = selected ? selectedColor : defaultColor;
    }
}
