using UnityEngine;
// 아이템 정보 스크립트 
[System.Serializable]
public struct ItemSpawnData
{
    //public string ItemName;
    public GameObject Prefab;
    public float SpawnWeight;
}