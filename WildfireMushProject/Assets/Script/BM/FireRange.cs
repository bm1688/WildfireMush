using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRange : MonoBehaviour
{
    [SerializeField] private GameObject _firePrefab;

    [SerializeField] private float _fireRange;
    [SerializeField] private float _distance;

    [SerializeField] private Vector2 _startPos;
    [SerializeField] private Vector2 _endPos;
    // Start is called before the first frame update
    void Start()
    {
        _startPos = _firePrefab.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _endPos = _firePrefab.transform.position;
        _distance = Vector2.Distance(_startPos, _endPos);

        if (_distance >= _fireRange )
        {
            Destroy(_firePrefab);
        }
    }
}
