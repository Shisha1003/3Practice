using DefaultNamespace;
using DefaultNamespace.Systems;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UIElements;



public class ReactionOnCollision : MonoBehaviour
{

    private List<MonoBehaviour> collisionActions = new List<MonoBehaviour>();
    private List<IAbilityTarget> collisionActionsAbilities = new List<IAbilityTarget>();
    private MonoBehaviour currentScript;

    private BulletManager _bulletManager;

    public List<IAbilityTarget> TypeOfObject(Collider _collider)
    {
        if (gameObject == null)
        {
            Debug.LogError("gameObject is null");
            return null;
        }

        switch (_collider)
        {
            case SphereCollider sphere:
                if (gameObject.GetComponent<CharacterTakeHealth>() == null)
                {
                    gameObject.AddComponent<CharacterTakeHealth>();
                }
                currentScript = gameObject.GetComponent<CharacterTakeHealth>();
                break;

            case BoxCollider box:
                if (gameObject.GetComponent<ApplyDamage>() == null)
                {
                    gameObject.AddComponent<ApplyDamage>();
                }
                currentScript = gameObject.GetComponent<ApplyDamage>();
                break;
            case CapsuleCollider capsule:
                
                _bulletManager.AddPrefabToScene();
                var _bulletPrefab = gameObject.GetComponent<BulletManager>();
                _bulletManager.EnableBulletBounce();
                _bulletManager.DeletePrefabFromScene(_bulletManager.bulletPrefab);
               // _shootAbility.Execute();
               //BulletManager _bulletManager = FindAnyObjectByType<BulletManager>();
               //var _bulletManager = gameObject.GetComponent<BulletManager>();
               //BulletManager bulletManager = BulletManager.Instance;
               //BulletManager.Instance.EnableBulletBounce();
               //_bulletManager.shouldAddBounceComponent = true;


                //if (bullet.GetComponent<BulletBounce>() == null)
                //{
                //    bullet.gameObject.AddComponent<BulletManager>();
                //}
                gameObject.SetActive(false);
                break;

        }
         collisionActions?.Add(currentScript);

        foreach (var action in collisionActions)
        {
            if (action is IAbilityTarget ability)
            {
                collisionActionsAbilities.Add(ability);
            }
        }

        return collisionActionsAbilities;
    }

}     





