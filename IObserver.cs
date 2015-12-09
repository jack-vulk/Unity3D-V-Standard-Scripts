using UnityEngine;
using System.Collections.Generic;

namespace Kokychi
{


    public interface IObservee
    {
        void Attach(IObserver observer);

        void Deattach(IObserver observer);

        void Notify();
    }

    public class Observee : IObservee
    {
        #region Attributes

        List<IObserver> _observers = new List<IObserver>();

        #endregion

        void IObservee.Attach(IObserver observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }

        void IObservee.Deattach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        void IObservee.Notify()
        {
            foreach (IObserver observer in _observers)
                observer.Update();
        }
    }

    public interface IObserver
    {
        void Update();
    }
}