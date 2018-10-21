using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
	namespace PlayerController
	{
        [System.Serializable]
		public class GroundSystem 
		{
			[SerializeField]
            Color rayColor;
            [SerializeField, Range(0.1f, 10f)]
            float rayLenght = 0.5f;
            [SerializeField]
            LayerMask groundLayer;
            [SerializeField]
            Vector3 startPosition;

			public Vector3 StartPosition
            {
                get
                {
                    return startPosition;
                }
            }
            public bool CheckGround(Transform transform)
            {
                return Physics.Raycast((Vector3)transform.position + startPosition, Vector3.down, rayLenght,groundLayer);
            }

            public void DrawRay(Transform transform)
            {
                Gizmos.color = rayColor;
                Gizmos.DrawRay((Vector3)transform.position + startPosition,Vector3.down*rayLenght);
                //Debug.DrawRay((Vector3)transform.position + startPosition, (Vector3)transform.TransformDirection(Vector3.down) * rayLenght);
            }

            
		}	
	}
}

