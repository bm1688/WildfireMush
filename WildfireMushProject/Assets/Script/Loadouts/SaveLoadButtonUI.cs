using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadButtonUI : MonoBehaviour
{
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
}
