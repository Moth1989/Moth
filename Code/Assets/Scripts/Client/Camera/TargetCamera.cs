using UnityEngine;
using System.Collections;
namespace Moth
{
#if UNITY_EDITOR
	[AddComponentMenu("Moth/Camera/TargetCamera")]
#endif
	
	public class TargetCamera : MonoBehaviour {
		
		[SerializeField]
		private Transform cameraTarget=null;
		private Transform proCameraTarget=null;
		public Transform CameraTarget
		{
			get
			{
				return cameraTarget;
				
			}
			set
			{
				cameraTarget=value;
				if(proCameraTarget==null)
				{
					LookTarget(Target);
				}
				else if(proCameraTarget.position!=cameraTarget.position)
				{
					LookTarget(Target);
				}
				proCameraTarget=cameraTarget;
			}
		}
		private Vector3 Target
		{
			get
			{
				if(CameraTarget==null)
				{
					return Vector3.zero;
				}
				return CameraTarget.position;
			}
		}
		
		private void LookTarget(Vector3 position)
		{
			Quaternion rotation=Quaternion.LookRotation(position-transform.position);
			Vector3 eulerAngles=rotation.eulerAngles;
			eulerAngles.z=0;
			transform.eulerAngles=eulerAngles;
		}
	
#if UNITY_EDITOR
		void OnDrawGizmos()
		{
			LookTarget(Target);
		}
	
		
#endif
	}
}
