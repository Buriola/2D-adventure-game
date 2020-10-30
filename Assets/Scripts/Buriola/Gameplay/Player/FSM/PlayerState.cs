using Buriola.Gameplay.Player.Data;
using UnityEngine;

namespace Buriola.Gameplay.Player.FSM
{
    public class PlayerState
    {
        protected PlayerController2D PlayerController;
        protected PlayerStateMachine StateMachine;
        protected PlayerData PlayerData;

        protected bool IsAnimationFinished;
        protected float StartTime;
        protected string AnimationName;
        
        public PlayerState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, string animationName)
        {
            PlayerController = player;
            StateMachine = stateMachine;
            PlayerData = data;
            AnimationName = animationName;
        }

        public virtual void OnEnter()
        {
            DoChecks();
            
            PlayerController.AnimController.PlayAnimation(AnimationName);
            StartTime = Time.time;
            IsAnimationFinished = false;
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
            PlayerController.AnimController.StopAnimation();
        }

        public virtual void DoChecks() { }
        public virtual void AnimationTrigger() { }
        public virtual void AnimationFinishTrigger() => IsAnimationFinished = true;
    }
}
