using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootAbility : MonoBehaviour, IAbility
{
    public GameObject bullet;
    public float bulletSpeed;
    public float shootDelay;
    public float bulletLifetime = 3f;
    private float _shootTime = float.MinValue;

    public bool isBulletBounce;
    public void Execute()
    {
        if (Time.time < _shootTime + shootDelay)
        {
            return;
        }
        else
        {
            _shootTime = Time.time;
        }

        if (bullet != null)
        {
            var t = transform;
            var newBullet = Instantiate(bullet, t.position, t.rotation);
            if (isBulletBounce)
            {
            newBullet.AddComponent<BulletBounce>();
            }

            var bulletComponent = newBullet.GetComponent<BulletManager>();
    

            if (bulletComponent != null)
            {
                bulletComponent.lifetime = bulletLifetime;
            }
            else
            {
                bulletComponent = newBullet.AddComponent<BulletManager>();
                bulletComponent.lifetime = bulletLifetime;
            }

            newBullet.GetComponent<Rigidbody>().AddForce(t.forward * bulletSpeed);
        }
        else
        {
            Debug.Log("[SHOOT ABILITY] No prefab Link");
        }
    }
}
