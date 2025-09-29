using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "CanonConfig", menuName = "Canon Config")]
    public class CanonConfig : ScriptableObject
    {
        [field: SerializeField] public float ShootInterval { get; private set; }
        [field: SerializeField] public float Range { get; private set; }
    }
}