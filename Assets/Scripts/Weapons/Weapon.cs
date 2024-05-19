using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField, Tooltip("This particler weapon state")]
    protected SO_WeaponStats _stats;

    protected int _currentMagazineSize;


    protected virtual void Start()
    {
        _currentMagazineSize = _stats.MagazineSize;
    }



    /// <summary>
    /// Shoot the weapon and play its sound
    /// </summary>
    public virtual void ShootWeapon()
    {
        if (_currentMagazineSize <= 0)
        {
            ReloadWeapon();    
        }
        
        _currentMagazineSize--;
    }

    /// <summary>
    /// Reload said weapon
    /// </summary>
    public void ReloadWeapon()
    {
        _currentMagazineSize = _stats.MagazineSize;
    }

    public void ActivateWeapon()
    {

    }
}
