using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartAutoSave : MonoBehaviour
{
    private void Start()
    {
        if (SaveManager.Instance == null) return;

        if (SaveManager.Instance.IsLoadingGame)
        {
            Debug.Log("Auto Save skipped: scene was loaded from save.");
            return;
        }

        SaveManager.Instance.SaveCurrentGame();
    }
}
