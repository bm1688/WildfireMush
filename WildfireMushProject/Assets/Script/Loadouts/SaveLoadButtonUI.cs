using UnityEngine;

public class SaveLoadButtonUI : MonoBehaviour
{
    [SerializeField] private LoadoutUIController loadoutUIController;

    private void Awake()
    {
        if (loadoutUIController == null)
        {
            loadoutUIController = FindObjectOfType<LoadoutUIController>();
        }
    }

    public void SaveGame()
    {
        if (SaveManager.Instance == null) return;
        SaveManager.Instance.SaveCurrentGame();
    }

    public void LoadGame()
    {
        if (SaveManager.Instance == null) return;
        SaveManager.Instance.LoadGame();
    }

    public void SaveLoadout1()
    {
        if (SaveManager.Instance == null) return;
        SaveManager.Instance.SaveLoadoutSlot1();

        if (loadoutUIController != null)
            loadoutUIController.RefreshSelectedButtons();
    }

    public void SaveLoadout2()
    {
        if (SaveManager.Instance == null) return;
        SaveManager.Instance.SaveLoadoutSlot2();

        if (loadoutUIController != null)
            loadoutUIController.RefreshSelectedButtons();
    }

    public void SaveLoadout3()
    {
        if (SaveManager.Instance == null) return;
        SaveManager.Instance.SaveLoadoutSlot3();

        if (loadoutUIController != null)
            loadoutUIController.RefreshSelectedButtons();
    }

    public void LoadLoadout1()
    {
        if (SaveManager.Instance == null) return;
        SaveManager.Instance.LoadLoadoutSlot1();

        if (loadoutUIController != null)
            loadoutUIController.RefreshSelectedButtons();
    }

    public void LoadLoadout2()
    {
        if (SaveManager.Instance == null) return;
        SaveManager.Instance.LoadLoadoutSlot2();

        if (loadoutUIController != null)
            loadoutUIController.RefreshSelectedButtons();
    }

    public void LoadLoadout3()
    {
        if (SaveManager.Instance == null) return;
        SaveManager.Instance.LoadLoadoutSlot3();

        if (loadoutUIController != null)
            loadoutUIController.RefreshSelectedButtons();
    }
}