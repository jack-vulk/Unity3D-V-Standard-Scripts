using UnityEngine;
using System.Collections;

namespace Kokychi.Behaviours.Physics
{
    public class Float : ExtendedScipt
    {
        #region Attributes 

        public Transform Target;

        public float HeightFactor = 1.0f;

        public Transform RefPoint = null;        

        #endregion
        
        void Start()
        {
            // Force the target.position 
            // to set Referenced Position 
            if (RefPoint != null)
            {
                float x = this.RefPoint.position.x;

                float y = this.RefPoint.position.y;

                float z = this.RefPoint.position.z;

                this.Target.position = new Vector3(x, y, z);                   
            } 

        } 

        void FixedUpdate()
        {
            try
            {
                float y = Mathf.Sin(Time.time + Time.deltaTime) - Mathf.Sin(Time.time);

                y = HeightFactor * y;

                y += this.Target.position.y;

                float x = this.Target.position.x;

                float z = this.Target.position.z;

                this.Target.position = new Vector3(x, y, z);

            } catch (System.NullReferenceException e)
            {
                Debug.LogWarning(e);
            }
        }
    }
}