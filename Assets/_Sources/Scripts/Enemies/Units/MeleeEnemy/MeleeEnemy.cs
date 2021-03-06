using _Sources.Scripts.Enemies.Data;
using _Sources.Scripts.Enemies.State_Mashine;
using _Sources.Scripts.Structs;
using UnityEngine;

namespace _Sources.Scripts.Enemies.Units.MeleeEnemy
{
    public class MeleeEnemy : Entity
    {
        public MeleeEnemy_SpawnState SpawnState { get; private set; }
        public MeleeEnemy_IdleState IdleState { get; private set; }
        public MeleeEnemy_MoveState MoveState { get; private set; }
        public MeleeEnemy_PlayerDetectedState PlayerDetectedState { get; private set; }
        public MeleeEnemy_ChargeState ChargeState { get; private set; }
        public MeleeEnemy_MeleeAttackState MeleeAttackState { get; private set; }
        public MeleeEnemy_DamageState DamageState { get; private set; }
        public MeleeEnemy_DeadState DeadState { get; private set; }

        [SerializeField] private D_IdleState idleStateData;
        [SerializeField] private D_MoveState moveStateData;
        [SerializeField] private D_PlayerDetectedState playerDetectedStateData;
        [SerializeField] private D_ChargeState chargeStateData;
        [SerializeField] private D_MeleeAttackState meleeAttackStateData;
        [SerializeField] private D_DamageState damageStateData;
        [SerializeField] private D_DeadState deadStateData;
 
        [SerializeField] private Transform meleeAttackPosition;
    
        public override void Start()
        {
            base.Start();
            SpawnState = new MeleeEnemy_SpawnState(this, StateMachine, "spawn", this);
            IdleState = new MeleeEnemy_IdleState(this, StateMachine, "idle", idleStateData, this);
            MoveState = new MeleeEnemy_MoveState(this, StateMachine, "move", moveStateData, this);
            PlayerDetectedState = new MeleeEnemy_PlayerDetectedState(this, StateMachine, "playerDetected", playerDetectedStateData, this);
            ChargeState = new MeleeEnemy_ChargeState(this, StateMachine, "charge", chargeStateData, this);
            MeleeAttackState = new MeleeEnemy_MeleeAttackState(this, StateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
            DamageState = new MeleeEnemy_DamageState(this, StateMachine, "damage", damageStateData, this);
            DeadState = new MeleeEnemy_DeadState(this, StateMachine, "dead", deadStateData, this);
            StateMachine.Initialize(SpawnState);

  
        }

        public override void Update()
        {
            base.Update();
            //TestTarget.position = PatrolState.MovePos;

        }

        public override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            //Gizmos.DrawWireSphere(StartingPos, patrolStateData.PatrolDistance);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.AttackRadius);
            //Gizmos.DrawLine(AliveGO.transform.position, new Vector2(AliveGO.transform.position.x + MoveState.Direction.x, AliveGO.transform.position.y + MoveState.Direction.y));
        }

        public override void Damage(AttackDetails attackDetails)
        {
            base.Damage(attackDetails);
            Core.CombatSystem.TakeDamage(attackDetails);
            if(Core.HealthSystem.IsDead)
            {
                StateMachine.ChangeState(DeadState);

            }
            else
            {
                StateMachine.ChangeState(DamageState);
            
            }
  
        }
    }
}
