using _Project.Scripts.Configs;
using UnityEngine;

namespace _Project.Scripts.Canons.Factory
{
    public class BaseCanonFactory<T> where T : Canon
    {
        private T _prefab;
        private CanonConfig _canonConfig;
        private ProjectileConfig _projectileConfig;

        public BaseCanonFactory(T prefab, CanonConfig canonConfig, ProjectileConfig projectileConfig)
        {
            _prefab = prefab;
            _canonConfig = canonConfig;
            _projectileConfig = projectileConfig;
        }

        public T Create()
        {
            var result = GameObject.Instantiate(_prefab);

            result.transform.position = _canonConfig.SpawnPosition;

            var canonGun = result.GetComponentInChildren<CanonGun>();

            result.Init(_canonConfig, _projectileConfig, canonGun.GetComponent<Transform>());

            return result;
        }
    }
}