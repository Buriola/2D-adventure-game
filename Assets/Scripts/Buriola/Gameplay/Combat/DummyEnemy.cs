using Buriola.Gameplay.Player;
using UnityEngine;

namespace Buriola.Gameplay.Combat
{
    public class DummyEnemy : MonoBehaviour, IDamageable
    {
        private PlayerController2D _player;

        private void Start()
        {
            _player = FindObjectOfType<PlayerController2D>();
        }

        public void TakeDamage(BaseAttack attack)
        {
            if (attack.ApplyKnockback)
            {
                Vector2 force = new Vector2(attack.KnockbackForce.x * _player.DirectionX, attack.KnockbackForce.y);
                GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
            }
        }

        public void TakeDamage(float damage)
        {
            throw new System.NotImplementedException();
        }
    }
}