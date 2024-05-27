using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new inventory", menuName = "Game Globals/Inventory")]
public class SO_Inventory : ScriptableObject
{
    public event Action OnActiveWeaponChanged;

    [field: SerializeField, Tooltip("Reference to all available weapons the player havve")]
    public List<SO_WeaponStats> AvailableWeapons { get; private set; } = new List<SO_WeaponStats>(5);


    [field: SerializeField, Tooltip("Reference to the currently active weapon")]
    public Weapon ActiveWeapon { get; private set; }


    // Methods-------------------------------------------------------------------------------------

    /// <summary>
    /// Change the currently active weapon
    /// </summary>
    /// <param name="newlySelectedWeapon">The weapon the plaayer choose to select</param>
    public void ChangeActiveWeapon(Weapon newlySelectedWeapon)
    {
        ActiveWeapon = newlySelectedWeapon;
        OnActiveWeaponChanged?.Invoke();
    }
}
