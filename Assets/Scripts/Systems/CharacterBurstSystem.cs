using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;
using static UserInputData;

public class CharacterBurstSystem : ComponentSystem
{

//private EntityQuery _burstQuery;
   // private InputActionMap inputMap;

    protected override void OnCreate()
    {
        //PlayerControls inputMap = new PlayerControls();
        //inputMap.UI.Burst.performed += Burst_performed;
        //_burstQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(), ComponentType.ReadOnly<BurstData>(), ComponentType.ReadOnly<Transform>());
       // _burstQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>());
    }

    //private void Burst_performed(InputAction.CallbackContext context)
    //{
    //    Entities.With(_burstQuery).ForEach(
    //        (Entity entity, ref InputData inputData) =>
    //        {
    //            var burstData = EntityManager.GetComponentData<BurstData>(entity);
    //            var moveData = EntityManager.GetComponentData<MoveData>(entity);

    //            moveData.Direction = Vector2.up * burstData.JumpImpulse;
    //            //moveData.Speed *= burstData.MaxSpeed;

    //            EntityManager.SetComponentData(entity, moveData);
    //            EntityManager.SetComponentData(entity, inputData);
    //        });
    //}

    protected override void OnUpdate()
    {
        //Entities.With(_burstQuery).ForEach(
        //(Entity entity, Transform transform, ref InputData inputData, ref BurstData burst) =>
        //{
        //    var pos = transform.position;

        //    pos += new Vector3(inputData.Move.x * burst.MaxSpeed, 0, inputData.Move.y * burst.MaxSpeed);
        //    var target = pos;
        //    target.y = 0;
        //    var lookRotation = Quaternion.LookRotation(target - transform.position);

        //    transform.rotation = lookRotation;
        //    transform.position = pos;
        //});
    }
}
