using UnityEngine;

namespace Buriola._2D_Physics
{
    public sealed class CollisionInfo2D
    {
        private bool _above;
        private bool _below;
        private bool _left;
        private bool _right;
        private float _currentSlopeAngle;
        private float _previousSlopeAngle;

        public bool Left => _left;
        public bool Right => _right;
        public bool Above => _above;
        public bool Below => _below;
        public float CurrentSlopeAngle => _currentSlopeAngle;
        public float PreviousSlopeAngle => _previousSlopeAngle;
        public RaycastHit2D[] VerticalCollisionHits { get; set; }
        public RaycastHit2D[] HorizontalCollisionHits { get; set; }

        public CollisionInfo2D(int rayCount)
        {
            VerticalCollisionHits = new RaycastHit2D[rayCount];
            HorizontalCollisionHits = new RaycastHit2D[rayCount];
        }
        
        public void Reset()
        {
            System.Array.Clear(VerticalCollisionHits, 0, VerticalCollisionHits.Length);
            System.Array.Clear(HorizontalCollisionHits, 0, HorizontalCollisionHits.Length);

            _above = _below = false;
            _left = _right = false;
            
            _previousSlopeAngle = _currentSlopeAngle;
            _currentSlopeAngle = 0f;
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

        public void SetSlopeAngle(float value)
        {
            _currentSlopeAngle = value;
        }
    }
}
