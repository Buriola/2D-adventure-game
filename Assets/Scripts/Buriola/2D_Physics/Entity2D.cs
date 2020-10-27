using UnityEngine;

namespace Buriola._2D_Physics
{
    [DisallowMultipleComponent]
    public sealed class Entity2D : BaseEntity2D
    {
        private float _maxClimbAngle = 80f;
        private float _maxDescendAngle = 75f;
        
        protected override void Start()
        {
            base.Start();
            CollisionInfo = new CollisionInfo2D();
        }

        private void VerticalCollisions(ref Vector2 moveAmount)
        {
            float directionY = Mathf.Sign(moveAmount.y);
            float rayLength = Mathf.Abs(moveAmount.y) + SKIN_WIDTH;

            for (int i = 0; i < _verticalRayCount; i++)
            {
                Vector2 rayOrigin = (directionY == -1) ? _raycastOrigins.BottomLeft : _raycastOrigins.TopLeft;
                rayOrigin += Vector2.right * (_verticalRaySpacing * i + moveAmount.x);
                
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, _collisionMask);
                if (hit)
                {
                    moveAmount.y = (hit.distance - SKIN_WIDTH) * directionY;
                    rayLength = hit.distance;

                    if (CollisionInfo.IsClimbingSlope)
                    {
                        moveAmount.x = moveAmount.y / Mathf.Tan(CollisionInfo.CurrentSlopeAngle * Mathf.Deg2Rad) *
                                       Mathf.Sign(moveAmount.x);
                    }
                    
                    bool below = directionY == -1;
                    bool above = directionY == 1;
                    CollisionInfo.SetVerticalCollisions(above, below);
                }
            }

            //We need to check if the slope angle changed during the climb and update it
            if (CollisionInfo.IsClimbingSlope)
            {
                float directionX = Mathf.Sign(moveAmount.x);
                rayLength = Mathf.Abs(moveAmount.x) + SKIN_WIDTH;
                bool isMovingLeft = directionX == -1;
                
                Vector2 rayOrigin = (isMovingLeft ? _raycastOrigins.BottomLeft : _raycastOrigins.BottomRight) + Vector2.up * moveAmount.y;

                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, _collisionMask);
                if (hit)
                {
                    float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
                    if (slopeAngle != CollisionInfo.CurrentSlopeAngle)
                    {
                        moveAmount.x = (hit.distance - SKIN_WIDTH) * directionX;
                        CollisionInfo.CurrentSlopeAngle = slopeAngle;
                    }
                }
            }
        }

        private void HorizontalCollisions(ref Vector2 moveAmount)
        {
            float directionX = Mathf.Sign(moveAmount.x);
            float rayLength = Mathf.Abs(moveAmount.x) + SKIN_WIDTH;
            
            for (int i = 0; i < _horizontalRayCount; i++)
            {
                Vector2 rayOrigin = (directionX == -1) ? _raycastOrigins.BottomLeft : _raycastOrigins.BottomRight;
                rayOrigin += Vector2.up * (_horizontalRaySpacing * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, _collisionMask);

                if (hit)
                {
                    //Checking terrain slope
                    float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
                    if (i == 0 && slopeAngle <= _maxClimbAngle)
                    {
                        if (CollisionInfo.IsDescendingSlope)
                        {
                            CollisionInfo.IsDescendingSlope = false;
                            moveAmount = CollisionInfo.PreviousVelocity;
                        }
                        
                        float distanceToSlopeStart = 0f;
                        if (slopeAngle != CollisionInfo.PreviousSlopeAngle)
                        { 
                            distanceToSlopeStart = hit.distance - SKIN_WIDTH;
                            moveAmount.x -= distanceToSlopeStart * directionX;
                        }
                        ClimbSlope(ref moveAmount, slopeAngle);
                        moveAmount.x += distanceToSlopeStart * directionX;
                    }

                    if (!CollisionInfo.IsClimbingSlope || slopeAngle > _maxClimbAngle)
                    {
                        moveAmount.x = (hit.distance - SKIN_WIDTH) * directionX;
                        rayLength = hit.distance;

                        if (CollisionInfo.IsClimbingSlope)
                        {
                            moveAmount.y = Mathf.Tan(CollisionInfo.CurrentSlopeAngle * Mathf.Deg2Rad) *
                                           Mathf.Abs(moveAmount.x);
                        }
                        
                        bool left = directionX == -1;
                        bool right = directionX == 1;
                        CollisionInfo.SetHorizontalCollisions(left, right);
                    }
                }
            }
        }

        private void ClimbSlope(ref Vector2 moveAmount, float slopeAngle)
        {
            float moveDistance = Mathf.Abs(moveAmount.x);
            float climbVelocityY = Mathf.Sin(slopeAngle * Mathf.Deg2Rad) * moveDistance;

            // Check if entity is jumping
            if (moveAmount.y <= climbVelocityY)
            {
                moveAmount.y = climbVelocityY;
                moveAmount.x = Mathf.Cos(slopeAngle * Mathf.Deg2Rad) * moveDistance * Mathf.Sign(moveAmount.x);
                
                CollisionInfo.SetBelowCollision(true);
                CollisionInfo.IsClimbingSlope = true;
                CollisionInfo.CurrentSlopeAngle = slopeAngle;
            }
        }

        private void DescendSlope(ref Vector2 moveAmount)
        {
            float directionX = Mathf.Sign(moveAmount.x);
            bool isMovingLeft = directionX == -1;
            
            Vector2 rayOrigin = isMovingLeft ? _raycastOrigins.BottomRight : _raycastOrigins.BottomLeft;

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, Mathf.Infinity, _collisionMask);
            if (hit)
            {
                float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
                if (slopeAngle != 0 && slopeAngle <= _maxDescendAngle)
                {
                    if (Mathf.Sign(hit.normal.x) == directionX)
                    {
                        if (hit.distance - SKIN_WIDTH <=
                            Mathf.Tan(slopeAngle * Mathf.Deg2Rad) * Mathf.Abs(moveAmount.x))
                        {
                            float moveDistance = Mathf.Abs(moveAmount.x);
                            float descendVelocityY = Mathf.Sin(slopeAngle * Mathf.Deg2Rad) * moveDistance;

                            moveAmount.x = Mathf.Cos(slopeAngle * Mathf.Deg2Rad) * moveDistance *
                                           Mathf.Sign(moveAmount.x);

                            moveAmount.y -= descendVelocityY;

                            CollisionInfo.CurrentSlopeAngle = slopeAngle;
                            CollisionInfo.IsDescendingSlope = true;
                            CollisionInfo.SetBelowCollision(true);
                        }
                    }
                }
            }
        }

        public void Move(Vector2 moveAmount)
        {
            UpdateRaycastOrigins();
            CollisionInfo.Reset();
            CollisionInfo.PreviousVelocity = moveAmount;

            if (moveAmount.y < 0)
            {
                DescendSlope(ref moveAmount);
            }
            
            if (moveAmount.x != 0)
            {
                HorizontalCollisions(ref moveAmount);
            }

            if (moveAmount.y != 0)
            {
                VerticalCollisions(ref moveAmount);
            }
            
            transform.Translate(moveAmount);
        }
    }
}
