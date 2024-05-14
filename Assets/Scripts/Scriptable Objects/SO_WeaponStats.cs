using UnityEngine;


public class SO_WeaponStats : ScriptableObject
{
    public enum Type
    {
        HAND_GUN,
        SHOTGUN,
        AUTO_RIFLE,
        RIFLE,
        LAUNCHER
    }

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

    /// <summary>
    /// The reload time of the gun
    /// </summary>
    public float ReloadTime { get; protected set; }

    /// <summary>
    /// Number of rounds before reloading is required
    /// </summary>
    public int MagazineSize { get; protected set; }
}