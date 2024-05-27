using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Handles the Mele weapon behaviour
/// </summary>
public class MeleWeapon : Weapon
{
    [SerializeField, Tooltip("The enemies physics layer")]
    private LayerMask _enemyPhysicsLayer;
    private RaycastHit[] _hits = new RaycastHit[5];



    public override void UseWeapon()
    {
        int numberOfCollisions;
        numberOfCollisions = Physics.SphereCastNonAlloc(transform.position, 0.5f, transform.forward, 
            _hits, 1.0f, (int)_enemyPhysicsLayer);
        
        for (int i = 0; i < numberOfCollisions; i++)
        {
            Debug.Log(_hits[i].collider.name);
        }
    }
}
