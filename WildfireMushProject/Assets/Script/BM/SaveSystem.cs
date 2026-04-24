using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private LoadoutManager _loadoutManager;
    [SerializeField] private O2TankSO _o2TankSO;
    [SerializeField] private FuelTankSO _fuelTankSO;
    [SerializeField] private ShoeSO _shoeSO;

    [SerializeField] private string O2DATA;
    [SerializeField] private string FuelTankDATA;
    [SerializeField] private string ShoeDATA;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(_loadoutManager.GetCurrentLoadout());
        PlayerPrefs.GetInt(O2DATA);
        PlayerPrefs.GetInt(FuelTankDATA);
        PlayerPrefs.GetInt(ShoeDATA);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt(O2DATA, 0);
        Debug.Log(PlayerPrefs.GetInt(O2DATA));
        PlayerPrefs.SetInt(O2DATA, 1);
        Debug.Log(PlayerPrefs.GetInt(O2DATA));
    }
}
