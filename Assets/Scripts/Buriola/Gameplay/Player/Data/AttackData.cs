using UnityEngine;

namespace Buriola.Gameplay.Player.Data
{
    [System.Serializable]
    public class AttackData
    {
        public float Damage = 1f;
        public float AttackRadius = 1f;
        public Vector2 AttackCenterPoint = Vector2.zero;
        public Vector2 KnockbackForce = Vector2.zero;
        public bool ApplyKnockback = false;
    }
}
