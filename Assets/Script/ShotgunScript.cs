using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : WeaponScript
{
    protected override void WeaponConfigure()
    {
        _ammo = 16;
        _cd = 0.75f;
        _currentCd = 0f; 
        _bulletSpeed = 40f;
        _bulletDamage = 10f;
    }

    public override void Take()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        transform.parent.position = new Vector3(cameraPos.x + 0.2f, cameraPos.y - 0.1f, cameraPos.z + 0.4f);
    }
}
