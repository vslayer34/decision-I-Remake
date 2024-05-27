using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableWeapons : MonoBehaviour
{
    [SerializeField, Header("Inventory reference"), Tooltip("Reference to the inventory SO")]
    private SO_Inventory _inventory;


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
        WeaponCard weaponCard;

        for (int i = 0; i < BELT_SIZE; i++)
        {
            weaponCard = Instantiate(_weaponCard, transform).GetComponent<WeaponCard>();
            
            if (_inventory.AvailableWeapons[i] != null)
            {
                weaponCard.CardWeaponImageSprite = _inventory.AvailableWeapons[i].WeaponIcon;
            }
        }
    }
}
