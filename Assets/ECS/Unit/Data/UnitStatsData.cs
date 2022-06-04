using UnityEngine;

[CreateAssetMenu(fileName = "New unit stats data", menuName = "Static data/Unit/Stats data")]
public sealed class UnitStatsData : ScriptableObject
{
    [SerializeField][Range(1, 60)] int _speed;
    [SerializeField][Range(1, 60)] int _damage;
    public int Speed => _speed;
    public int Damage => _damage;

    [SerializeField][Range(1, 1000)] int _healthPoints;
    [SerializeField][Range(1, 1000)] int _maxHealthPoints;
    public int HP => _healthPoints;
    public int MaxHP => _maxHealthPoints;

    [SerializeField][Range(1, 1000)] int _bounceForce;
    public int BounceForce => _bounceForce;

    [SerializeField][Range(2, 120)] int _maxCompressionFrames;
    [SerializeField][Range(0f, 0.2f)] float _compressionDeltaScale;
    public int MaxCompressionFrames => _maxCompressionFrames;
    public float CompressionDeltaScale => _compressionDeltaScale;
}
