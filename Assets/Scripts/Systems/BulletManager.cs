using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance { get; private set; }
    public GameObject bulletPrefab; // Префаб пули
    public bool shouldAddBounceComponent;
    public float lifetime = 3f;
    public MonoBehaviour BounceAbility;

    private void Start()
    {
        Destroy(gameObject, lifetime);
        BounceAbility.enabled = false;
    }

    public void EnableBulletBounce()
    {
       BounceAbility.enabled = true;
    }

    public void AddPrefabToScene()
    {
        GameObject bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);

    }

    public void DeletePrefabFromScene(GameObject bullet)
    {
        Destroy(bullet);
    }

    
}
