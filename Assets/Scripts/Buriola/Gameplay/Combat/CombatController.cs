using Buriola.Gameplay.Player;
using Buriola.Gameplay.Player.Data;
using UnityEngine;

namespace Buriola.Gameplay.Combat
{
    public class CombatController
    {
        private PlayerController2D _playerController;
        private PlayerData _playerData;
        private bool _invencible;

        private BaseAttack _swordAttack1;
        private BaseAttack _swordAttack2;
        private BaseAttack _swordAttack3;
        
        public void Initialize(PlayerController2D player, PlayerData playerData)
        {
            _playerController = player;
            _playerData = playerData;
            _invencible = false;
            
            CreateAttacks();
        }

        public void SwordAttack(int attackId)
        {
            BaseAttack attack = GetSwordAttackById(attackId);
            CheckAttack(attack);
        }
        
        private void CreateAttacks()
        {
            _swordAttack1 = new BaseAttack(_playerData.SwordAttack1.Damage, _playerData.SwordAttack1.AttackRadius, _playerData.SwordAttack1.AttackCenterPoint, 
                _playerData.SwordAttack1.KnockbackForce, _playerData.SwordAttack1.ApplyKnockback);
            
            _swordAttack2 = new BaseAttack(_playerData.SwordAttack2.Damage, _playerData.SwordAttack2.AttackRadius, _playerData.SwordAttack2.AttackCenterPoint, 
                _playerData.SwordAttack2.KnockbackForce, _playerData.SwordAttack2.ApplyKnockback);
        
            _swordAttack3 = new BaseAttack(_playerData.SwordAttack3.Damage, _playerData.SwordAttack3.AttackRadius, _playerData.SwordAttack3.AttackCenterPoint, 
                _playerData.SwordAttack3.KnockbackForce, _playerData.SwordAttack3.ApplyKnockback);
        }
        
        private void CheckAttack(BaseAttack attack)
        {
            if (attack == null) return;

            Vector2 attackCenter = attack.AttackCenterPoint;
            attackCenter.x *= _playerController.DirectionX;
            
            Vector2 direction = (Vector2) _playerController.transform.position + attackCenter;

            Collider2D[] hits = Physics2D.OverlapCircleAll(direction, attack.AttackRadius, _playerData.DamageableMask);

            if (hits.Length > 0)
            {
                foreach (Collider2D enemy in hits)
                {
                    if (enemy.gameObject.TryGetComponent(out IDamageable damageable))
                    {
                        damageable.TakeDamage(attack);
                    }
                }
            }
        }

        private BaseAttack GetSwordAttackById(int attackId)
        {
            switch (attackId)
            {
                case 0:
                    return _swordAttack1;
                case 1:
                    return _swordAttack2;
                case 2:
                    return _swordAttack3;
                default:
                    return null;
            }
        }

        public void SetInvencibility(bool value)
        {
            _invencible = value;
        }
    }
}
