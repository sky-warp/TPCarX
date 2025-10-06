using _Project.Scripts.Monsters;
using UnityEngine;

namespace _Project.Scripts.Canons.Guided
{
    public class GuidedTower : Canon
    {
        private void Awake()
        {
            StartCoroutine(DetectMonster());
        }

        public override void Shoot()
        {
            var projectile = ProjectileFactory.Create();

            projectile.MoveTowardsMonster(TargetMonster);
        }

        public override bool CalculateRange(Monster monster)
        {
            return Vector3.Distance(transform.position, monster.transform.position) < AttackRange;
        }
    }
}