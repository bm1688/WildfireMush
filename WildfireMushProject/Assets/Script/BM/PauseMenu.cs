using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Image _pausePanel;

    [SerializeField] private GameObject _loadoutUI;
    [SerializeField] private GameObject _loadoutRootUI;
    [SerializeField] private GameObject _loadoutSaveLoadUI;

    [SerializeField] private int _saveLoadToggleValue;

    [SerializeField] private int _toggleValue;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _toggleValue == 0)
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _toggleValue == 1)
        {
            Continue();
        }

        if (Input.GetKeyDown(KeyCode.F) && _saveLoadToggleValue == 0)
        {
            OpenLoadout();
        }
        else if (Input.GetKeyDown(KeyCode.F) && _saveLoadToggleValue == 1)
        {
            CloseLoadout();
        }
    }

    public void Resume()
    {
        Continue();
    }

    private void PauseGame()
    {
        _pausePanel.enabled = true;
        //_loadoutUI.SetActive(true);
        _toggleValue = 1;
        Time.timeScale = 0f;
    }

    private void Continue()
    {
        CloseLoadout();
        _pausePanel.enabled = false;
        _loadoutUI.SetActive(false);
        _toggleValue = 0;
        Time.timeScale = 1f;
    }

    private void OpenLoadout()
    {
        _loadoutUI.SetActive(true);
        _saveLoadToggleValue = 1;
        Time.timeScale = 0f;
    }
        
    private void CloseLoadout()
    {
        _loadoutUI.SetActive(false );
        _saveLoadToggleValue = 0;
        Time.timeScale = 1f;
    }
    
}
