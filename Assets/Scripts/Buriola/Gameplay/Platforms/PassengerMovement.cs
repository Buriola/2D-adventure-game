using UnityEngine;

namespace Buriola.Gameplay.Platforms
{
    public struct PassengerMovement
    {
        public Transform PassengerTransform;
        public Vector2 Velocity;
        public bool StandingOnPlatform;
        public bool MoveBeforePlatform;
    }
}
