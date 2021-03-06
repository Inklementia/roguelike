using _Sources.Scripts.Enemies.Data;
using _Sources.Scripts.Enemies.State_Mashine;
using _Sources.Scripts.Enemies.States;

namespace _Sources.Scripts.Enemies.Units.MeleeEnemy
{
    public class MeleeEnemy_IdleState : IdleState
    {
        private MeleeEnemy _enemy;


        public MeleeEnemy_IdleState(Entity entity, FiniteStateMashine stateMachine, string animBoolName, D_IdleState stateData, MeleeEnemy enemy) : 
            base(entity, stateMachine, animBoolName, stateData)
        {
            _enemy = enemy;
        }

        public override void Enter()
        {
            base.Enter();
            _enemy.Core.Movement.StopMovement();
            //_enemy.SetVelocityZero();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (IsPlayerInMinAgroRange)
            {
                StateMachine.ChangeState(_enemy.PlayerDetectedState);
            }
            else if (IsIdleTimeOver)
            {
                //StateMachine.ChangeState(_enemy.PatrolState);
                StateMachine.ChangeState(_enemy.MoveState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
