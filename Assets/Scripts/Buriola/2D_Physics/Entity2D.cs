using UnityEngine;

namespace Buriola._2D_Physics
{
    [RequireComponent(typeof(BoxCollider2D))]
    [DisallowMultipleComponent]
    public class Entity2D : MonoBehaviour
    {
        private const float SKIN_WIDTH = .015f;
        
        private BoxCollider2D _collider;
        private RaycastOrigins2D _raycastOrigins;

        [SerializeField] private LayerMask _collisionMask = default;
        [SerializeField, Range(2, 10)] private int _horizontalRayCount = 4;
        [SerializeField, Range(2, 10)] private int _verticalRayCount = 4;

        private float _horizontalRaySpacing;
        private float _verticalRaySpacing;

        private void Start()
        {
            _collider = GetComponent<BoxCollider2D>();
            CalculateRaySpacing();
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
                    moveAmount.x = (hit.distance - SKIN_WIDTH) * directionX;
                    rayLength = hit.distance;
                }
            }
        }
        
        private void UpdateRaycastOrigins()
        {
            Bounds bounds = _collider.bounds;
            bounds.Expand(SKIN_WIDTH * -2);
            
            _raycastOrigins.BottomLeft    = new Vector2(bounds.min.x, bounds.min.y);
            _raycastOrigins.BottomRight   = new Vector2(bounds.max.x, bounds.min.y);
            _raycastOrigins.TopLeft       = new Vector2(bounds.min.x, bounds.max.y);
            _raycastOrigins.TopRight      = new Vector2(bounds.max.x, bounds.max.y);
        }

        private void CalculateRaySpacing()
        {
            Bounds bounds = _collider.bounds;
            bounds.Expand(SKIN_WIDTH * -2);

            _horizontalRaySpacing = bounds.size.y / (_horizontalRayCount - 1);
            _verticalRaySpacing = bounds.size.x / (_verticalRayCount - 1);
        }

        public void Move(Vector2 moveAmount)
        {
            UpdateRaycastOrigins();

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
