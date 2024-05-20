using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandleWeapons : MonoBehaviour
{
    [field: SerializeField, Tooltip("Weapon holding area")]
    public Transform WeaponHoldPoint { get; private set; }

    private Weapon _heldWeapon;

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

    private void Start()
    {
        GetActiveWeapon();
    }
    
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
            // ResetCharacterPivot();
            StartCoroutine(ResetCharacterPivot(transform.rotation));
            return;
        }

        for (int i = 0; i < collisionCount; i++)
        {
            if ((_hits[i].transform.position - transform.position).sqrMagnitude < nearestEnemy)
            {
                _followTarget = _hits[i];
                nearestEnemy = (_hits[i].transform.position - transform.position).sqrMagnitude;
            }
            
            _characterPivot.LookAt(_followTarget.transform, Vector3.up);
            // Quaternion.LookRotation
            // StartCoroutine(ResetCharacterPivot(Quaternion.LookRotation(_followTarget.transform.position, Vector3.up)));
            _heldWeapon.PullTrigger();
            break;
        }
    }


    // Signal Methods------------------------------------------------------------------------------

    /// <summary>
    /// Reset the pivott rotation with the players when their is no enemy on sight
    /// </summary>
    private IEnumerator ResetCharacterPivot(Quaternion targetRotation)
    {
        // _characterPivot.rotation = transform.rotation;
        float rotationTime = 0.5f;
        float currentTime = 0.0f;
        Quaternion currentRotation = _characterPivot.rotation;

        while (currentTime <= rotationTime)
        {
            currentTime += Time.deltaTime;
            _characterPivot.rotation = Quaternion.Lerp(currentRotation, targetRotation, currentTime / rotationTime);
            yield return null;
        }
    }

    /// <summary>
    /// Get the current held weapon and set it as active
    /// </summary>
    /// <typeparam name="Weapon"></typeparam>
    private void GetActiveWeapon()
    {
        _heldWeapon = WeaponHoldPoint.GetComponentInChildren<Weapon>();
        _heldWeapon.ActivateWeapon();
    }
}
