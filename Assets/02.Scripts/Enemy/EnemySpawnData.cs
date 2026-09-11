using UnityEngine;
// 순수하게 데이터를 보관하기 위한 스크립트 
[System.Serializable]
public struct EnemySpawnData
{
    //public string EnemyName;
    public GameObject Prefab;
    public float SpawnWeight;
}