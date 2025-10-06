using _Project.Scripts.Configs;
using UnityEngine;

namespace _Project.Scripts.Projectiles.Factory
{
    public class BaseProjectileFactory<T> where T : Projectile
    {
        private T _prefab;
        private Transform _parent;
        private ProjectileConfig _projectileConfig;

        public BaseProjectileFactory(T prefab, Transform parent, ProjectileConfig projectileConfig)
        {
            _prefab = prefab;
            _parent = parent;
            _projectileConfig = projectileConfig;
        }

        public T Create()
        {
            var result = GameObject.Instantiate(_prefab, _parent);
            result.Init(_projectileConfig);
            result.transform.position = _parent.position;
            
            return result;
        }
    }
}