using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadoutPageToggle : MonoBehaviour
{
    [SerializeField] private GameObject _loadoutUI;

    [SerializeField] private PauseMenu _pauseMenu;

    [SerializeField] private bool _loadoutActive;
    public bool LoadoutActive {  get { return _loadoutActive; } }

    [SerializeField] private int _toggleValue = 0;

    // Update is called once per frame
    void Update()
    {
        if (!_pauseMenu.PauseActive)
        {
            if (Input.GetKeyDown(KeyCode.F) && (_toggleValue == 0))
            {
                ActivateLoadout();
            }
            else if (Input.GetKeyDown(KeyCode.F) && (_toggleValue == 1))
            {
                DeactivateLoadout();
            }
        }
        
       
    }
    private void ActivateLoadout ()
    {
        _toggleValue = 1;
        _loadoutUI.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Open");
        _loadoutActive = true;
    }

    private void DeactivateLoadout ()
    {
        _toggleValue = 0;
        _loadoutUI.SetActive(false);
        Time.timeScale = 1f;
        _loadoutActive = false;
    }
}
