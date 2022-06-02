using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New spawning data", menuName = "Static data/Unit/Spawning data")]
public sealed class UnitSpawningData : ScriptableObject
{
    [Header("Units settings")]
    [SerializeField] GameObject _unitPrefab;
    public GameObject UnitPrefab => _unitPrefab;

    [SerializeField][Range(1, 20)] int _maxUnitsInTeam; 
    [SerializeField][Range(1, 4)] int _teamsCount;
    public int MaxUnitsInTeam => _maxUnitsInTeam;
    public int TeamsCount => _teamsCount;

    [Header("Spawn points")]
    [SerializeField] GameObject _teamParent;
    [SerializeField] GameObject _unitsParent;
    [SerializeField] List<SpawnData> _spawningData;
    [SerializeField][Range(0f, 7.5f)] float _spawnSpreading;
    public GameObject TeamParent => _teamParent;
    public GameObject UnitsParent => _unitsParent;
    public List<SpawnData> SpawningData => _spawningData;
    public float SpawnSpreading => _spawnSpreading;
}
