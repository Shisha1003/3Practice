using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using Unity.Entities;
using DefaultNamespace;
using Unity.VisualScripting;



public class CollisionAbility : MonoBehaviour, IConvertGameObjectToEntity, IAbility
    {

    public Collider Collider;

    [HideInInspector] public List<Collider> collisions;

    private ReactionOnCollision react;


    private void Start()
    {
        react = GetComponent<ReactionOnCollision>();
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        float3 position = gameObject.transform.position;
        Utils.Convert(Collider, entity, dstManager, conversionSystem, position);
        
    }

        public void Execute()
        {
        List<IAbilityTarget> collisionActionsAbilities = react.TypeOfObject(Collider);
        foreach (var action in collisionActionsAbilities)
            {
                action.Targets = new List<GameObject>();
                collisions.ForEach(c =>
                {
                    if (c != null && gameObject.activeInHierarchy) action.Targets.Add(c.gameObject); //приемлемо ли так писать?
                });
                    action.Execute();
            }
        }

        public struct ActorColliderData : IComponentData
        {
            public ColliderType ColliderType;

            public float3 SphereCenter;
            public float SphereRadius;

            public float3 CapsuleStart;
            public float3 CapsuleEnd;
            public float CapsuleRadius;

            public float3 BoxCenter;
            public float3 BoxHalfExtents;
            public quaternion BoxOrientation;
            public bool initialTakeOff;
        }

        public enum ColliderType
        {
            Sphere = 0,
            Capsule = 1,
            Box = 2
        }
    }

