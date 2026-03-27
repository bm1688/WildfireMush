using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShoeSO", menuName = "Scriptable Objects/ShoeSO")]
public class ShoeSO : ScriptableObject
{
    [Header("ID / Name")]
    public string id = "shoe_01";
    public string displayName = "Shoe 01";

    [Header("Stats")]
    public float moveSpeed = 5f;
}
