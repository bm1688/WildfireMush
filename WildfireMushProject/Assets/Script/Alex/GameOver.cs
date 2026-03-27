using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    public void GameOverScreen()
    {
        Time.timeScale = 0;
        Panel.SetActive(true);
    }
}
