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
        [SerializeField] private Vector2 _groundCheckPoint = Vector2.zero;
        [SerializeField] private Vector2 _ledgeCheckPoint = Vector2.zero;

        //Debug variables
        [SerializeField] private bool _debugAttack = false;
        [SerializeField] private float _attackRadius = 0f;
        [SerializeField] private Vector2 _attackCenterPoint = Vector2.zero;
        
        private Vector2 _velocity;
        private Vector2 _gravityForce;
        
        private bool _gravityEnabled;
        
        public float Gravity { get; private set; }
        public Rigidbody2D Rb2d { get; private set; }
        public CapsuleCollider2D Collider { get; private set; }
        public AnimationController AnimController { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public CombatController CombatController { get; private set; }
        public Vector2 CurrentVelocity { get; private set; }
        public int DirectionX { get; private set; }
        public int WallDirectionX { get; private set; }

        #region State Machine

        private PlayerStateMachine StateMachine { get; set; }
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
        #endregion

        private void Awake()
        {
            StateMachine = new PlayerStateMachine();
            CombatController = new CombatController();
            
            IdleState        = new PlayerIdleState(this, StateMachine, _playerData, AnimationConstants.PLAYER_IDLE_2_HASH);
            MoveState        = new PlayerMoveState(this, StateMachine, _playerData, AnimationConstants.PLAYER_RUN_2_HASH);
            JumpState        = new PlayerJumpState(this, StateMachine, _playerData, AnimationConstants.PLAYER_JUMP_HASH);
            InAirState       = new PlayerInAirState(this, StateMachine, _playerData, AnimationConstants.PLAYER_AIR_HASH);
            LandState        = new PlayerLandState(this, StateMachine, _playerData, AnimationConstants.PLAYER_LAND_HASH);
            WallSlideState   = new PlayerWallSlideState(this, StateMachine, _playerData, AnimationConstants.PLAYER_WALL_SLIDING_HASH);
            LedgeClimbState  = new PlayerLedgeClimbState(this, StateMachine, _playerData, AnimationConstants.PLAYER_LEDGE_GRAB_HASH);
            LedgeJumpState   = new PlayerLedgeJumpState(this, StateMachine, _playerData, AnimationConstants.PLAYER_LEDGE_JUMP_HASH);
            CrouchIdleState  = new PlayerCrouchIdleState(this, StateMachine, _playerData, AnimationConstants.PLAYER_CROUCH_IDLE_HASH);
            CrouchMoveState  = new PlayerCrouchMoveState(this, StateMachine, _playerData, AnimationConstants.PLAYER_CROUCH_WALK_HASH);
            SwordAttackState = new PlayerSwordAttackState(this, StateMachine, _playerData, AnimationConstants.PLAYER_ATTACK_1_HASH, 3);
            HandAttackState  = new PlayerHandAttackState(this, StateMachine, _playerData, AnimationConstants.PLAYER_PUNCH_1_HASH, 5);
        }

        private void Start()
        {
            Rb2d = GetComponent<Rigidbody2D>();
            Collider = GetComponent<CapsuleCollider2D>();
            AnimController = GetComponent<AnimationController>();
            InputHandler = GetComponent<PlayerInputHandler>();
            DirectionX = 1;
            _gravityEnabled = true;

            Gravity = -(2 * _playerData.MaxJumpHeight) / Mathf.Pow(_playerData.TimeToJumpApex, 2);
            _gravityForce.Set(0f, Gravity);
            
            StateMachine.Initialize(IdleState);
            CombatController.Initialize(this, _playerData);
        }

        private void Update()
        {
            CurrentVelocity = Rb2d.velocity;
            StateMachine.CurrentState.OnUpdate();
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
            CrouchIdleState.Dispose();
            CrouchMoveState.Dispose();
            SwordAttackState.Dispose();
            HandAttackState.Dispose();
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
                
                Gizmos.color = Color.green;
                Gizmos.DrawRay((Vector2) (transform.position) - (Vector2.up), Vector2.up * 1f);

                if (_debugAttack)
                {
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawWireSphere((Vector2) (transform.position) + _attackCenterPoint, _attackRadius);
                }
            }
        }
        
        private void Flip()
        {
            DirectionX *= -1;
            transform.Rotate(0f, 180f, 0f);
        }

        private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
        private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
        
        public bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheckPoint + (Vector2)transform.position, _playerData.GroundCheckRadius, _playerData.GroundCollisionMask);
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
            return Physics2D.Raycast((Vector2) transform.position + _ledgeCheckPoint, 
                Vector2.right * DirectionX, _playerData.LedgeDistanceCheck, _playerData.LedgeCollisionMask);
        }

        public bool CheckForObstaclesAbovePlayer()
        {
            return Physics2D.Raycast(transform.position, Vector2.up, _playerData.CollisionAboveCheckDistance, _playerData.GroundCollisionMask);
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

            RaycastHit2D yHit = Physics2D.Raycast(globalLedgeCheckPos + _velocity, Vector2.down, 1f, _playerData.GroundCollisionMask);

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

        public void ToggleGravity()
        {
            _gravityEnabled = !_gravityEnabled;
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
