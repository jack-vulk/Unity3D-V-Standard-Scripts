using UnityEngine;
using System.Collections.Generic;
using Kokychi;

namespace Kokychi.Behaviours.ConditionalBehaviours
{
    /// <summary>
    /// This behaviour observes a behaviour handled with ISession interface.
    /// <para>When the observed behaviour ends its session, this behaviour will call the ActionBehaviours.</para>
    /// </summary>
    public class OnBehaviourEnded : ConditionalBehaviour, IObserver
    {
        #region Attributes
        /// <summary>
        /// The behaviour is observed and handled by this Sequence Behaviour.
        /// </summary>
        public Behaviour ObservedBehaviour = null;

        #endregion

        #region Init

        protected new void Awake()
        {
            try
            {

                this._observedBehaviour = (IObservee)this.ObservedBehaviour;

                this._observedBehaviour.Attach(this);
            }
            catch (System.Exception e)
            {
                if (e is System.InvalidCastException)
                {
                    
                } else if (e is System.NullReferenceException)
                {
                    

                    
                }
            }
        }
        #endregion

        #region IObserver implementation

        private IObservee _observedBehaviour = null;        

        void IObserver.Update()
        {

            Behaviour currentBehaviour = ObservedBehaviour;

            try
            {
                ISession progress = (ISession)currentBehaviour;

                if (progress.IsSessionEnded)
                {
                    this._ConditionMet = true;
                }
                else
                {
                    this._ConditionMet = false;
                }
            }
            catch (System.InvalidCastException e)
            {
                Debug.Log("Couldn't cast " + "IProgressTrackedBehaviour" + " from the ObservedBehaviour. Error Log: " + e);
            }

        }
        #endregion
    }
}