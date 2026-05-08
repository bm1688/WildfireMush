using UnityEngine;

public class SaveLoadButtonUI : MonoBehaviour
{
    // Game Save / Load
    public void SaveGame()
    {
        if (SaveManager.Instance == null)
        {
            Debug.LogWarning("SaveManager Instance not found.");
            return;
        }

        SaveManager.Instance.SaveCurrentGame();
    }

    public void LoadGame()
    {
        if (SaveManager.Instance == null)
        {
            Debug.LogWarning("SaveManager Instance not found.");
            return;
        }

        SaveManager.Instance.LoadGame();
    }

    // Save Loadout Preset
    public void SaveLoadout1()
    {
        if (SaveManager.Instance == null) return;
        SaveManager.Instance.SaveLoadoutSlot1();
    }

    public void SaveLoadout2()
    {
        if (SaveManager.Instance == null) return;
        SaveManager.Instance.SaveLoadoutSlot2();
    }

    public void SaveLoadout3()
    {
        if (SaveManager.Instance == null) return;
        SaveManager.Instance.SaveLoadoutSlot3();
    }

    // Load Loadout Preset
    public void LoadLoadout1()
    {
        if (SaveManager.Instance == null) return;
        SaveManager.Instance.LoadLoadoutSlot1();
    }

    public void LoadLoadout2()
    {
        if (SaveManager.Instance == null) return;
        SaveManager.Instance.LoadLoadoutSlot2();
    }

    public void LoadLoadout3()
    {
        if (SaveManager.Instance == null) return;
        SaveManager.Instance.LoadLoadoutSlot3();
    }
}