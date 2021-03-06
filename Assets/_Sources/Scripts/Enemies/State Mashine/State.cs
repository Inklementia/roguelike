using _Sources.Scripts.Core;
using UnityEngine;

namespace _Sources.Scripts.Enemies.State_Mashine
{
    public class State
    {
        protected FiniteStateMashine StateMachine;
        protected Entity Entity;
        protected EnemyCore Core;

        protected float StartTime;

        protected string AnimBoolName;

        public State(Entity entity, FiniteStateMashine stateMachine, string animBoolName)
        {
            Entity = entity;
            StateMachine = stateMachine;
            AnimBoolName = animBoolName;
            Core = entity.Core;
        }

        public virtual void Enter()
        {
            StartTime = Time.time;
            Entity.Anim.SetBool(AnimBoolName, true);
            Debug.Log(AnimBoolName);
            DoChecks();
        }

        public virtual void Exit()
        {
            Entity.Anim.SetBool(AnimBoolName, false);

        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {

        }
    }
}
