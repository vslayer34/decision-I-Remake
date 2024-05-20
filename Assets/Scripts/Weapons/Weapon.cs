using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField, Tooltip("This particler weapon state")]
    protected SO_WeaponStats _stats;


    [field: SerializeField, Tooltip("Bullet spawn point")]
    public Transform BulletSpawnPosition { get; protected set; }

    protected int _currentMagazineSize;

    protected bool _isShooting;

    private const float SECONDS_PER_MINUTE = 60.0f;


    protected virtual void Start()
    {
        
    }



    /// <summary>
    /// Shoot the weapon and play its sound
    /// </summary>
    public virtual void PullTrigger()
    {
        if (!_isShooting)
        {
            _isShooting = true;
            if (_currentMagazineSize <= 0)
            {
                ReloadWeapon();    
            }

            StartCoroutine(Shoot());
        }
    }

    protected virtual IEnumerator Shoot()
    {
        Debug.Log("Pew Pew");
        _currentMagazineSize--;
        yield return new WaitForSeconds(SECONDS_PER_MINUTE / _stats.FireRate);
        _isShooting = false;
    }

    /// <summary>
    /// Reload said weapon
    /// </summary>
    public IEnumerator ReloadWeapon()
    {
        yield return new WaitForSeconds(_stats.ReloadTime);
        _currentMagazineSize = _stats.MagazineSize;
        Debug.Log("Reloaded");
    }

    public void ActivateWeapon()
    {
        _currentMagazineSize = _stats.MagazineSize;
    }
}
