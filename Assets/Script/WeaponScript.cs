using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
public enum WeaponState
{
    Idle,
    Shot
}


public class WeaponScript : MonoBehaviour
{
    public GameObject _bullet;
    protected PlayerInput _input;
    protected InputAction _actionFire;
    protected int _ammo;
    protected float _cd;
    protected float _bulletSpeed;
    protected float _bulletDamage;
    protected float _currentCd;
    public WeaponState _state;
    protected Animator _animator;

    // Start is called before the first frame update
    void Awake()
    {
        _state = WeaponState.Idle;
        _input = new PlayerInput();
        _animator = GetComponent<Animator>();
        WeaponConfigure();
        Take();
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
        if (_actionFire.IsPressed() && GotAmmo() && _state == WeaponState.Idle)
        {
            _state = WeaponState.Shot;
            _animator.SetTrigger("isShotting");
            Shot();
        }

        if (_currentCd != 0)
            _currentCd -= Time.deltaTime;

        if (_currentCd < 0)
        {
            _state = WeaponState.Idle;
            _currentCd = 0;
        }
    }

    bool GotAmmo()
    {
        if (_ammo > 0)
            return true;
        return false;
    }
    public void Shot()
    {
        GameObject bullet = Instantiate(_bullet);
        bullet.transform.position = transform.GetChild(0).position;
        Vector3 rotation = bullet.transform.rotation.eulerAngles;
        bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        bullet.GetComponent<Rigidbody>().AddForce(transform.GetChild(0).forward * _bulletSpeed, ForceMode.Impulse);
        _currentCd = _cd;
        _ammo -= 1;
    }

    virtual protected void WeaponConfigure(){}

    virtual public void Take(){}

}
