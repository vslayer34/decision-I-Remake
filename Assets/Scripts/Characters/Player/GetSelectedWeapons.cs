using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSelectedWeapons : MonoBehaviour
{
    [SerializeField, Header("Required SOs"), Tooltip("Reference to the inventory so")]
    private SO_Inventory _inventory;

    private List<Weapon> _runSelectedWeapons = new List<Weapon>();



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        GetPlayerChosenWeapons();
    }

    // Member Methods------------------------------------------------------------------------------

    /// <summary>
    /// Spawn the weapon that the player selected for this run
    /// </summary>
    private void GetPlayerChosenWeapons()
    {
        Weapon spawnedWeapon;

        for (int i = 0; i < _inventory.AvailableWeapons.Count; i++)
        {
            if (_inventory.AvailableWeapons[i] != null)
            {
                spawnedWeapon = Instantiate(_inventory.AvailableWeapons[i].WeaponPrefab, transform).GetComponent<Weapon>();
                _runSelectedWeapons.Add(spawnedWeapon);
            }
        }
    }


    // private void SetActiveWeapon(int index = 0)
    // {
    //     for (int i = 0; i < _runSelectedWeapons.Count; i++)
    //     {
    //         if (_runSelectedWeapons[i])
    //         {
    //             _runSelectedWeapons[i].gameObject.SetActive(true);
    //         }
    //     }
    // }
    // Getters and Setters-------------------------------------------------------------------------

    public List<Weapon> SelectedWeapons { get => _runSelectedWeapons; }
}
