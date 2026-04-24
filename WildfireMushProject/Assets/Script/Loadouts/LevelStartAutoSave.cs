using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartAutoSave : MonoBehaviour
{
    private void Start()
    {
        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.SaveCurrentGame();
        }
    }
}
