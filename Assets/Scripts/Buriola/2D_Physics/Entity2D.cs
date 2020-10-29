using UnityEngine;

namespace Buriola._2D_Physics
{
    [DisallowMultipleComponent]
    public sealed class Entity2D : BaseEntity2D
    {
        public Vector2 Velocity;
        public bool HasCollisionLeft => _collisionInfo.Left;
        public bool HasCollisionRight => _collisionInfo.Right;
        public bool HasHorizontalCollision => _collisionInfo.Left || _collisionInfo.Right;
        public bool HasCollisionAbove => _collisionInfo.Above;
        public bool HasCollisionBelow => _collisionInfo.Below;
        public float SlopeAngle => _collisionInfo.CurrentSlopeAngle;
        public RaycastHit2D[] HorizontalHits => _collisionInfo.HorizontalCollisionHits;
        public RaycastHit2D[] VerticalHits => _collisionInfo.HorizontalCollisionHits;
        public RaycastOrigins2D RayOrigins => _raycastOrigins;
        
        protected override void Start()
        {
            base.Start();
            _collisionInfo = new CollisionInfo2D(_rayCount);
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            
            UpdateEntity();
        }

        private void UpdateEntity()
        {
            UpdateRaycastOrigins();
            _collisionInfo.Reset();

            HorizontalCollisions(ref Velocity);
            VerticalCollisions(ref Velocity);
            
            transform.Translate(Velocity);
        }
        
        private void VerticalCollisions(ref Vector2 moveAmount)
        {
            float directionY = Mathf.Sign(moveAmount.y);
            float rayLength = Mathf.Abs(moveAmount.y) + SKIN_WIDTH;

            for (int i = 0; i < _rayCount; i++)
            {
                Vector2 rayOrigin = (directionY == -1) ? _raycastOrigins.BottomLeft : _raycastOrigins.TopLeft;
                rayOrigin += Vector2.right * (_verticalRaySpacing * i + moveAmount.x);
                
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, CollisionMask);
                if (hit)
                {
                    _collisionInfo.VerticalCollisionHits[i] = hit;
                    
                    moveAmount.y = (hit.distance - SKIN_WIDTH) * directionY;
                    rayLength = hit.distance;

                    // if (_collisionInfo.IsClimbingSlope)
                    // {
                    //     moveAmount.x = moveAmount.y / Mathf.Tan(_collisionInfo.CurrentSlopeAngle * Mathf.Deg2Rad) *
                    //                    Mathf.Sign(moveAmount.x);
                    // }
                    
                    bool below = directionY == -1;
                    bool above = directionY == 1;
                    _collisionInfo.SetVerticalCollisions(above, below);
                }
            }

            //We need to check if the slope angle changed during the climb and update it
            // if (_collisionInfo.IsClimbingSlope)
            // {
            //     float directionX = Mathf.Sign(moveAmount.x);
            //     rayLength = Mathf.Abs(moveAmount.x) + SKIN_WIDTH;
            //     bool isMovingLeft = directionX == -1;
            //     
            //     Vector2 rayOrigin = (isMovingLeft ? _raycastOrigins.BottomLeft : _raycastOrigins.BottomRight) + Vector2.up * moveAmount.y;
            //
            //     RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, _collisionMask);
            //     if (hit)
            //     {
            //         float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
            //         if (slopeAngle != _collisionInfo.CurrentSlopeAngle)
            //         {
            //             moveAmount.x = (hit.distance - SKIN_WIDTH) * directionX;
            //             _collisionInfo.SetSlopeAngle(slopeAngle);
            //         }
            //     }
            // }
        }

        private void HorizontalCollisions(ref Vector2 moveAmount)
        {
            float directionX = moveAmount.x;
            float rayLength = Mathf.Abs(moveAmount.x) + SKIN_WIDTH;
            
            if(Mathf.Abs(moveAmount.x) < SKIN_WIDTH)
            {
                rayLength = 2 * SKIN_WIDTH;
            }
            
            for (int i = 0; i < _rayCount; i++)
            {
                Vector2 rayOrigin = (directionX == -1) ? _raycastOrigins.BottomLeft : _raycastOrigins.BottomRight;
                rayOrigin += Vector2.up * (_horizontalRaySpacing * i);
                
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, CollisionMask);
                if (hit)
                {
                    _collisionInfo.HorizontalCollisionHits[i] = hit;
                    
                    // if (i == 0 && slopeAngle <= _maxClimbAngle)
                    // {
                    //     if (_collisionInfo.IsDescendingSlope)
                    //     {
                    //         _collisionInfo.IsDescendingSlope = false;
                    //         moveAmount = _collisionInfo.PreviousVelocity;
                    //     }
                    //     
                    //     float distanceToSlopeStart = 0f;
                    //     if (slopeAngle != _collisionInfo.PreviousSlopeAngle)
                    //     { 
                    //         distanceToSlopeStart = hit.distance - SKIN_WIDTH;
                    //         moveAmount.x -= distanceToSlopeStart * directionX;
                    //     }
                    //     ClimbSlope(ref moveAmount, slopeAngle);
                    //     moveAmount.x += distanceToSlopeStart * directionX;
                    // }
                    
                    float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
                    moveAmount.x = (hit.distance - SKIN_WIDTH) * directionX;
                    rayLength = hit.distance;

                    // if (_collisionInfo.IsClimbingSlope)
                    // {
                    //     moveAmount.y = Mathf.Tan(_collisionInfo.CurrentSlopeAngle * Mathf.Deg2Rad) *
                    //                    Mathf.Abs(moveAmount.x);
                    // }
                    
                    bool left = directionX == -1;
                    bool right = directionX == 1;
                    _collisionInfo.SetHorizontalCollisions(left, right);
                    _collisionInfo.SetSlopeAngle(slopeAngle);
                }
            }
        }
    }
}
