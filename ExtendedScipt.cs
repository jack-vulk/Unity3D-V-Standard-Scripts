using UnityEngine;
using System.Collections.Generic;
using System;

namespace Kokychi
{
    public class ExtendedScipt : MonoBehaviour, IObservee
    {
        #region Attributes 

        Observee _observee = new Observee();

        #endregion 

        protected void Awake()
        {   
             Notify();
        }


        void IObservee.Attach(IObserver observer)
        {
            ((IObservee)_observee).Attach(observer);
        }

        public void OnEnable()
        {
            Notify();
        }

        public void OnDisable()
        {
            Notify();
        }

        void IObservee.Deattach(IObserver observer)
        {
            ((IObservee)_observee).Deattach(observer);
        }

        public void Notify()
        {
            ((IObservee)_observee).Notify();
        }
    }
}