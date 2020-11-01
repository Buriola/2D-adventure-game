﻿using UnityEngine;

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
        private const string PLAYER_LEDGE_CLIMB = "LedgeClimb";
        private const string PLAYER_LEDGE_GRAB = "LedgeGrab";
        private const string PLAYER_LEDGE_JUMP = "LedgeJump";
        private const string PLAYER_CROUCH_IDLE = "CrouchIdle1";
        private const string PLAYER_CROUCH_WALK = "CrouchWalk";
        
        public static readonly int PLAYER_IDLE_HASH = Animator.StringToHash(PLAYER_IDLE);
        public static readonly int PLAYER_MOVING_HASH = Animator.StringToHash(PLAYER_MOVING);
        public static readonly int PLAYER_JUMP_HASH = Animator.StringToHash(PLAYER_JUMP);
        public static readonly int PLAYER_AIR_HASH = Animator.StringToHash(PLAYER_IN_AIR);
        public static readonly int PLAYER_LAND_HASH = Animator.StringToHash(PLAYER_LAND);
        public static readonly int PLAYER_WALL_SLIDING_HASH = Animator.StringToHash(PLAYER_WALL_SLIDING);
        public static readonly int PLAYER_LEDGE_CLIMB_HASH = Animator.StringToHash(PLAYER_LEDGE_CLIMB);
        public static readonly int PLAYER_LEDGE_GRAB_HASH = Animator.StringToHash(PLAYER_LEDGE_GRAB);
        public static readonly int PLAYER_LEDGE_JUMP_HASH = Animator.StringToHash(PLAYER_LEDGE_JUMP);
        public static readonly int PLAYER_CROUCH_IDLE_HASH = Animator.StringToHash(PLAYER_CROUCH_IDLE);
        public static readonly int PLAYER_CROUCH_WALK_HASH = Animator.StringToHash(PLAYER_CROUCH_WALK);
    }
}
