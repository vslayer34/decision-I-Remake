using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCard : MonoBehaviour
{
    public static event Action<int> OnCardSelected;

    [SerializeField, Tooltip("Reference to the image component of the card")]
    private Image _cardWeaponImage;

    [SerializeField, Tooltip("Reference to the toggle button")]
    private Toggle _selectionToggle;



    // Game Loop Methods---------------------------------------------------------------------------

    private void OnEnable()
    {
        _selectionToggle.onValueChanged.AddListener(delegate 
        {
            SelectCard();
        });
    }

    // Member Methods------------------------------------------------------------------------------

    public void SelectCard()
    {
        OnCardSelected?.Invoke(CardIndex);
    }

    // Getters and Setters-------------------------------------------------------------------------

    public Sprite CardWeaponImageSprite { get => _cardWeaponImage.sprite; set => _cardWeaponImage.sprite = value; }
    public Toggle SelectionToggle { get => _selectionToggle; }

    public int CardIndex { get; set; }
}
