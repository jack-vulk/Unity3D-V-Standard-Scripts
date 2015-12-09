using UnityEngine;
using System.Collections.Generic;


namespace Kokychi.Behaviours.ConditionalBehaviours
{
    public interface IObserverEnable : IObserver
    {
        void UpdateOnEnableNotify();
    }

    public interface IObserveeEnable : IObservee
    {
        void NotifyOnEnable();
    }
    /// <summary>
    /// Extend from OnBehaviourToggled. However, the ObservedBehaviour is observed
    /// via IObserveeEnable interface which provide better performance on checking.
    /// </summary>
    public class OnBehaviourToggledObserved : OnBehaviourToggled, IObserverEnable
    {
        void Awake()
        {
            try
            {
                IObserveeEnable observee = (IObserveeEnable)this.ObservedBehaviour;

                observee.Attach(this);
            }
            catch (System.Exception e)
            {
                Debug.Log(e.ToString() + "from " + this + " and Observed " + this.ObservedBehaviour);
            }
        }

        void LateUpdate()
        {
            // This is to override the behaviour 
            // of OnBehaviourToggled to lessen the performance hit.
        }

        #region IObserverEnable implementation
        void IObserverEnable.UpdateOnEnableNotify()
        {
            if (this.ObservedBehaviour.enabled == OnEnabled)
            {
                this._ConditionMet = true;
            }
            else
            {
                this._ConditionMet = false;
            }
        }

       

        void IObserver.Update()
        {
            ((IObserverEnable)this).UpdateOnEnableNotify();
        }
        #endregion

    }
}