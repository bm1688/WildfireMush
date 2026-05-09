using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimAndShoot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private Camera _cam;

    [SerializeField] private bool _shooting;
    public bool Shooting { get { return _shooting; } }

    [SerializeField] private float _time;
    [SerializeField] private float _firerate;
    [SerializeField] private float _nextTimeToShoot;
    [SerializeField] private float _range;

    [SerializeField] private Vector2 _mousePos;
    [SerializeField] private Vector2 _lookDir;
    public Vector2 LookDir { get { return _lookDir; } }

    [SerializeField] private Transform _firePoint;

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _firePrefab;

    [SerializeField] private PlayerFuel _playerFuel;

    [SerializeField] private float _shootForce;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerFuel = GetComponent<PlayerFuel>();
    }

    void Update()
    {
        if (Time.timeScale == 0) { return; }
        _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);

        _lookDir = _mousePos - _rb.position;
        float angle = Mathf.Atan2(_lookDir.y, _lookDir.x) * Mathf.Rad2Deg - 90f;

        _firePoint.eulerAngles = new Vector3(0, 0, angle);

        _firePrefab.transform.rotation = _firePoint.rotation;
        _firePrefab.transform.localPosition = _firePoint.up * _range;

        _time += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && _playerFuel.currentFuel > 0)
        {
            _shooting = true;
            _firePrefab.SetActive(true);

            if (AudioManager.instance != null)
                AudioManager.instance.PlayFlamethrowerLoop();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopShooting();
        }

        if (_time > 1 / _firerate && _shooting)
        {
            _playerFuel.ConsumeFuel(_playerFuel.drainRate);
            _time = 0;
        }

        if (_playerFuel.currentFuel <= 0 && _shooting)
        {
            StopShooting();
        }
    }

    private void StopShooting()
    {
        _shooting = false;
        _firePrefab.SetActive(false);

        if (AudioManager.instance != null)
            AudioManager.instance.StopFlamethrowerLoop();
    }

    private void OnDisable()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.StopFlamethrowerLoop();
    }
}
