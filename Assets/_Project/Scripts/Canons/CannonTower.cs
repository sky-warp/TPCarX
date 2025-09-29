using _Project.Scripts.Monsters;
using UnityEngine;

namespace _Project.Scripts.Canons
{
    public class CannonTower : MonoBehaviour
    {
        [SerializeField] private float _shootInterval = 0.5f;
        [SerializeField] private float _range = 4f;
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private Transform _shootPoint;

        private float _lastShotTime;

        void Update()
        {
            if (_projectilePrefab == null || _shootPoint == null)
                return;

            foreach (var monster in FindObjectsOfType<Monster>())
            {
                if (Vector3.Distance(transform.position, monster.transform.position) > _range)
                    continue;

                if (_lastShotTime + _shootInterval > Time.time)
                    continue;

                // shot
                Instantiate(_projectilePrefab, _shootPoint.position, _shootPoint.rotation);

                _lastShotTime = Time.time;
            }
        }
    }
}