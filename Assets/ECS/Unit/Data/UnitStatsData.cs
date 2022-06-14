using UnityEngine;

[CreateAssetMenu(fileName = "New unit stats data", menuName = "Static data/Unit/Stats data")]
public sealed class UnitStatsData : ScriptableObject
{
    [SerializeField][Range(1, 60)] int _speed;
    public int Speed => _speed;

    [SerializeField][Range(1, 60)] int _damage;
    [SerializeField][Range(0.0001f, 5f)] float _attackTime;
    public int Damage => _damage;
    public float AttackTime => _attackTime;

    [SerializeField][Range(1, 1000)] int _healthPoints;
    [SerializeField][Range(1, 1000)] int _maxHealthPoints;
    public int HP => _healthPoints;
    public int MaxHP => _maxHealthPoints;

    [SerializeField][Range(1, 1000)] int _bounceForce;
    public int BounceForce => _bounceForce;

    [SerializeField][Range(0f, 2f)] float _compressionTime;
    [SerializeField][Range(0f, 0.5f)] float _compressionDeltaScale;
    public float CompressionTime => _compressionTime;
    public float CompressionDeltaScale => _compressionDeltaScale;
}
