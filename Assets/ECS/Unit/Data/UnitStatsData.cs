using UnityEngine;

[CreateAssetMenu(fileName = "New unit stats data", menuName = "Static data/Unit/Stats data")]
public sealed class UnitStatsData : ScriptableObject
{
    public int Speed;
    public int Damage;

    public int HealthPoints;
    public int MaxHealthPoints;
}
