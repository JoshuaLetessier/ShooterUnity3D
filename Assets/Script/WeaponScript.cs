using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponScript : MonoBehaviour
{
    public GameObject _bullet;
    protected PlayerInput _input;
    protected InputAction _actionFire;
    protected int _ammo;
    protected float _cd;
    protected float _bulletSpeed;
    protected float _bulletDamage;
    protected float _bulletLifeTime;
    protected float _currentCd;
    // Start is called before the first frame update
    void Awake()
    {
        _input = new PlayerInput();
        Vector3 cameraPos = Camera.main.transform.position;
        transform.position = new Vector3(cameraPos.x + 0.4f, cameraPos.y - 0.6f, cameraPos.z + 9.3f);
        WeaponConfigure();
    }

    private void OnEnable()
    {
        _actionFire = _input.Player.Fire;
        _actionFire.Enable();
    }

    private void OnDisable()
    {
        _actionFire.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (_actionFire.IsPressed() && GotAmmo() && _currentCd == 0)
        {
            Shot();
        }

        if (_currentCd != 0)
            _currentCd -= Time.deltaTime;

        if (_currentCd < 0)
            _currentCd = 0;
    }

    bool GotAmmo()
    {
        if (_ammo > 0)
            return true;
        return false;
    }

    virtual protected void WeaponConfigure()
    { 

    }

    virtual protected void Shot()
    {
        
    }
}
