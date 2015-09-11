using System;
using UnityEngine;
using System.Collections;
namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;
        public float damping = 10;
        public float lookAheadFactor = 2;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

		Vector3 lookAheadPosition;
		Vector3 lookAheadMaxPosition;
		float lookAheadDis = 1f;
		float lookAheadVelocity = 1;
        // Use this for initialization
        private void Start()
        {

			m_LastTargetPosition = target.position;
			lookAheadPosition = m_LastTargetPosition;
			lookAheadPosition.z = transform.position.z;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;
			damping = 0.5f;
        }

		private void Update()
		{

			Vector3 newPos = target.position;
			newPos.z = -10;
			transform.position = newPos;

			/*
			Vector3 delta = (target.position  - m_LastTargetPosition);

			if (delta.magnitude > 0.01) {
				lookAheadMaxPosition = target.position + delta.normalized * lookAheadDis;

				//lookAheadPosition +=  delta.normalized;
				//lookAheadPosition.z = transform.position.z;
				Vector2 cameraPos = (Vector2)transform.position;



				Vector3 lookAheadPos = target.position + delta.normalized* lookAheadDis;
				Vector3 cameraDelta = ((Vector2)lookAheadPos - cameraPos).normalized * delta.magnitude * 1.4f;

				if((cameraPos + (Vector2)cameraDelta - (Vector2)target.position).magnitude>lookAheadDis)
				{

					lookAheadPos.z = transform.position.z;
					transform.position = lookAheadPos;             

					//transform.position = Vector3.SmoothDamp(transform.position, transform.position+delta.normalized * lookAheadDis, ref m_CurrentVelocity, damping);
				}
				else
				{
					transform.position += cameraDelta;
				}
				//transform.position = Vector3.SmoothDamp (transform.position, lookAheadPosition, ref m_CurrentVelocity, 0.2f); 
			} else {
				//transform.position = Vector3.SmoothDamp (transform.position, lookAheadPosition, ref m_CurrentVelocity, damping);
			}

*/
			/*
			if (delta.magnitude > 0.01f) {

				print(delta);
				print((Vector2)transform.position + delta * 2 - (Vector2)target.position);
				transform.position += Vector3.ClampMagnitude ((Vector2)transform.position + delta * 2 - (Vector2)target.position, 1);

				//print (Vector2.ClampMagnitude (transform.position + delta * 2 - target.position, 1));
			}
*/


			m_LastTargetPosition = target.position;
			//float xMoveDelta = (target.position - m_LastTargetPosition).x;

		}

		/*
        // Update is called once per frame
        private void Update()
        {
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

            transform.position = newPos;

            m_LastTargetPosition = target.position;
        }*/
    }
}
