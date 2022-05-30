using UnityEngine;

[System.Serializable]
public class SpawnData
{
    public Vector3 SpawnPoint;

    public Teams team;
}

public enum Teams
{
    Red,
    Blue,
    Green,
    Yellow
};
