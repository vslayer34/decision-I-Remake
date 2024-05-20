using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the rigid body;")]
    private Rigidbody _rigidBody;



    private void OnEnable()
    {
        ShootBullet();
    }

    // Member Methods------------------------------------------------------------------------------

    private void ShootBullet()
    {
        _rigidBody.AddForce(transform.forward * 10.0f, ForceMode.Impulse);
    }
}
