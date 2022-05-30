using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New spawning data", menuName = "Static data/Unit/Spawning data")]
public sealed class UnitSpawningData : ScriptableObject
{
    [Header("Units settings")]
    public GameObject UnitPrefab;
    public int MaxUnitsInTeam;
    [Range(1, 4)] public int TeamCount;

    [Header("Spawn points")]
    public List<SpawnData> SpawningData;
    [Range(0f, 5f)] public float SpawnSpreading;
}
