using UnityEngine;

[System.Serializable]
public class SpawnData
{
    [SerializeField] Vector3 _spawnPoint;
    public Vector3 SpawnPoint => _spawnPoint;

    [SerializeField] Teams _team;
    public Teams Team => _team;
}