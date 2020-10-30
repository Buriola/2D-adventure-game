using Buriola.Gameplay.Player.Data;
using UnityEngine;

namespace Buriola.Gameplay.Player.FSM
{
    public class PlayerState
    {
        protected PlayerController2D _playerController;
        protected PlayerStateMachine _stateMachine;
        protected PlayerData _playerData;

        protected float _startTime;
        protected string _animationName;
        
        public PlayerState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, string animationName)
        {
            _playerController = player;
            _stateMachine = stateMachine;
            _playerData = data;
            _animationName = animationName;
        }

        public virtual void OnEnter()
        {
            DoChecks();
            
            _playerController.AnimController.PlayAnimation(_animationName);
            
            _startTime = Time.time;
        }

        public virtual void OnUpdate()
        {
            
        }

        public virtual void OnPhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void OnExit()
        {
            _playerController.AnimController.StopAnimation();
        }

        public virtual void DoChecks()
        {
            
        }
    }
}
