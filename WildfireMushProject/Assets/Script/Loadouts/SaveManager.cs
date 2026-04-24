using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    [SerializeField] private string fileName = "saveData.json";

    private SaveData pendingLoadData;
    private bool isLoadingGame = false;

    private string SavePath => Path.Combine(Application.persistentDataPath, fileName);

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
        if (isLoadingGame)
        {
            Debug.Log("Save skipped: game is loading.");
            return;
        }

        if (LoadoutManager.Instance == null)
        {
            Debug.LogWarning("Save failed: LoadoutManager not found.");
            return;
        }

        SaveData data = new SaveData();
        data.levelId = SceneManager.GetActiveScene().name;

        LoadoutManager.Instance.GetCurrentSelectionIds(out data.o2TankId, out data.fuelTankId, out data.shoeId);

        Debug.Log("Saving:");
        Debug.Log("Level = " + data.levelId);
        Debug.Log("O2 = " + data.o2TankId);
        Debug.Log("Fuel = " + data.fuelTankId);
        Debug.Log("Shoe = " + data.shoeId);

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SavePath, json);

        Debug.Log("Game Saved: " + SavePath);
    }

    public void LoadGame()
    {
        if (!File.Exists(SavePath))
        {
            Debug.LogWarning("No save file found.");
            return;
        }

        string json = File.ReadAllText(SavePath);
        pendingLoadData = JsonUtility.FromJson<SaveData>(json);

        if (pendingLoadData == null)
        {
            Debug.LogWarning("Load failed: save data is invalid.");
            return;
        }

        Debug.Log("Loading file...");
        Debug.Log("Loaded Level = " + pendingLoadData.levelId);
        Debug.Log("Loaded O2 = " + pendingLoadData.o2TankId);
        Debug.Log("Loaded Fuel = " + pendingLoadData.fuelTankId);
        Debug.Log("Loaded Shoe = " + pendingLoadData.shoeId);

        isLoadingGame = true;

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

    public bool HasSaveFile()
    {
        return File.Exists(SavePath);
    }

    public void DeleteSave()
    {
        if (File.Exists(SavePath))
        {
            File.Delete(SavePath);
            Debug.Log("Save file deleted.");
        }
    }
}
