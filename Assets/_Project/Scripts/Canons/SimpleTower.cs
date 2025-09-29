using _Project.Scripts.Monsters;
using _Project.Scripts.Projectiles;
using UnityEngine;

namespace _Project.Scripts.Canons
{
    public class SimpleTower : MonoBehaviour
    {
        public float m_shootInterval = 0.5f;
        public float m_range = 4f;
        public GameObject m_projectilePrefab;

        private float _lastShotTime;
        
        void Update()
        {
            if (m_projectilePrefab == null)
                return;

            foreach (var monster in FindObjectsOfType<Monster>())
            {
                
                if (Vector3.Distance(transform.position, monster.transform.position) > m_range)
                    continue;

                if (_lastShotTime + m_shootInterval > Time.time)
                    continue;

                // shot
                var projectile =
                    Instantiate(m_projectilePrefab, transform.position + Vector3.up * 1.5f,
                        Quaternion.identity) as GameObject;
                var projectileBeh = projectile.GetComponent<GuidedProjectile>();
                projectileBeh.m_target = monster.gameObject;

                _lastShotTime = Time.time;
            }
        }
    }
}