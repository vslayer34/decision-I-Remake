using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSelectedWeapons : MonoBehaviour
{
    [SerializeField, Header("Required SOs"), Tooltip("Reference to the inventory so")]
    private SO_Inventory _inventory;

    private List<Weapon> _runSelectedWeapons = new List<Weapon>();

    private Weapon _currentActiveWeapon;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        GetPlayerChosenWeapons();
        SetActiveWeapon();

        WeaponCard.OnCardSelected += SetActiveWeapon;
    }

    private void OnDisable()
    {
        WeaponCard.OnCardSelected -= SetActiveWeapon;
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
                spawnedWeapon.gameObject.SetActive(false);
            }
        }
    }


    public void SetActiveWeapon(int index = 0)
    {
        // _runSelectedWeapons[index].ActivateWeapon();
        _inventory.ChangeActiveWeapon(_runSelectedWeapons[index]);

        // disable the previouse selected weapon before setting the new one
        _currentActiveWeapon?.gameObject.SetActive(false);
        _currentActiveWeapon = _inventory.ActiveWeapon;
        _currentActiveWeapon.gameObject.SetActive(true);
    }
    
    // Getters and Setters-------------------------------------------------------------------------

    public List<Weapon> SelectedWeapons { get => _runSelectedWeapons; }
}
