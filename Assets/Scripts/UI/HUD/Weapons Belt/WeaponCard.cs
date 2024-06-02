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

    [SerializeField, Tooltip("Reference to the card outline")]
    private Outline _cardOutline;



    // Game Loop Methods---------------------------------------------------------------------------

    private void OnEnable()
    {
        _selectionToggle.onValueChanged.AddListener(delegate 
        {
            SelectCard();

            // Outline the selected card and disable all other cards
            if (_selectionToggle.isOn)
            {
                CardOutline.enabled = true;
            }
            else
            {
                CardOutline.enabled = false;
            }
        });
    }

    // Member Methods------------------------------------------------------------------------------

    /// <summary>
    /// Select the card and invoke the signal for the get selected weapon to change it
    /// </summary>
    public void SelectCard()
    {
        OnCardSelected?.Invoke(CardIndex);
    }

    // Getters and Setters-------------------------------------------------------------------------

    public Sprite CardWeaponImageSprite { get => _cardWeaponImage.sprite; set => _cardWeaponImage.sprite = value; }
    public Toggle SelectionToggle { get => _selectionToggle; }

    public int CardIndex { get; set; }
    public Outline CardOutline { get => _cardOutline; private set => _cardOutline = value; }
}
