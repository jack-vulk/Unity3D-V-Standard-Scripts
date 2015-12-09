using UnityEngine;
using System.Collections;

namespace Kokychi
{
    /// <summary>
    /// This interface is applied to behaviour which is behaving with the session-kind property.
    /// That's it, it will be tracked on session/progress completion/initialization. 
    /// </summary>
    public interface ISession
    {
        bool IsSessionStarted
        {
            get;
        }

        bool IsSessionEnded
        {
            get;
        }

        void StartSession();

        void EndSession();

        void UpdateSession();        
    }
}