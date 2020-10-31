using UnityEngine;

namespace Buriola.Gameplay.Player.Data
{
    [CreateAssetMenu(fileName = "New Player Data", menuName = "Data/Player Data/Base Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Movement")]
        public LayerMask CollisionMask;
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
        public float _wallSlideMaxSpeed = 3f;
        public float _wallStickTime = 0.25f;
        public Vector2 _wallJumpClimb = Vector2.zero;
        public Vector2 _wallJumpOff = Vector2.zero;
        public Vector2 _wallJumpLeap = Vector2.zero;
    }
}
