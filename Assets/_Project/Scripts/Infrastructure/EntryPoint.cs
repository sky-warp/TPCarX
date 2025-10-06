using _Project.Scripts.Canons;
using _Project.Scripts.Canons.Factory;
using _Project.Scripts.Configs;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private CanonConfig _guidedTowerConf;
        [SerializeField] private ProjectileConfig _guidedProjectileConfig;

        [SerializeField] private Canon _guidedCanonPrefab;

        private BaseCanonFactory<Canon> _guidedCanonFactory;
        
        private void Start()
        {
            _guidedCanonFactory = new(_guidedCanonPrefab, _guidedTowerConf, _guidedProjectileConfig);
            var guided = _guidedCanonFactory.Create();
        }
    }
}