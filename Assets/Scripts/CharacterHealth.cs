using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int Health = 100;

    public void AddHealth(int amount)
    {
        Health += amount;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Health = 0;
        }

    }
}
