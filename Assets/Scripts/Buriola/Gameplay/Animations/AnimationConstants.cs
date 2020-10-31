using UnityEngine;

namespace Buriola.Gameplay.Animations
{
    public static class AnimationConstants
    {
        private const string PLAYER_IDLE = "Idle1";
        private const string PLAYER_MOVING = "Run1";
        private const string PLAYER_JUMP = "Jump";
        private const string PLAYER_IN_AIR = "InAir";
        private const string PLAYER_LAND = "Land";
        private const string PLAYER_WALL_SLIDING = "WallSlide";
        
        public static readonly int PLAYER_IDLE_HASH = Animator.StringToHash(PLAYER_IDLE);
        public static readonly int PLAYER_MOVING_HASH = Animator.StringToHash(PLAYER_MOVING);
        public static readonly int PLAYER_JUMP_HASH = Animator.StringToHash(PLAYER_JUMP);
        public static readonly int PLAYER_AIR_HASH = Animator.StringToHash(PLAYER_IN_AIR);
        public static readonly int PLAYER_LAND_HASH = Animator.StringToHash(PLAYER_LAND);
        public static readonly int PLAYER_WALL_SLIDING_HASH = Animator.StringToHash(PLAYER_WALL_SLIDING);
    }
}
