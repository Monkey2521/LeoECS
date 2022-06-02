using UnityEngine;

[CreateAssetMenu(fileName = "New unit stats data", menuName = "Static data/Unit/Stats data")]
public sealed class UnitStatsData : ScriptableObject
{
    [SerializeField] int _speed;
    [SerializeField] int _damage;
    public int Speed => _speed;
    public int Damage => _damage;

    [SerializeField] int _healthPoints;
    [SerializeField] int _maxHealthPoints;
    public int HP => _healthPoints;
    public int MaxHP => _maxHealthPoints;

    [SerializeField] int _bounceForce;
    public int BounceForce => _bounceForce;
}
