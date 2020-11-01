using Buriola.Gameplay.Player.Data;
using Buriola.Gameplay.Player.FSM.SuperStates;
using UnityEngine;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public sealed class PlayerCrouchIdleState : PlayerGroundedState
    {
        private bool _obstacleAbove;
        
        public PlayerCrouchIdleState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash) : base(player, stateMachine, data, animationHash)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            PlayerController.Collider.size = PlayerData.CrouchedColliderSize;
            PlayerController.Collider.offset = PlayerData.CrouchedColliderOffset;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (RawInputX != 0f)
            {
                StateMachine.ChangeState(PlayerController.CrouchMoveState);
            }

            if (RawInputY >= 0f && !ObstacleAbove)
            {
                StateMachine.ChangeState(PlayerController.IdleState);
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            
            PlayerController.Collider.size = PlayerData.NormalColliderSize;
            PlayerController.Collider.offset = PlayerData.NormalColliderOffset;
        }
    }
}
