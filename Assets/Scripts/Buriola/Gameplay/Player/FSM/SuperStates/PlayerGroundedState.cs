using Buriola.Gameplay.Player.Data;
using UnityEngine;

namespace Buriola.Gameplay.Player.FSM.SuperStates
{
    public class PlayerGroundedState : PlayerState
    {
        protected Vector2 Input;
        protected float RawInputX;
        
        public PlayerGroundedState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, string animationName) : base(player, stateMachine, data, animationName)
        {
            
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            Input = _playerController.InputHandler.MovementAxis;
            RawInputX = _playerController.InputHandler.RawInputX;
        }
    }
}
