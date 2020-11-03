using UnityEngine;

namespace Buriola.Gameplay.Player.Data
{
    [CreateAssetMenu(fileName = "New Player Data", menuName = "Data/Player Data/Base Data")]
    public sealed class PlayerData : ScriptableObject
    {
        [Header("Movement")]
        public LayerMask GroundCollisionMask;
        public float GroundCheckRadius = 1f;
        public float MoveSpeed = 4f;
        public float CrouchedMoveSpeed = 8f;
        public float AccelerationTimeGrounded = 0.1f;
        public float MaxClimbAngle = 80f;
        public float MaxDescendAngle = 75f;

        [Header("Sliding")]
        public float SlideDistance = 5f;
        public float SlideSpeed = 5f;
        public float SlideAcceleration = 0.2f;
        public float SlideCooldown = 0.5f;

        [Header("Collider Settings")] 
        public float CollisionAboveCheckDistance = 0.8f;
        public Vector2 NormalColliderSize = Vector2.zero;
        public Vector2 NormalColliderOffset = Vector2.zero;
        public Vector2 CrouchedColliderSize = Vector2.zero;
        public Vector2 CrouchedColliderOffset = Vector2.zero;
        public Vector2 SlidingColliderSize = Vector2.zero;
        public Vector2 SlidingColliderOffset = Vector2.zero;
        
        [Header("Air & Jump")]
        public float AccelerationTimeAirborne = 0.2f;
        public float MaxJumpHeight = 8f;
        public float MinJumpHeight = 1f;
        public float TimeToJumpApex = 0.4f;
        public int JumpAmount = 1;
        
        [Header("Wall Slide")]
        public LayerMask WallCollisionMask;
        public float WallDistanceCheck = 0.5f;
        public float WallSlideMaxSpeed = 3f;
        public float WallStickTime = 0.25f;
        public Vector2 WallJumpClimb = Vector2.zero;
        public Vector2 WallJumpOff = Vector2.zero;
        public Vector2 WallJumpLeap = Vector2.zero;

        [Header("Ledge Movement")] 
        public LayerMask LedgeCollisionMask;
        public float LedgeDistanceCheck = 0.5f;
        public Vector2 LedgeJumpClimb = Vector2.zero;
        public Vector2 StartOffset = Vector2.zero;

        [Header("Combat Settings")]
        public float InputBufferTime = 0.5f;
        public LayerMask DamageableMask = default;
        [Header("Sword Attacks")]
        public AttackData SwordAttack1;
        public AttackData SwordAttack2;
        public AttackData SwordAttack3;
        [Header("Sword Air Attacks")]
        public AttackData SwordAirAttack1;
        public AttackData SwordAirAttack2;
        public AttackData SwordAirAttack3;
        [Header("Hand Combat Attacks")]
        public AttackData PunchAttack1;
        public AttackData PunchAttack2;
        public AttackData PunchAttack3;
        public AttackData KickAttack1;
        public AttackData KickAttack2;
    }
}
