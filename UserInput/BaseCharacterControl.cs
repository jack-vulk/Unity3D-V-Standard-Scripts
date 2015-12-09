using UnityEngine;
using System.Collections;

namespace Kokychi.UserInput
{
    public class BaseCharacterControl : ExtendedScipt
    {
        #region Attributes

        public float ForwardSpeed = 1.0f;
        public float BackwardSpeed = 1.0f;
        public float HorizontalSpeed = 1.0f;

        public float JumpForce = 1.0f;

        public Animator Animator = null;
        public Rigidbody RigidBody = null;
        private Animator _anim = null;
        private Rigidbody _rig = null;

        protected Animator _RefAnimator
        {
            get
            {
                return _anim;
            }
        }
        protected Rigidbody _RefRigidBody
        {
            get
            {
                return _rig;
            }
        }
            
        protected void Start()
        {
            if (Animator != null)
            {
                _anim = Animator;
            } else
            {
                _anim = GetComponent<Animator>();
            }

            if (RigidBody != null)
            {
                _rig = RigidBody;
            } else
            {
                _rig = GetComponent<Rigidbody>();
            }
        }
        #endregion 
    }
}