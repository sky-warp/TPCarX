using _Project.Scripts.Monsters;
using UnityEngine;

namespace _Project.Scripts.Projectiles
{
    public class CannonProjectile : MonoBehaviour
    {
        [SerializeField] private float _speed = 0.2f;
        [SerializeField] private int _damage = 10;

        void Update()
        {
            var translation = transform.forward * _speed;
            transform.Translate(translation);
        }

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
    }
}