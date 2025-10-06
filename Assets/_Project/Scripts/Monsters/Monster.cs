using _Project.Scripts.Projectiles.Interfaces;
using UnityEngine;

namespace _Project.Scripts.Monsters
{
    public abstract class Monster : MonoBehaviour, ITargetable
    {
        public GameObject m_moveTarget;
        public float m_speed = 0.1f;
        public int m_maxHP = 30;
        public const float m_reachDistance = 0.3f;
    }
}