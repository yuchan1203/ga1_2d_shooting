using UnityEngine;
[System.Serializable]
public struct EnemySpawnData
{
    [SerializeField] public GameObject Prefab;
    [SerializeField] public float SpawnWeight;
}