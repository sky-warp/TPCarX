using System.Collections;
using _Project.Scripts.Configs;
using UnityEngine;

namespace _Project.Scripts.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        public float Speed { get; private set; }
        public int Damage { get; private set; }

        public Projectile(ProjectileConfig config)
        {
            Speed = config.Speed;
            Damage = config.Damage;
        }

        public abstract IEnumerator MoveTowardsTarget();
    }
}