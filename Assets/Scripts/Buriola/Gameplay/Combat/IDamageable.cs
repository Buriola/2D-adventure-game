namespace Buriola.Gameplay.Combat
{
    public interface IDamageable
    {
        void TakeDamage(BaseAttack attack);
        void TakeDamage(float damage);
    }
}
