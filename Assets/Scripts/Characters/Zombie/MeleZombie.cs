using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleZombie : MonoBehaviour, ITakeDamage
{
    public void TakeDamage()
    {
        Debug.Log("OOOh Nooo!!!");
    }
}
