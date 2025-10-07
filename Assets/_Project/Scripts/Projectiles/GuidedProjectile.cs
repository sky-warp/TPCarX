using System;
using _Project.Scripts.Monsters;
using _Project.Scripts.Projectiles.Interfaces;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Projectiles
{
    public class GuidedProjectile : Projectile, IDisposable
    {
        public override IReadOnlyReactiveProperty<Vector3> DirectionTowardsTarget => _directionTowardsTarget;

        private ReactiveProperty<Vector3> _directionTowardsTarget = new();

        private CompositeDisposable _disposables = new();

        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Monster monster))
            {
                if (monster == null)
                    return;

                //Some controller?
                monster.m_maxHP -= Damage;

                if (monster.m_maxHP <= 0)
                {
                    Destroy(monster.gameObject);
                }
            }
        }

        public override void CalculateDirectionTowardsTarget(ITargetable target)
        {
            Vector3 direction = Vector3.zero;

            Observable
                .EveryUpdate()
                .Where(_ => this != null)
                .Subscribe(_ =>
                {
                    if ((MonoBehaviour)target != null && target is MonoBehaviour targetMono)
                    {
                        direction.x = targetMono.transform.position.x;
                        direction.y = targetMono.transform.position.y;
                        direction.z = targetMono.transform.position.z;

                        _directionTowardsTarget.Value = direction;
                    }

                    if ((MonoBehaviour)target == null)
                    {
                        //Improve?
                        Destroy(gameObject);
                    }
                });
        }

        public void Dispose()
        {
            _directionTowardsTarget?.Dispose();
            _disposables?.Dispose();
        }
    }
}