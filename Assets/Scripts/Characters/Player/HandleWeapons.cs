using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandleWeapons : MonoBehaviour
{
    [field: SerializeField, Tooltip("Weapon holding area")]
    public Transform WeaponHoldPoint { get; private set; }

    [SerializeField, Tooltip("Reference to the range sprite")]
    private SpriteRenderer _spriteRenderer;

    [SerializeField, Tooltip("Reference to the character")]
    private Transform _characterPivot;

    private Collider _followTarget;


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
        float nearestEnemy = float.MaxValue;

        int collisionCount = Physics.OverlapSphereNonAlloc(transform.position, _testRadius, _hits, (int)_zombieLayerMask);

        if (collisionCount == 0)
        {
            if (_followTarget == null)
            {
                return;
            }
            
            _followTarget = null;
            Debug.Log("Reset target");
            ResetCharacterPivot();
            return;
        }

        for (int i = 0; i < collisionCount; i++)
        {
            // if (_hits[i].TryGetComponent(out ITakeDamage damageable))
            // {
            //     if ((_hits[i].transform.position - transform.position).sqrMagnitude < nearestEnemy)
            //     {
            //         // _followTarget = _hits[i].;
            //     }

            //     _characterPivot.LookAt(_hits[i].transform, Vector3.up);
            //     break;
            // }

            if ((_hits[i].transform.position - transform.position).sqrMagnitude < nearestEnemy)
            {
                _followTarget = _hits[i];
                nearestEnemy = (_hits[i].transform.position - transform.position).sqrMagnitude;
            }
            
            _characterPivot.LookAt(_followTarget.transform, Vector3.up);
        }
    }


    // Signal Methods------------------------------------------------------------------------------

    private void ResetCharacterPivot() => _characterPivot.rotation = /*Quaternion.Euler(0, 0, 0)*/transform.rotation;
}
