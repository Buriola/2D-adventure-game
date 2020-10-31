using Buriola.Gameplay.Player.Data;
using Buriola.Gameplay.Player.FSM.SuperStates;
using UnityEngine;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public class PlayerLandState : PlayerGroundedState
    {
        public PlayerLandState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash) : base(player, stateMachine, data, animationHash)
        {
        }

        public override void OnEnter()
        {
            DoChecks();
            
            StartTime = Time.time;
            IsAnimationFinished = false;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (RawInputX != 0)
            {
                StateMachine.ChangeState(PlayerController.MoveState);
            }
            else
            {
                StateMachine.ChangeState(PlayerController.IdleState);
            }
        }
    }
}
