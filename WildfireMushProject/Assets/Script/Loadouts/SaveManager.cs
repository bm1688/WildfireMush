using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    [SerializeField] private string gameFileName = "saveData.json";
    [SerializeField] private string loadoutFileName = "loadoutSlots.json";

    private SaveData pendingLoadData;
    private bool isLoadingGame = false;

    private string GameSavePath => Path.Combine(Application.persistentDataPath, gameFileName);
    private string LoadoutSavePath => Path.Combine(Application.persistentDataPath, loadoutFileName);

    private int currentSelectedLoadoutSlot = 0;
    public int CurrentSelectedLoadoutSlot { get { return currentSelectedLoadoutSlot; } }

    public event Action OnSelectedLoadoutSlotChanged;
    public bool IsLoadingGame => isLoadingGame;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SaveCurrentGame()
    {
        if (isLoadingGame) return;

        if (LoadoutManager.Instance == null)
        {
            Debug.LogWarning("Save failed: LoadoutManager not found.");
            return;
        }

        SaveData data = new SaveData();

        data.levelId = SceneManager.GetActiveScene().name;
        data.selectedLoadoutSlot = currentSelectedLoadoutSlot;

        LoadoutManager.Instance.GetCurrentSelectionIds(
            out data.o2TankId,
            out data.fuelTankId,
            out data.shoeId
        );

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(GameSavePath, json);
    }

    public void LoadGame()
    {
        if (!File.Exists(GameSavePath))
        {
            Debug.LogWarning("No game save file found.");
            return;
        }

        string json = File.ReadAllText(GameSavePath);

        pendingLoadData = JsonUtility.FromJson<SaveData>(json);

        if (pendingLoadData == null)
        {
            Debug.LogWarning("Load failed: save data is invalid.");
            return;
        }

        isLoadingGame = true;

        SetCurrentSelectedLoadoutSlot(pendingLoadData.selectedLoadoutSlot);

        if (LoadoutManager.Instance != null)
        {
            LoadoutManager.Instance.SetSelectedByIds(
                pendingLoadData.o2TankId,
                pendingLoadData.fuelTankId,
                pendingLoadData.shoeId
            );
        }

        SceneManager.LoadScene(pendingLoadData.levelId);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        pendingLoadData = null;
        isLoadingGame = false;
    }

    public void SaveLoadoutSlot1()
    {
        SaveLoadoutSlot(1);
    }

    public void SaveLoadoutSlot2()
    {
        SaveLoadoutSlot(2);
    }

    public void SaveLoadoutSlot3()
    {
        SaveLoadoutSlot(3);
    }

    public void LoadLoadoutSlot1()
    {
        LoadLoadoutSlot(1);
    }

    public void LoadLoadoutSlot2()
    {
        LoadLoadoutSlot(2);
    }

    public void LoadLoadoutSlot3()
    {
        LoadLoadoutSlot(3);
    }

    private void SaveLoadoutSlot(int slotNumber)
    {
        if (LoadoutManager.Instance == null)
        {
            Debug.LogWarning("Save loadout failed: LoadoutManager not found.");
            return;
        }

        LoadoutSlotsSaveData slotsData = ReadLoadoutSlotsFile();

        LoadoutManager.Instance.GetCurrentSelectionIds(
            out string o2Id,
            out string fuelId,
            out string shoeId
        );

        LoadoutSlotData slotData = new LoadoutSlotData(o2Id, fuelId, shoeId);

        if (slotNumber == 1)
            slotsData.loadout1 = slotData;
        else if (slotNumber == 2)
            slotsData.loadout2 = slotData;
        else if (slotNumber == 3)
            slotsData.loadout3 = slotData;

        WriteLoadoutSlotsFile(slotsData);
        SetCurrentSelectedLoadoutSlot(slotNumber);
    }

    private void LoadLoadoutSlot(int slotNumber)
    {
        LoadoutSlotsSaveData slotsData = ReadLoadoutSlotsFile();

        LoadoutSlotData slotData = null;

        if (slotNumber == 1)
            slotData = slotsData.loadout1;
        else if (slotNumber == 2)
            slotData = slotsData.loadout2;
        else if (slotNumber == 3)
            slotData = slotsData.loadout3;

        if (slotData == null || slotData.IsEmpty())
        {
            Debug.LogWarning("Loadout slot " + slotNumber + " is empty.");
            return;
        }

        if (LoadoutManager.Instance == null)
        {
            Debug.LogWarning("Load loadout failed: LoadoutManager not found.");
            return;
        }

        SetCurrentSelectedLoadoutSlot(slotNumber);

        LoadoutManager.Instance.SetSelectedByIds(
            slotData.o2TankId,
            slotData.fuelTankId,
            slotData.shoeId
        );
    }

    private LoadoutSlotsSaveData ReadLoadoutSlotsFile()
    {
        if (!File.Exists(LoadoutSavePath))
        {
            return new LoadoutSlotsSaveData();
        }

        string json = File.ReadAllText(LoadoutSavePath);

        LoadoutSlotsSaveData data = JsonUtility.FromJson<LoadoutSlotsSaveData>(json);

        if (data == null)
            data = new LoadoutSlotsSaveData();

        return data;
    }

    private void WriteLoadoutSlotsFile(LoadoutSlotsSaveData data)
    {
        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(LoadoutSavePath, json);
    }

    public bool HasSaveFile()
    {
        return File.Exists(GameSavePath);
    }

    public void DeleteGameSave()
    {
        if (File.Exists(GameSavePath))
            File.Delete(GameSavePath);
    }

    public void DeleteLoadoutSlots()
    {
        if (File.Exists(LoadoutSavePath))
            File.Delete(LoadoutSavePath);
    }
    private void SetCurrentSelectedLoadoutSlot(int slotNumber)
    {
        currentSelectedLoadoutSlot = slotNumber;
        OnSelectedLoadoutSlotChanged?.Invoke();
    }
    public void ClearSelectedLoadoutSlot()
    {
        currentSelectedLoadoutSlot = 0;
    }
}
