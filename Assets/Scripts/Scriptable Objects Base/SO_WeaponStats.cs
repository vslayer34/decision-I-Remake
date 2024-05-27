using System;
using UnityEngine;


public class SO_WeaponStats : ScriptableObject
{
    public enum Type
    {
        MELE,
        HAND_GUN,
        SHOTGUN,
        AUTO_RIFLE,
        RIFLE,
        LAUNCHER
    }

    [field: SerializeField, Tooltip("The name of the weapon")]
    public String Name { get; private set; }

    [field: SerializeField, Tooltip("The weapon sprite")]
    public Sprite WeaponIcon { get; private set; }
    

    [field: SerializeField, Tooltip("The class of the weapon")]
    /// <summary>
    /// The class of the weapon
    /// </summary>
    public Type WeaponClass { get; protected set; }

    
    [field: SerializeField, Tooltip("The range of said weapon")]
    /// <summary>
    /// The range of the weapon
    /// </summary>
    public float Range { get; protected set; }

    
    [field: SerializeField, Tooltip("The reload time of said weapon")]
    /// <summary>
    /// The reload time of the gun
    /// </summary>
    public float ReloadTime { get; protected set; }

    
    [field: SerializeField, Tooltip("Magazine size")]
    /// <summary>
    /// Number of rounds before reloading is required
    /// </summary>
    public int MagazineSize { get; protected set; }


    [field: SerializeField, Tooltip("The fire rate of the weapon")]
    public float FireRate { get; protected set; }


    [field: SerializeField, Tooltip("Weapon Accuracy")]
    public float Accuracy { get; protected set; }


    [field: SerializeField, Tooltip("Bullet prefab")]
    public Transform BulletPrefab { get; protected set; }
}