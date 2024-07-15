using Unity.Entities;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class UserInputData : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField] private float speed;
    [SerializeField] private float burstSpeed;


    public MonoBehaviour ShootAction;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new BurstData
        {
            JumpDelay = 2,
            MaxSpeed = burstSpeed,
            JumpImpulse = 100
        }) ;
        dstManager.AddComponentData(entity, new InputData());
        dstManager.AddComponentData(entity, new MoveData
        {
            Speed = speed / 100,
            Direction = Vector2.zero
        });

        dstManager.AddComponentData(entity, new VelocityData());

        if (ShootAction != null && ShootAction is IAbility)
        {
            dstManager.AddComponentData(entity, new ShootData());
        }
    }

    public struct InputData: IComponentData
    {
        public float2 Move;
        public float Shoot;
        public float2 Burst;
    }

    public struct MoveData: IComponentData
    {
        public float Speed;
        public float2 Direction;
    }

    public struct ShootData: IComponentData
    {

    }

    public struct BurstData: IComponentData
    {
        public float JumpDelay;
        public float MaxSpeed;
        public float JumpImpulse;
        
    }

    public struct VelocityData : IComponentData
    {
        public float2 Velocity;
    }
}
