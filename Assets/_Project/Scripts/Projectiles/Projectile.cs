using _Project.Scripts.Configs;
using _Project.Scripts.Projectiles.Interfaces;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        public float Speed { get; private set; }
        public int Damage { get; private set; }
        public Vector3 Destination { get; private set; }

        public void Init(ProjectileConfig config)
        {
            Speed = config.Speed;
            Damage = config.Damage;
        }

        public abstract void MoveTowardsMonster(ITargetable target);

        public void SetDestination(Vector3 destination)
        {
            Destination = destination;
        }

        public void CheckDestinationAchivedStatus()
        {
            if(transform.position == Destination)
                Destroy(this);
            
            /*Observable
                .EveryUpdate()
                .Where(_ => this != null && transform.position == Destination)
                .Subscribe(_ => Destroy(this));*/
        }
    }
}