using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : WeaponScript
{
    protected override void WeaponConfigure()
    {
        _ammo = 8;
        _cd = 2f;
        _currentCd = 0f;
        _bulletSpeed = 60f;
        _bulletDamage = 1f;
        _bulletLifeTime = 3f;
    }

    protected override void Shot()
    {
        GameObject bullet = Instantiate(_bullet);
        //Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
        bullet.transform.position = transform.GetChild(0).position;
        Vector3 rotation = bullet.transform.rotation.eulerAngles;
        bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        bullet.GetComponent<Rigidbody>().AddForce(transform.GetChild(0).forward * _bulletSpeed, ForceMode.Impulse);
        _currentCd = _cd;
    }
}
