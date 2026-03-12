using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimAndShoot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private Camera _cam;

    [SerializeField] private bool _shooting;

    [SerializeField] private float _time;
    [SerializeField] private float _firerate;
    [SerializeField] private float _nextTimeToShoot;
    [SerializeField] private float _range;

    [SerializeField] private Vector2 _mousePos;
    [SerializeField] private Vector2 _lookDir;

    [SerializeField] private Transform _firePoint;

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _firePrefab;

    [SerializeField] private float _shootForce;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        

        _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);

        _lookDir = _mousePos - _rb.position;
        float angle = Mathf.Atan2(_lookDir.y, _lookDir.x) * Mathf.Rad2Deg - 90f;
        
        _firePoint.eulerAngles = new Vector3(0,0,angle);

        _firePrefab.transform.rotation = _firePoint.rotation;
        _firePrefab.transform.localPosition = _firePoint.up * _range;

        _time += Time.deltaTime;


        /*if (_time > 1 / _firerate && _shooting)
        {

            Fire(_shooting);
            _time = 0;

        }*/

        if (Input.GetMouseButtonDown(0))
        {
            //_shooting = true;
            _firePrefab.SetActive(true);
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            //_shooting = false;
            _firePrefab.SetActive(false);
        }

        
        
        
        

    }

    private void Fire(bool isShooting)
    {
        //GameObject fire = Instantiate(_firePrefab, _firePoint.position, _firePoint.rotation);
        //fire.transform.position = _firePoint.transform.up * _range;
        //Rigidbody2D fireRB = fire.GetComponent<Rigidbody2D>();
        //fireRB.AddForce( _firePoint.up *  _shootForce, ForceMode2D.Impulse);

        
    }
}
