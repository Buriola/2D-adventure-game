using UnityEngine;

namespace Buriola._2D_Physics
{
    public sealed class CollisionInfo2D
    {
        private bool _above;
        private bool _below;
        private bool _left;
        private bool _right;
        public bool IsClimbingSlope { get; set; }
        public bool IsDescendingSlope { get; set; }
        public bool IsGrounded => _below;
        public float CurrentSlopeAngle { get; set; }
        public float PreviousSlopeAngle { get; private set; }
        public Vector2 PreviousVelocity { get; set; }
        
        public void Reset()
        {
            _above = _below = false;
            _left = _right = false;
            IsClimbingSlope = false;
            IsDescendingSlope = false;
            PreviousSlopeAngle = CurrentSlopeAngle;
            CurrentSlopeAngle = 0f;
        }
        
        public void SetVerticalCollisions(bool above, bool below)
        {
            _above = above;
            _below = below;
        }

        public void SetHorizontalCollisions(bool left, bool right)
        {
            _left = left;
            _right = right;
        }
        
        public void SetBelowCollision(bool value)
        {
            _below = value;
        }

        public bool HasVerticalCollision()
        {
            return _above || _below;
        }

        public bool HasHorizontalCollision()
        {
            return _left || _right;
        }
    }
}
