using UnityEngine;

namespace Buriola.Gameplay.Animations
{
    public static class AnimationConstants
    {
        private const string PLAYER_IDLE_1 = "Idle1";
        private const string PLAYER_IDLE_2 = "Idle2";
        private const string PLAYER_IDLE_3 = "Idle3";
        private const string PLAYER_RUN_1 = "Run1";
        private const string PLAYER_RUN_2 = "Run2";
        private const string PLAYER_RUN_3 = "Run3";
        private const string PLAYER_JUMP = "Jump";
        private const string PLAYER_IN_AIR = "InAir";
        private const string PLAYER_LAND = "Land";
        private const string PLAYER_WALL_SLIDING = "WallSlide";
        private const string PLAYER_LEDGE_CLIMB = "LedgeClimb";
        private const string PLAYER_LEDGE_GRAB = "LedgeGrab";
        private const string PLAYER_LEDGE_JUMP = "LedgeJump";
        private const string PLAYER_CROUCH_IDLE = "CrouchIdle1";
        private const string PLAYER_CROUCH_WALK = "CrouchWalk";
        private const string PLAYER_ATTACK_1 = "Attack1";
        private const string PLAYER_ATTACK_2 = "Attack2";
        private const string PLAYER_ATTACK_3 = "Attack3";
        private const string PLAYER_AIR_ATTACK_1 = "AirAttack1";
        private const string PLAYER_AIR_ATTACK_2 = "AirAttack2";
        private const string PLAYER_AIR_ATTACK_3_START = "AirAttack3_Start";
        private const string PLAYER_AIR_ATTACK_3_LOOP = "AirAttack3_Loop";
        private const string PLAYER_AIR_ATTACK_3_END = "AirAttack3_End";
        private const string PLAYER_PUNCH_1 = "Punch1";
        private const string PLAYER_PUNCH_2 = "Punch2";
        private const string PLAYER_PUNCH_3 = "Punch3";
        private const string PLAYER_KICK_1 = "Kick1";
        private const string PLAYER_KICK_2 = "Kick2";
        private const string PLAYER_SLIDE = "Slide";
        private const string PLAYER_STAND = "Stand";
        private const string PLAYER_SOMERSAULT = "Somersault";
        private const string PLAYER_USE_ITEM = "Item";
        
        public static readonly int PLAYER_IDLE_1_HASH       = Animator.StringToHash(PLAYER_IDLE_1);
        public static readonly int PLAYER_IDLE_2_HASH       = Animator.StringToHash(PLAYER_IDLE_2);
        public static readonly int PLAYER_IDLE_3_HASH       = Animator.StringToHash(PLAYER_IDLE_3);
        public static readonly int PLAYER_RUN_1_HASH        = Animator.StringToHash(PLAYER_RUN_1);
        public static readonly int PLAYER_RUN_2_HASH        = Animator.StringToHash(PLAYER_RUN_2);
        public static readonly int PLAYER_RUN_3_HASH        = Animator.StringToHash(PLAYER_RUN_3);
        public static readonly int PLAYER_JUMP_HASH         = Animator.StringToHash(PLAYER_JUMP);
        public static readonly int PLAYER_AIR_HASH          = Animator.StringToHash(PLAYER_IN_AIR);
        public static readonly int PLAYER_LAND_HASH         = Animator.StringToHash(PLAYER_LAND);
        public static readonly int PLAYER_WALL_SLIDING_HASH = Animator.StringToHash(PLAYER_WALL_SLIDING);
        public static readonly int PLAYER_LEDGE_CLIMB_HASH  = Animator.StringToHash(PLAYER_LEDGE_CLIMB);
        public static readonly int PLAYER_LEDGE_GRAB_HASH   = Animator.StringToHash(PLAYER_LEDGE_GRAB);
        public static readonly int PLAYER_LEDGE_JUMP_HASH   = Animator.StringToHash(PLAYER_LEDGE_JUMP);
        public static readonly int PLAYER_CROUCH_IDLE_HASH  = Animator.StringToHash(PLAYER_CROUCH_IDLE);
        public static readonly int PLAYER_CROUCH_WALK_HASH  = Animator.StringToHash(PLAYER_CROUCH_WALK);
        public static readonly int PLAYER_ATTACK_1_HASH     = Animator.StringToHash(PLAYER_ATTACK_1);
        public static readonly int PLAYER_ATTACK_2_HASH     = Animator.StringToHash(PLAYER_ATTACK_2);
        public static readonly int PLAYER_ATTACK_3_HASH     = Animator.StringToHash(PLAYER_ATTACK_3);
        public static readonly int PLAYER_AIR_ATTACK_1_HASH = Animator.StringToHash(PLAYER_AIR_ATTACK_1);
        public static readonly int PLAYER_AIR_ATTACK_2_HASH = Animator.StringToHash(PLAYER_AIR_ATTACK_2);
        public static readonly int PLAYER_AIR_ATTACK_3_START_HASH  = Animator.StringToHash(PLAYER_AIR_ATTACK_3_START);
        public static readonly int PLAYER_AIR_ATTACK_3_LOOP_HASH   = Animator.StringToHash(PLAYER_AIR_ATTACK_3_LOOP);
        public static readonly int PLAYER_AIR_ATTACK_3_END_HASH    = Animator.StringToHash(PLAYER_AIR_ATTACK_3_END);
        public static readonly int PLAYER_PUNCH_1_HASH      = Animator.StringToHash(PLAYER_PUNCH_1);
        public static readonly int PLAYER_PUNCH_2_HASH      = Animator.StringToHash(PLAYER_PUNCH_2);
        public static readonly int PLAYER_PUNCH_3_HASH      = Animator.StringToHash(PLAYER_PUNCH_3);
        public static readonly int PLAYER_KICK_1_HASH       = Animator.StringToHash(PLAYER_KICK_1);
        public static readonly int PLAYER_KICK_2_HASH       = Animator.StringToHash(PLAYER_KICK_2);
        public static readonly int PLAYER_SLIDE_HASH        = Animator.StringToHash(PLAYER_SLIDE);
        public static readonly int PLAYER_STAND_HASH        = Animator.StringToHash(PLAYER_STAND);
        public static readonly int PLAYER_SOMERSAULT_HASH   = Animator.StringToHash(PLAYER_SOMERSAULT);
        public static readonly int PLAYER_USE_ITEM_HASH     = Animator.StringToHash(PLAYER_USE_ITEM);
    }
}
