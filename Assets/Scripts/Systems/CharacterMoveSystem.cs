using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using static UserInputData;

public class CharacterMoveSystem : ComponentSystem
{

    private EntityQuery _moveQuery;
    private EntityQuery _burstQuery;

    protected override void OnCreate()
    {

        PlayerControls playerCont = new PlayerControls();
        _moveQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(), ComponentType.ReadOnly<MoveData>(), ComponentType.ReadOnly<Transform>());
        _burstQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(), ComponentType.ReadOnly<BurstData>(), ComponentType.ReadOnly<Transform>());

    }


    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.With(_moveQuery).ForEach((Entity entity, Transform transform, ref InputData inputData, ref MoveData move, ref VelocityData velocityData) =>
        {
            var pos = transform.position;

            var moveDirection = new Vector3(inputData.Move.x * move.Speed, 0, inputData.Move.y * move.Speed);
            pos += moveDirection;

            var velocityDirection = new Vector3(velocityData.Velocity.x, 0, velocityData.Velocity.y) * deltaTime; //уточнить как работают между собой pos
            pos += velocityDirection;

            var target = pos;
            target.y = transform.position.y; 
            if (moveDirection != Vector3.zero || velocityDirection != Vector3.zero)
            {
                var lookRotation = Quaternion.LookRotation(target - transform.position);
                transform.rotation = lookRotation;
            }

            transform.position = pos;

            velocityData.Velocity *= 0.9f; 

        });

        Entities.With(_burstQuery).ForEach((Entity entity, Transform transform, ref InputData inputData, ref BurstData burstData, ref VelocityData velocityData) =>
        {
            if (inputData.Burst.x != 0)
            {
                var forward = transform.forward;
                velocityData.Velocity = new float2(forward.x, forward.z) * burstData.MaxSpeed;
            }
        });
    }
}
