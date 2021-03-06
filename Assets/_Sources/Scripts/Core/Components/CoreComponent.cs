using JetBrains.Annotations;
using UnityEngine;

namespace _Sources.Scripts.Core.Components
{
    public class CoreComponent : MonoBehaviour
    {
        protected Core Core;
        [CanBeNull] protected PlayerCore PlayerCore;
        protected virtual void Awake()
        {
            Core = transform.parent.GetComponent<Core>();
            PlayerCore = transform.parent.GetComponent<PlayerCore>();
            if (Core == null)
            {
                Debug.LogError("No Core on the parent");
            }
       
        }

        protected virtual void Start()
        {
            
        }
    }
}
