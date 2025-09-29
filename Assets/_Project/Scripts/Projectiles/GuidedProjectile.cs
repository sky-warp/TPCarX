using System.Collections;
using _Project.Scripts.Configs;
using _Project.Scripts.Monsters;
using UnityEngine;

namespace _Project.Scripts.Projectiles
{
	public class GuidedProjectile : Projectile 
	{
		public GameObject m_target;
		/*public float m_speed = 0.2f;
		public int m_damage = 10;*/

		public GuidedProjectile(ProjectileConfig config) : base(config)
		{
		}

		void Update()
		{
			if (m_target == null)
			{
				Destroy(gameObject);
				return;
			}

			var translation = m_target.transform.position - transform.position;
			if (translation.magnitude > Speed)
			{
				translation = translation.normalized * Speed;
			}

			transform.Translate(translation);
		}

		void OnTriggerEnter(Collider other)
		{
			var monster = other.gameObject.GetComponent<Monster>();
			if (monster == null)
				return;

			monster.m_maxHP -= Damage;
			if (monster.m_maxHP <= 0)
			{
				Destroy(monster.gameObject);
			}

			Destroy(gameObject);
		}

		public override IEnumerator MoveTowardsTarget()
		{
			throw new System.NotImplementedException();
		}
	}
}