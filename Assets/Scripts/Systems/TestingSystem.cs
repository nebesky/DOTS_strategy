using Unity.Burst;
using Unity.Entities;
using UnityEngine;

partial struct TestingSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {

    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        int count = 0;

        foreach (RefRW<Zombie> friendly in SystemAPI.Query<RefRW<Zombie>>())
        {
            count++;
        }

        //Debug.Log("unit count "+ count);
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {

    }
}