using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField, Tooltip("This particler weapon state")]
    protected SO_WeaponStats _stats;

    protected int _currentMagazineSize;

    private const float SECONDS_PER_MINUTE = 60.0f;


    protected virtual void Start()
    {
        
    }



    /// <summary>
    /// Shoot the weapon and play its sound
    /// </summary>
    public virtual void PullTrigger()
    {
        if (_currentMagazineSize <= 0)
        {
            ReloadWeapon();    
        }

        StartCoroutine(Shoot());
    }

    protected virtual IEnumerator Shoot()
    {
        yield return new WaitForSeconds(_stats.FireRate / SECONDS_PER_MINUTE);
        Debug.Log("Pew Pew");
        _currentMagazineSize--;
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
