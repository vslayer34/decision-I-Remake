using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCard : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the image component of the card")]
    private Image _cardWeaponImage;



    // Game Loop Methods---------------------------------------------------------------------------
    // Member Methods------------------------------------------------------------------------------
    // Getters and Setters-------------------------------------------------------------------------

    public Sprite CardWeaponImageSprite { get => _cardWeaponImage.sprite; set => _cardWeaponImage.sprite = value; }
}
