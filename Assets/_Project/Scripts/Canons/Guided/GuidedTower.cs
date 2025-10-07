using System;
using _Project.Scripts.Monsters;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Canons.Guided
{
    public class GuidedTower : Canon, IDisposable
    {
        private CompositeDisposable _disposables = new();

        private void Awake()
        {
            StartCoroutine(DetectMonster());
        }

        public override void Shoot()
        {
            var projectile = ProjectileFactory.Create();

            projectile.CalculateDirectionTowardsTarget(TargetMonster);

            Observable
                .EveryUpdate()
                .Where(_ => projectile != null)
                .Subscribe(_ =>
                {
                    projectile.transform.position =
                        Vector3.MoveTowards(projectile.transform.position, projectile.DirectionTowardsTarget.Value,
                            projectile.Speed * Time.deltaTime);
                })
                .AddTo(_disposables);
        }

        public override bool CalculateRange(Monster monster)
        {
            return Vector3.Distance(transform.position, monster.transform.position) < AttackRange;
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }
    }
}