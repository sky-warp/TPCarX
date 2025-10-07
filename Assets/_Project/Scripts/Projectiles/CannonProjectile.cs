using _Project.Scripts.Monsters;
using _Project.Scripts.Projectiles.Interfaces;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Projectiles
{
    public class CannonProjectile : Projectile
    {
        [SerializeField] private int _damage = 10;

        void OnTriggerEnter(Collider other)
        {
            //Monster model to decrease monsters health?
            //Some damage controller?
            if (other.gameObject.TryGetComponent<DefaultMonster>(out DefaultMonster monster))
            {
                monster.m_maxHP -= _damage;

                if (monster.m_maxHP <= 0)
                {
                    Destroy(monster.gameObject);
                }
            }
        }

        public override IReadOnlyReactiveProperty<Vector3> DirectionTowardsTarget { get; }

        public override void CalculateDirectionTowardsTarget(ITargetable target)
        {
        }
    }
}