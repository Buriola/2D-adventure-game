using UnityEngine;

namespace Buriola.Gameplay.Player.Data
{
    [CreateAssetMenu(fileName = "New Player Data", menuName = "Data/Player Data/Base Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Movement")]
        public LayerMask GroundCollisionMask;
        public float GroundCheckRadius = 1f;
        public float MoveSpeed = 4f; 
        public float AccelerationTimeGrounded = 0.1f;
        public float MaxClimbAngle = 80f;
        public float MaxDescendAngle = 75f;
        
        [Header("Air & Jump")]
        public float AccelerationTimeAirborne = 0.2f;
        public float MaxJumpHeight = 8f;
        public float MinJumpHeight = 1f;
        public float TimeToJumpApex = 0.4f;
        public int JumpAmount = 1;
        public float JumpCooldown = 0.5f;
        
        [Header("Wall Slide")]
        public LayerMask WallCollisionMask;
        public float WallDistanceCheck = 0.5f;
        public float WallSlideMaxSpeed = 3f;
        public float WallStickTime = 0.25f;
        public Vector2 WallJumpClimb = Vector2.zero;
        public Vector2 WallJumpOff = Vector2.zero;
        public Vector2 WallJumpLeap = Vector2.zero;
    }
}
