using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class BehaviourManager : MonoBehaviour, IConvertGameObjectToEntity
{
    public List<MonoBehaviour> behaviours;
    public IBehaviour activeBehaviour;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponent<AIAgent>(entity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public struct AIAgent : IComponentData
    {

    }
}
