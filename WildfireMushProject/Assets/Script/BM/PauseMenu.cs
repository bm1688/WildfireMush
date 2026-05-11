using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private LoadoutPageToggle _loadoutPageToggle;

    [SerializeField] private Image _pausePanel;

    

    [SerializeField] private GameObject _pauseUI;

    

    [SerializeField] private int _toggleValue;

    

    [SerializeField] private bool _pauseActive = false;
    public bool PauseActive {  get { return _pauseActive; }}

    // Update is called once per frame
    void Update()
    {
        if (!_loadoutPageToggle.LoadoutActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && _toggleValue == 0)
            {
                PauseGame();
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && _toggleValue == 1)
            {
                Continue();


            }
        }
        
        

        
    }

    public void Resume()
    {
        Continue();
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

    
    
}
