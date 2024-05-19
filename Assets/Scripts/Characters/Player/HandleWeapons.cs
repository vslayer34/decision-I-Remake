using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandleWeapons : MonoBehaviour
{
    [field: SerializeField, Tooltip("Weapon holding area")]
    public Transform WeaponHoldPoint { get; private set; }

    [SerializeField, Tooltip("Reference to the range sprite")]
    private SpriteRenderer _spriteRenderer;


    private Collider[] _hits = new Collider[20];

    [SerializeField, Tooltip("test radius")]
    private float _testRadius = 5.0f;

    [SerializeField, Tooltip("the layer mask for the zombies")]
    private LayerMask _zombieLayerMask;


    /// <summary>
    /// the fixed radius that cover a one scale range sprite
    /// helps with calculating changing of the sprite size in relation to the range radius
    /// </summary>
    private const float _oneScaleRadiusCoverage = 6.5f;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Update()
    {
        DisplayRange();
        DetectEnemies();
    }
    
    // Member Methods------------------------------------------------------------------------------

    private void DisplayRange()
    {
        _spriteRenderer.transform.localScale = Vector3.one * (_testRadius / _oneScaleRadiusCoverage); 
    }

    private void DetectEnemies()
    {
        // Physics.SphereCastNonAlloc(transform.position, _testRadius, transform.forward, _hits, 0.0f, (int)_zombieLayerMask);

        // for (int i = 0; i < _hits.Length; i++)
        // {
        //     if (_hits[i].collider != null && _hits[i].collider.TryGetComponent(out ITakeDamage damageable))
        //     {
        //         damageable?.TakeDamage();
        //         Debug.Log(_hits[i], this);
        //     }
        // }

        int collisionCount = Physics.OverlapSphereNonAlloc(transform.position, _testRadius, _hits, (int)_zombieLayerMask);

        for (int i = 0; i < collisionCount; i++)
        {
            if (_hits[i].TryGetComponent(out ITakeDamage damageable))
            {
                damageable?.TakeDamage();
            }
        }
    }
}
