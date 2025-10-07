using _Project.Scripts.Configs;
using _Project.Scripts.Projectiles.Interfaces;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        public abstract IReadOnlyReactiveProperty<Vector3> DirectionTowardsTarget { get; }
        public float Speed { get; private set; }
        public int Damage { get; private set; }
        public Vector3 Destination { get; private set; }

        public void Init(ProjectileConfig config)
        {
            Speed = config.Speed;
            Damage = config.Damage;
        }

        public abstract void CalculateDirectionTowardsTarget(ITargetable target);
    }
}