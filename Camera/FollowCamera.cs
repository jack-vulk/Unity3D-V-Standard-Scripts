using UnityEngine;
using System.Collections;


namespace Kokychi.CameraBehaviours
{
    [RequireComponent(typeof(Camera))]
    public class FollowCamera : ExtendedScipt
    {
        #region Attributes 

        public Transform SetCameraPosition;

        #endregion

        void FixedUpdate()
        {
            this.transform.position = SetCameraPosition.position;

            this.transform.forward = SetCameraPosition.forward;
        }
    }
}