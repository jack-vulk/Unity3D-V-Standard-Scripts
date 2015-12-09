using UnityEngine;
using System.Collections.Generic;

namespace Kokychi.Behaviours.ConditionalBehaviours
{

    /// <summary>
    /// This behaviour observes ISession Behaviours.
    /// <seealso cref="OnBehaviourEnded"/>
    /// </summary>
    public class OnBehavioursEnded : ConditionalBehaviour, IObserver
    {
        #region Field

        /// <summary>
        /// The observed ISession behaviours
        /// </summary>
        public List<Behaviour> ObservedBehaviours = new List<Behaviour>();

        #endregion

        #region Init

        void Awake()
        {
            foreach (MonoBehaviour behaviour in this.ObservedBehaviours)
            {
                try
                {
                    IObservee observee = (IObservee)behaviour;

                    observee.Attach(this);
                }
                catch (System.InvalidCastException e)
                {
                    Debug.Log("Ignoring the behaviour " + e);
                }
            }

        }

        #endregion

        #region IMonoBehaviourObservers implementation

       

        void IObserver.Update()
        {
            bool isNotFinishedFound = false;

            foreach (MonoBehaviour behaviour in this.ObservedBehaviours)
            {
                try
                {
                    ISession session = (ISession)behaviour;

                    if (!session.IsSessionEnded)
                    {
                        isNotFinishedFound = true;
                        break;
                    }
                }
                catch (System.InvalidCastException e)
                {
                    Debug.Log("Ignoring this behaviour " + e);
                }
            }

            if (isNotFinishedFound == false)
            {
                this._ConditionMet = true;
            }
            else
            {
                this._ConditionMet = false;
            }
        }
        #endregion
    }
}