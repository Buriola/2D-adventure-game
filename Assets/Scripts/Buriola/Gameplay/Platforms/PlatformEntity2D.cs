using System.Collections.Generic;
using Buriola._2D_Physics;
using UnityEngine;

namespace Buriola.Gameplay.Platforms
{
    [DisallowMultipleComponent]
    public sealed class PlatformEntity2D : BaseEntity2D
    {
        [SerializeField] private LayerMask _passengerMask = default;
        [SerializeField] private Vector2 _moveAmount = Vector2.zero;
        
        private readonly HashSet<Transform> _movedPassengers = new HashSet<Transform>();

        private Vector2 _velocity = Vector2.zero;
        private Vector2 _velocityVertically = Vector2.zero;
        private Vector2 _velocityHorizontally = Vector2.zero;

        protected override void Update()
        {
            base.Update();
            
            UpdateRaycastOrigins();
            
            _velocity = _moveAmount * DeltaTime;
            
            MovePassengers(_velocity);
            transform.Translate(_velocity);
        }

        private void MovePassengers(Vector2 velocity)
        {
            _movedPassengers.Clear();
            
            _velocityVertically.x = 0f;
            _velocityVertically.y = 0f;
            
            _velocityHorizontally.x = 0f;
            _velocityHorizontally.y = 0f;
            
            float directionX = Mathf.Sign(velocity.x);
            float directionY = Mathf.Sign(velocity.y);
            
            // Vertically moving platform
            if (velocity.y != 0)
            {
                float rayLength = Mathf.Abs(velocity.y) + SKIN_WIDTH;

                for (int i = 0; i < _verticalRayCount; i++)
                {
                    Vector2 rayOrigin = (directionY == -1) ? _raycastOrigins.BottomLeft : _raycastOrigins.TopLeft;
                    rayOrigin += Vector2.right * (_verticalRaySpacing * i);

                    RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, _passengerMask);
                    if (hit)
                    {
                        if (!_movedPassengers.Contains(hit.transform))
                        {
                            _movedPassengers.Add(hit.transform);
                            
                            float pushX = (directionY == 1) ? velocity.x : 0f;
                            float pushY = velocity.y - (hit.distance - SKIN_WIDTH) * directionY;

                            _velocityVertically.x = pushX;
                            _velocityVertically.y = pushY;
                        
                            hit.transform.Translate(_velocityVertically);
                        }
                    }
                }
            }
            
            // Horizontally moving platform
            if (velocity.x != 0)
            {
                float rayLength = Mathf.Abs(velocity.x) + SKIN_WIDTH;

                for (int i = 0; i < _horizontalRayCount; i++)
                {
                    Vector2 rayOrigin = (directionX == -1) ? _raycastOrigins.BottomLeft : _raycastOrigins.BottomRight;
                    rayOrigin += Vector2.up * (_horizontalRaySpacing * i);

                    RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, _passengerMask);
                    if (hit)
                    {
                        if (!_movedPassengers.Contains(hit.transform))
                        {
                            _movedPassengers.Add(hit.transform);
                            
                            float pushX = velocity.x - (hit.distance - SKIN_WIDTH) * directionX;
                            float pushY = 0F;

                            _velocityHorizontally.x = pushX;
                            _velocityHorizontally.y = pushY;
                            
                            hit.transform.Translate(_velocityHorizontally);
                        }
                    }
                }
            }
            
            // Passenger on top of a horizontally or downward moving platform
            if (directionY == -1 || velocity.y == 0 && directionX != 0)
            {
                float rayLength = SKIN_WIDTH * 2f;

                for (int i = 0; i < _verticalRayCount; i++)
                {
                    Vector2 rayOrigin = _raycastOrigins.TopLeft + Vector2.right * (_verticalRaySpacing * i);

                    RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up, rayLength, _passengerMask);
                    if (hit)
                    {
                        if (!_movedPassengers.Contains(hit.transform))
                        {
                            _movedPassengers.Add(hit.transform);

                            float pushX = velocity.x;
                            float pushY = velocity.y;

                            _velocityVertically.x = pushX;
                            _velocityVertically.y = pushY;
                        
                            hit.transform.Translate(_velocityVertically);
                        }
                    }
                }
            }
        }
    }
}
