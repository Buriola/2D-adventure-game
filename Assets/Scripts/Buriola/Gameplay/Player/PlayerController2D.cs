using Buriola.Gameplay.Animations;
using Buriola.Gameplay.Player.Data;
using Buriola.Gameplay.Player.FSM;
using Buriola.Gameplay.Player.FSM.SubStates;
using UnityEngine;

namespace Buriola.Gameplay.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(AnimationController))]
    [RequireComponent(typeof(PlayerInputHandler))]
    [DisallowMultipleComponent]
    public class PlayerController2D : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData = null;
        [SerializeField] private Vector2 _groundCheckPoint = Vector2.zero;
        [SerializeField] private Vector2 _ledgeCheckPoint = Vector2.zero;

        public Rigidbody2D Rb2d { get; private set; }
        public Vector2 CurrentVelocity { get; private set; }
        public PlayerStateMachine StateMachine { get; private set; }
        public AnimationController AnimController { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerLandState LandState { get; private set; }
        public PlayerWallSlideState WallSlideState { get; private set; }
        public PlayerLedgeClimbState LedgeClimbState { get; private set; }
        
        public int DirectionX { get; private set; }
        public int WallDirectionX { get; private set; }
        private Vector2 _velocity;
        
        public bool CanJump { get; private set; }

        private bool _gravityEnabled;
        private float _jumpTimer;
        private float _gravity;
        private Vector2 _gravityForce;

        private void Awake()
        {
            StateMachine = new PlayerStateMachine();
            IdleState = new PlayerIdleState(this, StateMachine, _playerData, AnimationConstants.PLAYER_IDLE_HASH);
            MoveState = new PlayerMoveState(this, StateMachine, _playerData, AnimationConstants.PLAYER_MOVING_HASH);
            JumpState = new PlayerJumpState(this, StateMachine, _playerData, AnimationConstants.PLAYER_JUMP_HASH);
            InAirState = new PlayerInAirState(this, StateMachine, _playerData, AnimationConstants.PLAYER_AIR_HASH);
            LandState = new PlayerLandState(this, StateMachine, _playerData, AnimationConstants.PLAYER_LAND_HASH);
            WallSlideState = new PlayerWallSlideState(this, StateMachine, _playerData, AnimationConstants.PLAYER_WALL_SLIDING_HASH);
            LedgeClimbState = new PlayerLedgeClimbState(this, StateMachine, _playerData, AnimationConstants.PLAYER_LEDGE_GRAB_HASH);
        }

        private void Start()
        {
            Rb2d = GetComponent<Rigidbody2D>();
            AnimController = GetComponent<AnimationController>();
            InputHandler = GetComponent<PlayerInputHandler>();
            DirectionX = 1;
            CanJump = true;
            _gravityEnabled = true;

            _gravity = -(2 * _playerData.MaxJumpHeight) / Mathf.Pow(_playerData.TimeToJumpApex, 2);
            _gravityForce.Set(0f, _gravity);
            
            StateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            CurrentVelocity = Rb2d.velocity;
            StateMachine.CurrentState.OnUpdate();
            
            CheckIfCanJump();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.OnPhysicsUpdate();

            if (!Rb2d.IsSleeping() && _gravityEnabled)
            {
                Rb2d.AddForce(_gravityForce, ForceMode2D.Force);   
            }
        }

        private void OnDisable()
        {
            IdleState.Dispose();
            MoveState.Dispose();
            JumpState.Dispose();
            InAirState.Dispose();
            LandState.Dispose();
            WallSlideState.Dispose();
            LedgeClimbState.Dispose();
        }

        private void OnDrawGizmos()
        {
            if (_playerData != null)
            {
                Gizmos.color = Color.yellow;
                Vector2 globalWaypointPos = _groundCheckPoint + (Vector2)transform.position;
                Gizmos.DrawWireSphere(globalWaypointPos, _playerData.GroundCheckRadius);
                Gizmos.DrawRay(transform.position, Vector2.right * _playerData.WallDistanceCheck); 
                Gizmos.DrawRay((Vector2)transform.position + _ledgeCheckPoint, Vector2.right * _playerData.LedgeDistanceCheck); 
            }
        }
        
        private void Flip()
        {
            DirectionX *= -1;
            transform.Rotate(0f, 180f, 0f);
        }

        private void CheckIfCanJump()
        {
            if (!CanJump)
            {
                _jumpTimer += Time.deltaTime;
                if (_jumpTimer >= _playerData.JumpCooldown)
                {
                    _jumpTimer = 0f;
                    CanJump = true;
                }
            }
        }
        
        private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
        private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
        
        public bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheckPoint + (Vector2)transform.position, _playerData.GroundCheckRadius, _playerData.GroundCollisionMask);;
        }

        public bool IsTouchingWall()
        {
            if (Physics2D.Raycast(transform.position, Vector2.right * DirectionX, _playerData.WallDistanceCheck,
                _playerData.WallCollisionMask))
            {
                WallDirectionX = (int)(Vector2.right * DirectionX).x;
                return true;
            }

            return false;
        }

        public bool CheckForLedges()
        {
            return Physics2D.Raycast((Vector2) transform.position + _ledgeCheckPoint, Vector2.right * DirectionX,
                _playerData.LedgeDistanceCheck, _playerData.GroundCollisionMask);
        }

        public Vector2 FindCornerPosition()
        {
            float xDistance = 0f;
            float yDistance = 0f;

            Vector2 globalLedgeCheckPos = (Vector2) transform.position + _ledgeCheckPoint; 
            
            RaycastHit2D xHit = Physics2D.Raycast(transform.position, Vector2.right * DirectionX,
                _playerData.WallDistanceCheck, _playerData.GroundCollisionMask);
            
            if (xHit)
            {
                xDistance = xHit.distance;
                _velocity.Set(xDistance * DirectionX, 0f);
            }

            RaycastHit2D yHit = Physics2D.Raycast(globalLedgeCheckPos + _velocity, Vector2.down,
                _playerData.LedgeDistanceCheck, _playerData.GroundCollisionMask);

            if (yHit)
            {
                yDistance = yHit.distance;
            }
            
            _velocity.Set(transform.position.x + (xDistance * DirectionX), globalLedgeCheckPos.y - yDistance);
            
            return _velocity;
        }
        
        public void SetVelocity(Vector2 velocity)
        {
            _velocity = velocity;
            Rb2d.velocity = _velocity;
            CurrentVelocity = _velocity;
        }

        public void SetVelocityX(float xVelocity)
        {
            _velocity.Set(xVelocity, CurrentVelocity.y);
            Rb2d.velocity = _velocity;
            CurrentVelocity = _velocity;
        }

        public void SetVelocityY(float yVelocity)
        {
            _velocity.Set(CurrentVelocity.x, yVelocity);
            Rb2d.velocity = _velocity;
            CurrentVelocity = _velocity;
        }

        public void CheckIfShouldFlip(float xInput)
        {
            if (xInput != 0 && xInput != DirectionX)
            {
                Flip();
            }
        }

        public void SetCanJump(bool canJump)
        {
            CanJump = canJump;
        }

        public void ToggleGravity()
        {
            _gravityEnabled = !_gravityEnabled;
        }
    }
}
