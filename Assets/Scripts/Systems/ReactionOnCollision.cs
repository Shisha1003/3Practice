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


    ShootAbility shootAbil;

    private void Start()
    {
        shootAbil = FindObjectOfType<ShootAbility>();
    }
    public List<IAbilityTarget> TypeOfObject(Collider _collider)
    {
        if (gameObject == null)
        {
            Debug.LogError("gameObject is null");
            return null;
        }
        collisionActions.Clear();
        collisionActionsAbilities.Clear();

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

                shootAbil.isBulletBounce = true;
                gameObject.SetActive(false);
                break;

        }
        if (currentScript != null)
        {
            collisionActions?.Add(currentScript);
        }
         

        foreach (var action in collisionActions)
        {
            if (action is IAbilityTarget ability)
            {
                collisionActionsAbilities?.Add(ability);
            }
        }

        return collisionActionsAbilities;
    }

}     





