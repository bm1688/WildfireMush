using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShoeSO", menuName = "Scriptable Objects/ShoeSO")]
public class ShoeSO : ScriptableObject
{
    [SerializeField] private float _speed;
}
