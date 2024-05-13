using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleWeapons : MonoBehaviour
{
    [field: SerializeField, Tooltip("Weapon holding area")]
    public Transform WeaponHoldPoint { get; private set; }

    [SerializeField, Tooltip("Reference to the range sprite")]
    private SpriteRenderer _spriteRenderer;


    private RaycastHit[] _hits = new RaycastHit[20];

    [SerializeField, Tooltip("test radius")]
    private float _testRadius = 5.0f;


    /// <summary>
    /// the fixed radius that cover a one scale range sprite
    /// helps with calculating changing of the sprite size in relation to the range radius
    /// </summary>
    private const float _oneScaleRadiusCoverage = 6.5f;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Update()
    {
        DisplayRange();
    }
    
    // Member Methods------------------------------------------------------------------------------

    private void DisplayRange()
    {
        Physics.SphereCastNonAlloc(transform.position, _testRadius, Vector3.zero, _hits);
        _spriteRenderer.transform.localScale = Vector3.one * (_testRadius / _oneScaleRadiusCoverage); 
    }
}
