using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System.Runtime.CompilerServices;

public class DogMovement : ComponentSystem
{
    private EntityQuery _query;
    protected override void OnUpdate()
    {
        Entities.With(_query).ForEach((Entity entity, Transform transform, DogMoveComponent dogMove) =>
        {
            var p = transform.position;
            p.y += dogMove.moveSpeed / 1000;
            transform.position = p;
        });
         
    }

    protected override void OnCreate()
    {
        _query = GetEntityQuery(ComponentType.ReadOnly<DogMoveComponent>());
    }
}
