using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private GameOver GameOverScript;
    public void Kill()
    {
        GameOverScript.GameOverScreen();
    }


}
