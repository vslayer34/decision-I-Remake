using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the rigid body;")]
    private Rigidbody _rigidBody;



    // Game Loop Methods---------------------------------------------------------------------------
    private void OnEnable()
    {
        ShootBullet();
    }

    private void OnDisable()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other != null && other.gameObject.TryGetComponent(out MeleZombie zombie))
        {
            gameObject.SetActive(false);
        }
    }

    // Member Methods------------------------------------------------------------------------------

    private void ShootBullet()
    {
        _rigidBody.AddForce(transform.forward * 10.0f, ForceMode.Impulse);
    }
}
