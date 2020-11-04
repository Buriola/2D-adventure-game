using Buriola.Gameplay.Animations;
using Buriola.Gameplay.Combat;
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
    public class PlayerController2D : MonoBehaviour, IDamageable
    {
        [SerializeField] private PlayerData _playerData = null;

        //Debug variables
        [SerializeField] private bool _debugAttack = false;
        [SerializeField] private float _attackRadius = 0f;
        [SerializeField] private Vector2 _attackCenterPoint = Vector2.zero;

        [SerializeField] private bool _debugLedge = false;
        [SerializeField] private Vector2 _ledgeDetectedPosition = Vector2.zero;
        [SerializeField] private Vector2 _cornerPosition = Vector2.zero;
        
        private Vector2 _velocity;
        private Vector2 _gravityForce;
        
        private bool _gravityEnabled;
        private float _gravity;
        private Rigidbody2D _rb2d;
        
        public CapsuleCollider2D Collider { get; private set; }
        public AnimationController AnimController { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public CombatController CombatController { get; private set; }
        public Vector2 CurrentVelocity { get; private set; }
        public int DirectionX { get; private set; }
        public int WallDirectionX { get; private set; }

        #region State Machine

        private PlayerStateMachine _stateMachine;
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerLandState LandState { get; private set; }
        public PlayerWallSlideState WallSlideState { get; private set; }
        public PlayerLedgeClimbState LedgeClimbState { get; private set; }
        public PlayerLedgeJumpState LedgeJumpState { get; private set; }
        public PlayerCrouchIdleState CrouchIdleState { get; private set; }
        public PlayerCrouchMoveState CrouchMoveState { get; private set; }
        public PlayerAttackState SwordAttackState { get; private set; }
        public PlayerAttackState HandAttackState { get; private set; }
        public PlayerAttackState AirAttackState { get; private set; }
        public PlayerSlideState SlideState { get; private set; }
        public PlayerItemState ItemState { get; private set; }
        #endregion

        private void Awake()
        {
            _stateMachine = new PlayerStateMachine();
            CombatController = new CombatController();
            
            IdleState        = new PlayerIdleState(this, _stateMachine, _playerData, AnimationConstants.PLAYER_IDLE_2_HASH);
            MoveState        = new PlayerMoveState(this, _stateMachine, _playerData, AnimationConstants.PLAYER_RUN_2_HASH);
            JumpState        = new PlayerJumpState(this, _stateMachine, _playerData, AnimationConstants.PLAYER_JUMP_HASH);
            InAirState       = new PlayerInAirState(this, _stateMachine, _playerData, AnimationConstants.PLAYER_AIR_HASH);
            LandState        = new PlayerLandState(this, _stateMachine, _playerData, AnimationConstants.PLAYER_LAND_HASH);
            WallSlideState   = new PlayerWallSlideState(this, _stateMachine, _playerData, AnimationConstants.PLAYER_WALL_SLIDING_HASH);
            LedgeClimbState  = new PlayerLedgeClimbState(this, _stateMachine, _playerData, AnimationConstants.PLAYER_LEDGE_GRAB_HASH);
            LedgeJumpState   = new PlayerLedgeJumpState(this, _stateMachine, _playerData, AnimationConstants.PLAYER_LEDGE_JUMP_HASH);
            CrouchIdleState  = new PlayerCrouchIdleState(this, _stateMachine, _playerData, AnimationConstants.PLAYER_CROUCH_IDLE_HASH);
            CrouchMoveState  = new PlayerCrouchMoveState(this, _stateMachine, _playerData, AnimationConstants.PLAYER_CROUCH_WALK_HASH);
            SwordAttackState = new PlayerSwordAttackState(this, _stateMachine, _playerData, AnimationConstants.PLAYER_ATTACK_1_HASH, 3);
            HandAttackState  = new PlayerHandAttackState(this, _stateMachine, _playerData, AnimationConstants.PLAYER_PUNCH_1_HASH, 5);
            AirAttackState   = new PlayerAirAttackState(this, _stateMachine, _playerData, AnimationConstants.PLAYER_AIR_ATTACK_1_HASH, 2);
            SlideState       = new PlayerSlideState(this, _stateMachine, _playerData, AnimationConstants.PLAYER_SLIDE_HASH);
            ItemState        = new PlayerItemState(this, _stateMachine, _playerData, AnimationConstants.PLAYER_USE_ITEM_HASH);
        }

        private void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            Collider = GetComponent<CapsuleCollider2D>();
            AnimController = GetComponent<AnimationController>();
            InputHandler = GetComponent<PlayerInputHandler>();
            DirectionX = 1;
            _gravityEnabled = true;

            _gravity = -(2 * _playerData.MaxJumpHeight) / Mathf.Pow(_playerData.TimeToJumpApex, 2);
            _gravityForce.Set(0f, _gravity);
            
            _stateMachine.Initialize(IdleState);
            CombatController.Initialize(this, _playerData);
        }

        private void Update()
        {
            CurrentVelocity = _rb2d.velocity;
            _stateMachine.CurrentState.OnUpdate();
        }

        private void FixedUpdate()
        {
            _stateMachine.CurrentState.OnPhysicsUpdate();

            if (!_rb2d.IsSleeping() && _gravityEnabled)
            {
                _rb2d.AddForce(_gravityForce, ForceMode2D.Force);   
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
            CrouchIdleState.Dispose();
            CrouchMoveState.Dispose();
            SwordAttackState.Dispose();
            HandAttackState.Dispose();
            AirAttackState.Dispose();
            SlideState.Dispose();
        }

        private void OnDrawGizmos()
        {
            if (_playerData != null)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(_playerData.GroundCheckPoint + (Vector2)transform.position, _playerData.GroundCheckRadius);
                Gizmos.DrawRay(transform.position, Vector2.right * _playerData.WallDistanceCheck); 
                
                Gizmos.DrawRay((Vector2)transform.position + _playerData.LedgeHorizontalCheckPoint, Vector2.right * _playerData.LedgeHorizontalDistanceCheck);
                Gizmos.DrawRay((Vector2)transform.position + _playerData.LedgeVerticalCheckPoint, Vector2.down * _playerData.LedgeVerticalDistanceCheck);
                
                Gizmos.color = Color.green;
                Gizmos.DrawRay((Vector2) (transform.position) - (Vector2.up), Vector2.up * 1f);

                if (_debugAttack)
                {
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawWireSphere((Vector2) (transform.position) + _attackCenterPoint, _attackRadius);
                }

                if (_debugLedge)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireSphere(_ledgeDetectedPosition, 0.1f);
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawWireSphere(_cornerPosition, .1f);
                }
            }
        }
        
        private void Flip()
        {
            DirectionX *= -1;
            transform.Rotate(0f, 180f, 0f);
        }

        private void AnimationTrigger() => _stateMachine.CurrentState.AnimationTrigger();
        private void AnimationFinishTrigger() => _stateMachine.CurrentState.AnimationFinishTrigger();
        
        public bool IsGrounded()
        {
            return Physics2D.OverlapCircle((Vector2)transform.position + _playerData.GroundCheckPoint, _playerData.GroundCheckRadius, _playerData.GroundCollisionMask);
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
            _ledgeDetectedPosition = transform.position;

            return Physics2D.Raycast((Vector2) transform.position + _playerData.LedgeHorizontalCheckPoint, 
                Vector2.right * DirectionX, _playerData.LedgeHorizontalDistanceCheck, _playerData.LedgeCollisionMask);
        }

        public bool CheckForObstaclesAbovePlayer()
        {
            return Physics2D.Raycast(transform.position, Vector2.up, _playerData.CollisionAboveCheckDistance, _playerData.GroundCollisionMask);
        }

        public Vector2 FindCornerPosition()
        {
            float xValue = 0f;
            float yValue = 0f;
            
            Vector2 verticalCheckPoint = _playerData.LedgeVerticalCheckPoint;
            verticalCheckPoint.x *= DirectionX;
            
            RaycastHit2D xHit = Physics2D.Raycast(transform.position, Vector2.right * DirectionX, _playerData.WallDistanceCheck, _playerData.GroundCollisionMask);
            RaycastHit2D yHit = Physics2D.Raycast((Vector2) transform.position + verticalCheckPoint, Vector2.down, _playerData.LedgeVerticalDistanceCheck, _playerData.GroundCollisionMask);

            if (xHit && yHit)
            {
                xValue = xHit.distance;
                yValue = yHit.point.y - xHit.point.y;
            }
            
            _velocity.Set(transform.position.x + (xValue * DirectionX), transform.position.y + yValue);

            _cornerPosition = _velocity;
            
            return _velocity;
        }
        
        public void SetVelocity(Vector2 velocity)
        {
            _velocity = velocity;
            _rb2d.velocity = _velocity;
            CurrentVelocity = _velocity;
        }

        public void SetVelocityX(float xVelocity)
        {
            _velocity.Set(xVelocity, CurrentVelocity.y);
            _rb2d.velocity = _velocity;
            CurrentVelocity = _velocity;
        }

        public void SetVelocityY(float yVelocity)
        {
            _velocity.Set(CurrentVelocity.x, yVelocity);
            _rb2d.velocity = _velocity;
            CurrentVelocity = _velocity;
        }

        public void CheckIfShouldFlip(float xInput)
        {
            if (xInput != 0 && xInput != DirectionX)
            {
                Flip();
            }
        }

        public void ToggleGravity()
        {
            _gravityEnabled = !_gravityEnabled;
        }

        public void SetGravityEnabled(bool value)
        {
            _gravityEnabled = value;
        }
        
        //Called by animation events
        public void SwordAttack(int attackId)
        {
            CombatController.SwordAttack(attackId);
        }

        public void TakeDamage(BaseAttack attack)
        {
            
        }

        public void TakeDamage(float damage)
        {
            
        }
    }
}
