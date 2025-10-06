using System.Collections;
using _Project.Scripts.Configs;
using _Project.Scripts.Monsters;
using _Project.Scripts.Projectiles;
using _Project.Scripts.Projectiles.Factory;
using UnityEngine;

namespace _Project.Scripts.Canons
{
    public abstract class Canon : MonoBehaviour
    {
        public BaseProjectileFactory<Projectile> ProjectileFactory;
        public Monster TargetMonster { get; private set; }
        public float AttackRange { get; private set; }
        public float ShootingInterval { get; private set; }

        private bool _isEnable = true;
        private float _canonHeat;

        public void Init(CanonConfig config, ProjectileConfig projectileConfig, Transform projectileParent)
        {
            ShootingInterval = config.ShootInterval;
            AttackRange = config.Range;

            ProjectileFactory = new(config.ProjectilePrefab, projectileParent, projectileConfig);
        }

        public abstract void Shoot();
        
        public abstract bool CalculateRange(Monster monster);

        public void SetTarget(Monster monster)
        {
            TargetMonster = monster;
        }

        private void Update()
        {
            if (_canonHeat > 0)
            {
                _canonHeat -= Time.deltaTime;
            }
        }
        
        protected IEnumerator DetectMonster()
        {
            while (_isEnable)
            {
                Collider[] targets = Physics.OverlapSphere(transform.position, AttackRange);

                foreach (Collider target in targets)
                {
                    if (target.TryGetComponent(out Monster monster))
                    {
                        if (_canonHeat <= 0)
                        {
                            if (CalculateRange(monster))
                            {
                                SetTarget(monster);

                                _canonHeat = ShootingInterval;
                                Shoot();
                            }
                        }
                    }
                }

                yield return null;
            }
        }

        private void OnDestroy()
        {
            _isEnable = false;
        }
    }
}