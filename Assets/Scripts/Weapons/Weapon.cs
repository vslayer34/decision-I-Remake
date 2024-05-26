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

    protected bool _isReloading;

    private const float SECONDS_PER_MINUTE = 60.0f;


    protected virtual void Start()
    {
        
    }



    /// <summary>
    /// Shoot the weapon and play its sound
    /// </summary>
    public virtual void UseWeapon()
    {
        if (!_isShooting && !_isReloading)
        {
            if (_currentMagazineSize <= 0 && !_isReloading)
            {
                _isReloading = true;
                StartCoroutine(ReloadWeapon());
                return;
            }

            _isShooting = true;
            StartCoroutine(Shoot());
        }
    }


    /// <summary>
    /// Shoot the weapon according to its fire rate and reduce its magazine size
    /// </summary>
    protected virtual IEnumerator Shoot()
    {
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
        _isReloading = false;
    }


    /// <summary>
    /// Set the weapon as active and set its properties
    /// </summary>
    public void ActivateWeapon()
    {
        _currentMagazineSize = _stats.MagazineSize;
    }


    /// <summary>
    /// Rotate the Bullet spawn point a bit to apply accuracys of the gun
    /// </summary>
    /// <param name="accuracy">The accuracy of the gun in the stats</param>
    protected void ApplyAccuracyValues(float accuracy)
    {
        BulletSpawnPosition.localRotation = Quaternion.Euler(
            Random.Range(-GetAxisAccuracy(accuracy), GetAxisAccuracy(accuracy)), 
            Random.Range(-GetAxisAccuracy(accuracy), GetAxisAccuracy(accuracy)), 
            0.0f
        );
    }


    /// <summary>
    /// Get random rotation for the x, y axises according to the accuracy and deviation values
    /// </summary>
    /// <param name="accuracy">The accuracy of the used weapon</param>
    /// <returns></returns>
    private float GetAxisAccuracy(float accuracy)
    {
        const float DEVIATION = 10.0f;
        const float MAX_ACCURACY = 10.0f;

        return DEVIATION - Random.Range(accuracy, MAX_ACCURACY);
    }
}
