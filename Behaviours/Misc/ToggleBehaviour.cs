using UnityEngine;
using System.Collections;

namespace Kokychi.Behaviours.Misc
{
    public class ToggleBehaviour : ExtendedScipt
    {
        #region Field

        /// <summary>
        /// The behaviours to be toggled on/off
        /// </summary>
        public Behaviour TargetBehaviour = null;

        private Behaviour _targetBehaviour = null;

        protected virtual Behaviour _TargetBehaviour
        {
            get
            {
                if (this._targetBehaviour == null)
                {
                    if (this.TargetBehaviour != null)
                    {
                        this._targetBehaviour = this.TargetBehaviour;
                    }
                    else
                    {
                        // in inheritance
                    }
                }
                return this._targetBehaviour; 
            }
        }

        /// <summary>
        /// Toggle the behaviour on.
        /// </summary>
        public bool ToggleOn = false;

        #endregion

        /// <summary>
        /// This behaviour only run once on behaviour startup.
        /// <para>To run the behaviour again, toggle it off then on.</para>
        /// </summary>
        void Start()
        {
            if (this._TargetBehaviour != null)
            {
                this._TargetBehaviour.enabled = ToggleOn;

                this.enabled = false;
            }
        }

        protected new void OnEnable()
        {
            base.OnEnable();

            this.Start();
        }


    }
}