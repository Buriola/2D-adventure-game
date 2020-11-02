using UnityEngine;

namespace Buriola.Gameplay.Combat
{
    public class BaseAttack
    {
        public float Damage { get; private set; }
        public float AttackRadius { get; private set; }
        public Vector2 AttackCenterPoint { get; private set; }
        public Vector2 KnockbackForce { get; private set; }
        public bool ApplyKnockback { get; private set; }

        public BaseAttack(float damage, float attackRadius, Vector2 attackCenterPoint, Vector2 knockbackForce, bool applyKnockback = false)
        {
            Damage = damage;
            AttackRadius = attackRadius;
            AttackCenterPoint = attackCenterPoint;
            KnockbackForce = knockbackForce;
            ApplyKnockback = applyKnockback;
        }
    }
}