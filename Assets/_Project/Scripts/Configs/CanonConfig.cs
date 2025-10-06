using _Project.Scripts.Projectiles;
using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "CanonConfig", menuName = "Canon Config")]
    public class CanonConfig : ScriptableObject
    {
        [field: SerializeField] public Vector3 SpawnPosition { get; private set; }
        [field: SerializeField] public Projectile ProjectilePrefab  { get; private set; }
        [field: SerializeField] public float ShootInterval { get; private set; }
        [field: SerializeField] public float Range { get; private set; }
    }
}