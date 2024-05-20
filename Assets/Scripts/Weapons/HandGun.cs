using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : Weapon
{
    protected override void Start()
    {
        base.Start();
    }


    protected override IEnumerator Shoot()
    {
        return base.Shoot();
        
    }
}