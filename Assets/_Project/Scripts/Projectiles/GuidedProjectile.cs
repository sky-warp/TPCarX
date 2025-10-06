using _Project.Scripts.Monsters;
using _Project.Scripts.Projectiles.Interfaces;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Projectiles
{
    public class GuidedProjectile : Projectile
    {
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

        public override void MoveTowardsMonster(ITargetable target)
        {
            Vector3 direction = Vector3.zero;

            Observable
                .EveryUpdate()
                .Where(_ => this != null)
                .Subscribe(_ =>
                {
                    var lastTargetPos = direction;

                    if ((MonoBehaviour)target != null && target is MonoBehaviour targetMono)
                    {
                        direction.x = targetMono.transform.position.x;
                        direction.y = targetMono.transform.position.y;
                        direction.z = targetMono.transform.position.z;

                        SetDestination(direction);

                        transform.position = Vector3.MoveTowards(transform.position, direction,
                            Speed * Time.deltaTime);

                        CheckDestinationAchivedStatus();
                    }

                    if ((MonoBehaviour)target == null)
                    {
                        SetDestination(lastTargetPos);

                        transform.position =
                            Vector3.MoveTowards(transform.position, lastTargetPos,
                                Speed * Time.deltaTime);

                        CheckDestinationAchivedStatus();
                    }
                });
        }
    }
}