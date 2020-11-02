using System;
using Buriola.Gameplay.Player.Data;
using UnityEngine;

namespace Buriola.Gameplay.Player.FSM
{
    public abstract class PlayerState : IDisposable
    {
        protected readonly PlayerController2D PlayerController;
        protected readonly PlayerStateMachine StateMachine;
        protected readonly PlayerData PlayerData;

        protected bool IsAnimationFinished;
        protected float StartTime;
        protected int AnimationHash;
        
        protected PlayerState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash)
        {
            PlayerController = player;
            StateMachine = stateMachine;
            PlayerData = data;
            AnimationHash = animationHash;
        }

        public virtual void OnEnter()
        {
            DoChecks();
            
            PlayerController.AnimController.PlayAnimation(AnimationHash);
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

        protected virtual void DoChecks() { }

        public virtual void Dispose()
        {
            
        }
        
        public virtual void AnimationTrigger() { }
        public virtual void AnimationFinishTrigger() => IsAnimationFinished = true;
    }
}
