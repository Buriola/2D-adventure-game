using Buriola.Gameplay.Player.Data;
using UnityEngine;

namespace Buriola.Gameplay.Player.FSM.SuperStates
{
    public class PlayerGroundedState : PlayerState
    {
        protected Vector2 _input;
        
        public PlayerGroundedState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, string animationName) : base(player, stateMachine, data, animationName)
        {
            
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            _input = _playerController.InputHandler.MovementAxis;
        }
    }
}
