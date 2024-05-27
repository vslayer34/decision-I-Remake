using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableWeapons : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the Weapon card")]
    private Transform _weaponCard;

    private const int BELT_SIZE = 5;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        PopulateWeaponBelt();
    }

    // Member Methods------------------------------------------------------------------------------

    /// <summary>
    /// Create the weapon cards when the game starts
    /// </summary>
    private void PopulateWeaponBelt()
    {
        for (int i = 0; i < BELT_SIZE; i++)
        {
            Instantiate(_weaponCard, transform);
        }
    }
}
