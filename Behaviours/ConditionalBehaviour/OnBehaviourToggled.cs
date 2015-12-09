using UnityEngine;
using System.Collections.Generic;


namespace Kokychi.Behaviours.ConditionalBehaviours
{
    /// <summary>
    /// This behaviour observes the ObservedBehaviour enable status.
    /// When the enable is toggled, the _Condition is checked. 
    /// </summary>
    public class OnBehaviourToggled : ConditionalBehaviour
    {
        #region Field

        /// <summary>
        /// The behaviour to be observed the toggle enable true/false.
        /// </summary>
        public Behaviour ObservedBehaviour = null;

        /// <summary>
        /// If OnEnable is set to true, then the ActionBehaviour will be played
        /// when the ObservedBehaviour is toggled enable true.
        /// </summary>
        public bool OnEnabled = false;

        #endregion

        void LateUpdate()
        {
            if (this.ObservedBehaviour != null)
            {
                if (this.ObservedBehaviour.enabled == OnEnabled)
                {
                    _ConditionMet = true;
                }
            }
        }
    }
}