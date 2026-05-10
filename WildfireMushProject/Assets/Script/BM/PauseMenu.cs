using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Image _pausePanel;

    [SerializeField] private GameObject _loadoutUI;

    [SerializeField] private GameObject _pauseUI;

    [SerializeField] private int _saveLoadToggleValue;

    [SerializeField] private int _toggleValue;

    [SerializeField] private bool _loadoutActive = false;

    [SerializeField] private bool _pauseActive = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _toggleValue == 0 && !_loadoutActive)
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _toggleValue == 1)
        {
            Continue();
            
            
        }

        if (Input.GetKeyDown(KeyCode.F) && _saveLoadToggleValue == 0 && !_pauseActive)
        {
            OpenLoadout();
        }
        else if (Input.GetKeyDown(KeyCode.F) && _saveLoadToggleValue == 1)
        {
            CloseLoadout();
            
        }
    }

    

    private void PauseGame()
    {
        _pausePanel.enabled = true;
        _pauseUI.SetActive(true);
        _pauseActive = true;
        _toggleValue = 1;
        Time.timeScale = 0f;
    }

    private void Continue()
    {
        
        _pausePanel.enabled = false;
        _pauseUI.SetActive(false);
        _pauseActive = false;
        _toggleValue = 0;
        Time.timeScale = 1f;
    }

    private void OpenLoadout()
    {
        _loadoutUI.SetActive(true);
        _loadoutActive = true;
        _saveLoadToggleValue = 1;
        Time.timeScale = 0f;
    }
        
    private void CloseLoadout()
    {
        _loadoutUI.SetActive(false);
        _loadoutActive = false;
        _saveLoadToggleValue = 0;
        Time.timeScale = 1f;
    }
    
}
