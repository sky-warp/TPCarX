using UnityEngine;

namespace _Project.Scripts.Monsters
{
    public class DefaultMonster : Monster
    {
        void Update()
        {
            if (m_moveTarget == null)
                return;

            if (Vector3.Distance(transform.position, m_moveTarget.transform.position) <= m_reachDistance)
            {
                Destroy(gameObject);
                return;
            }

            var translation = m_moveTarget.transform.position - transform.position;
            if (translation.magnitude > m_speed)
            {
                translation = translation.normalized * m_speed;
            }

            transform.Translate(translation);
        }
    }
}