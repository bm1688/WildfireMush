using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerO2 : MonoBehaviour
{
    public float currentO2 = 100;
    public float maxO2 = 100;

    public Presenter presenter;

    [Header("Rates")]
    [SerializeField] private float decreaseRate = 10f;
    [SerializeField] private float regenRate = 27f;
    [SerializeField] private GameOver GameOverScript;

    private int smokeCount = 0;
    private bool death = true;

    void Start()
    {
        presenter.SetMaxO2(maxO2);
        currentO2 = maxO2;
    }

    void Update()
    {
        if (smokeCount > 0)
        {
            O2Decrease(decreaseRate);
        }
        else
        {
            O2Regen(regenRate);
        }

        if (currentO2 > maxO2)
            currentO2 = maxO2;

        if (currentO2 < 0 && death == true)
        {
            death = false;
            Debug.Log("Player died from lack of oxygen! Loading GameOver screen");
            GameOverScript.GameOverScreen();
        }

        presenter.SetO2(currentO2);
    }

    void O2Decrease(float rate)
    {
        currentO2 -= rate * Time.deltaTime;
    }

    void O2Regen(float rate)
    {
        currentO2 += rate * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Smoke"))
        {
            smokeCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Smoke"))
        {
            smokeCount--;

            if (smokeCount < 0)
                smokeCount = 0;
        }
    }

    public void ApplyO2Tank(O2TankSO tank, bool refill = true)
    {
        if (tank == null) return;

        maxO2 = tank.maxO2;
        regenRate = tank.regenRate;
        decreaseRate = tank.decreaseRate;

        if (refill)
            currentO2 = maxO2;

        presenter.SetMaxO2(maxO2);
        presenter.SetO2(currentO2);
    }
}
