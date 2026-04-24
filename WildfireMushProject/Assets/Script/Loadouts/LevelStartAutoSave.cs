using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartAutoSave : MonoBehaviour
{
    [SerializeField] private bool autoSaveOnStart = true;

    private void Start()
    {
        if (!autoSaveOnStart) return;
        if (SaveManager.Instance == null) return;

        if (SaveManager.Instance.IsLoadingGame)
        {
            Debug.Log("Auto Save skipped: scene was loaded from save.");
            return;
        }

        SaveManager.Instance.SaveCurrentGame();
    }
}
