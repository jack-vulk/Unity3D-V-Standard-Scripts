using UnityEngine;
using System.Collections.Generic;
using Kokychi;

namespace Kokychi.Behaviours.ConditionalBehaviours
{
    /// <summary>
    /// This behaviour will handle the prerequisite for performing
    /// the set behaviours. 
    /// </summary>
    public class ConditionalBehaviour : ExtendedScipt
    {
        #region Fields
        /// <summary>
        /// This behaviour will be called when the condition is met.
        /// </summary>
        public Behaviour ActionBehaviour = null;

        /// <summary>
        /// This behaviour will be called when the condition is set to not met.
        /// </summary>
        public Behaviour BehaviourOnFail = null;

        private bool _isConditionMet = false;

        /// <summary>
        /// Update on the prerequisite must be performed on this field.
        /// </summary>
        protected bool _ConditionMet
        {
            get
            {
                return this._isConditionMet;
            }
            set
            {
                this._isConditionMet = value;

                if (this._isConditionMet) 
                {
                    // call the ActionBehaviour
                    if (this.ActionBehaviour != null)
                    {
                        this.ActionBehaviour.enabled = true;
                    }
                }
                else 
                {
                    // call the ActionBehaviour on condition's failure
                    if (this.BehaviourOnFail != null)
                    {
                        this.BehaviourOnFail.enabled = true;
                    }
                }
            }
        }

        #endregion
    }
}