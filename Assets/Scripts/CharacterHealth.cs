using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public Settings settings;

    public int Health;


    public ShootAbility shootAbility;

    private void Start()
    {
        Health = settings.HeroHealth;
    }
    public void AddHealth(int amount)
    {
        Health += amount;
        WriteStats();
    }

    private void WriteStats()
    {

        var jsonString = JsonUtility.ToJson(shootAbility.playerStats);
        Debug.Log(jsonString);
        PlayerPrefs.SetString("Stats", jsonString);
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        WriteStats();
        if (Health <= 0)
        {
            Health = 0;
        }

    }
}
