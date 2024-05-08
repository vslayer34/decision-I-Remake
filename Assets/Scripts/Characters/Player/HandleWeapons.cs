using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleWeapons : MonoBehaviour
{
    [field: SerializeField, Tooltip("Weapon holding area")]
    public Transform WeaponHoldPoint { get; private set; }
}
