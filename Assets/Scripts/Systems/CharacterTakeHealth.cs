using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTakeHealth : MonoBehaviour, IAbilityTarget
{
    public int healthAmount = 20;

    public List<GameObject> Targets {get; set;}

    public void Execute()
    {
        foreach (var target in Targets)
        {
            var healthComponent = target.GetComponent<CharacterHealth>(); 
            if (healthComponent != null)
            {
                healthComponent.AddHealth(healthAmount);
                gameObject.SetActive(false);
            }
        }
    }
}
