using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBounce : MonoBehaviour, IAbility
{

    private int maxBounces = 3;
    private int currentBounces = 0;
    

    public void Execute()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (currentBounces < maxBounces)
        {
            Vector3 reflectDir = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
            float rotation = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rotation, 0);
            currentBounces++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
