using System;
using _Sources.Scripts.Core.Components;
using DG.Tweening;
using UnityEngine;

namespace _Sources.Scripts.Core
{
    public class PlayerCore : Core
    {
        public EnemyDetectionSenses EnemyDetectionSenses { get; private set; }
        public EnergySystem EnergySystem { get; private set; }
        public ShieldSystem ShieldSystem { get; private set; }
        public PlayerCombatSystem PlayerCombatSystem { get; private set; }

        protected override void Awake()
        {
            
            base.Awake();
            DOTween.SetTweensCapacity(2000, 100);
            
            
            EnemyDetectionSenses = GetComponentInChildren<EnemyDetectionSenses>();
            EnergySystem = GetComponentInChildren<EnergySystem>();
            ShieldSystem = GetComponentInChildren<ShieldSystem>();
            PlayerCombatSystem = GetComponentInChildren<PlayerCombatSystem>();
            
            if (!EnemyDetectionSenses)
            {
                Debug.LogError("Missing Senses Component");
            }

        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            ShieldSystem.LogicUpdate();
        }
    }
}
