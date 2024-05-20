using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : Weapon
{
    private Transform _bullet;


    protected override void Start()
    {
        base.Start();
    }



    public override void PullTrigger()
    {
        base.PullTrigger();
    }

    protected override IEnumerator Shoot()
    {
        _bullet = Instantiate(_stats.BulletPrefab, BulletSpawnPosition.position, BulletSpawnPosition.rotation);
        yield return base.Shoot();
    }
}