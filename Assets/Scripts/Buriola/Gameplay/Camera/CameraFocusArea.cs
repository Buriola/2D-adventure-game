using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Buriola.Gameplay.Camera
{
    public class CameraFocusArea
    {
        public Vector2 Center;
        public Vector2 Velocity;

        private float _left;
        private float _right;
        private float _top;
        private float _bottom;

        public CameraFocusArea(Bounds targetBounds, Vector2 size)
        {
            _left = targetBounds.center.x - size.x * 0.5f;
            _right = targetBounds.center.x + size.x * 0.5f;
            _bottom = targetBounds.min.y;
            _top = targetBounds.min.y + size.y;

            Velocity = Vector2.zero;
            Center = new Vector2((_left + _right) * 0.5f, (_top + _bottom) * 0.5f);
        }

        public void Update(Bounds targetBounds)
        {
            float shiftX = 0f;
            float shiftY = 0f;

            if (targetBounds.min.x < _left) shiftX = targetBounds.min.x - _left;
            else if (targetBounds.max.x > _right) shiftX = targetBounds.max.x - _right;

            _left += shiftX;
            _right += shiftX;

            if (targetBounds.min.y < _bottom) shiftY = targetBounds.min.y - _bottom;
            else if (targetBounds.max.y > _top) shiftY = targetBounds.max.y - _top;

            _top += shiftY;
            _bottom += shiftY;
            
            Center.Set((_left + _right) * 0.5f, (_top + _bottom) * 0.5f);
            Velocity.Set(shiftX, shiftY);
        }
    }
}
