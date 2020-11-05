using Buriola.Gameplay.Player;
using UnityEngine;

namespace Buriola.Gameplay.Camera
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private PlayerController2D _player = null;
        [SerializeField] private Vector2 _focusAreaSize = Vector2.zero;
        [SerializeField] private float _verticalOffset = 0f;
        [SerializeField] private float _verticalSmoothTime = 0f;
        [SerializeField] private float _lookAheadDistanceX = 0f;
        [SerializeField] private float _lookAheadSmoothTimeX = 0f;
        
        private CameraFocusArea _focusArea;
        private float _currentLookAheadX;
        private float _targetLookAheadX;
        private float _lookAheadDirectionX;
        private float _smoothLookVelocityX;
        private float _smoothLookVelocityY;
        private bool _lookAheadStopped;
        
        //Debug variables
        [SerializeField] private bool _showGizmos = false;
        [SerializeField] private Color _gizmosColor = default;

        private void Start()
        {
            _focusArea = new CameraFocusArea(_player.Collider.bounds, _focusAreaSize);
        }

        private void LateUpdate()
        {
            _focusArea.Update(_player.Collider.bounds);

            Vector2 focusPosition = _focusArea.Center + Vector2.up * _verticalOffset;
            
            if (_focusArea.Velocity.x != 0)
            {
                _lookAheadDirectionX = Mathf.Sign(_focusArea.Velocity.x);
                if (Mathf.Sign(_player.InputHandler.RawInputX) == Mathf.Sign(_focusArea.Velocity.x) &&
                    _player.InputHandler.RawInputX != 0)
                {
                    _lookAheadStopped = false;
                    _targetLookAheadX = _lookAheadDirectionX * _lookAheadDistanceX;
                }
                else
                {
                    if (!_lookAheadStopped)
                    {
                        _lookAheadStopped = true;
                        _targetLookAheadX = _currentLookAheadX + (_lookAheadDirectionX * _lookAheadDistanceX - _currentLookAheadX) / 4f;
                    }
                }
            }

            _targetLookAheadX = _lookAheadDirectionX * _lookAheadDistanceX;
            _currentLookAheadX = Mathf.SmoothDamp(_currentLookAheadX, _targetLookAheadX, ref _smoothLookVelocityX, _lookAheadSmoothTimeX);

            focusPosition.y = Mathf.SmoothDamp(transform.position.y, focusPosition.y, ref _smoothLookVelocityY, _verticalSmoothTime);
            focusPosition += Vector2.right * _currentLookAheadX;
            transform.position = (Vector3)focusPosition + Vector3.forward * -10f;
        }

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying) return;
            
            if (_showGizmos && _player)
            {
                Gizmos.color = _gizmosColor;
                Gizmos.DrawCube(_focusArea.Center, _focusAreaSize);
            }
        }
    }
}
