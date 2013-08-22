using UnityEngine;
using System.Collections;

namespace Moth
{
	public class LookTarget :  IInit
	{
		public static void LookAt(Transform heart, Vector3 target)
		{
			Quaternion lookRotation=Quaternion.LookRotation(target-heart.position);
			Vector3 angles=lookRotation.eulerAngles;
			angles.z=0;
			heart.eulerAngles=angles;
		}
		public static void SmoothLookAt(Transform heart,Vector3 target , float slerpValue)
		{
			Quaternion lookRotation=Quaternion.LookRotation(target-heart.position);
			Quaternion tempRotation=Quaternion.Slerp(heart.rotation,lookRotation, slerpValue*Time.deltaTime);
			Vector3 angles=tempRotation.eulerAngles;
			angles.z=0;
			heart.eulerAngles=angles;
		}
		
		public LookTarget()
		{
			Init();
		}
		public bool Init ()
		{
			return false;
		}
		#region SmoothFollow
		
		private bool isFirstOperate=true;
		private Vector3 preTargetPosition=Vector3.zero;
		private void SmoothFollowInit()
		{
			isFirstOperate=true;
		}
		
		public void SmoothFollow(Transform heart,MothTarget target , TargetParams tps)
		{
			Vector3 desTarget;
			if(isFirstOperate)
			{
				preTargetPosition=target.Position;
				desTarget=target.Position;
			}
			else
			{
				desTarget=Vector3.Slerp(preTargetPosition,target.Position,tps.PositionDamping*Time.deltaTime);
				preTargetPosition=desTarget;
			}
			
			#region forwad distance
			
			Quaternion tempDesRotation=target.Rotation;
			//Quaternion tempDesRotation=Quaternion.LookRotation(desTarget-heart.position);
			Quaternion desRotation=Quaternion.Euler(0f,tempDesRotation.eulerAngles.y,0f);
			Quaternion tempRotation;
			if(isFirstOperate)
			{
				tempRotation=desRotation;
				isFirstOperate=false;
			}
			else
			{
				tempRotation=Quaternion.Slerp(heart.rotation,desRotation,tps.RotationDamping*Time.deltaTime);
			}
			Vector3 tempPosition=desTarget-tempRotation*Vector3.forward*tps.ForwardDistance;
			#endregion
			
			#region height
			
			float desHeight=tps.Height+tempPosition.y;
			tempPosition.y=desHeight;
			
			#endregion
			heart.position=tempPosition;
			
			#region LookTarget
			
			Vector3 tempTarget=desTarget;
			tempTarget.y+=tps.TargetHeight;
			
			LookTarget.SmoothLookAt(heart,tempTarget,tps.RotationDamping);
			#endregion
			
			
			
		}
		
		#endregion
	}
	
#if UNITY_EDITOR
	[System.Serializable]
#endif
	public class TargetParams
	{
		public TargetParams(float height , float positionDamping , float forwardDistance , float targetHeight , float rotationDamping)
		{
			_height=height;
			_positionDamping=positionDamping;
			_forwardDistance=forwardDistance;
			_targetHeight=targetHeight;
			_rotationDamping=rotationDamping;
		}
#if UNITY_EDITOR
	[SerializeField]
#endif
		private float _positionDamping=3f;

#if UNITY_EDITOR
		[SerializeField]
#endif
		private float _rotationDamping=2f;
#if UNITY_EDITOR
		[SerializeField]
#endif
		private float _forwardDistance=8f;
		
#if UNITY_EDITOR
		[SerializeField]
#endif
		private float _height=5f;
		
#if UNITY_EDITOR
		[SerializeField]
#endif
		private float _targetHeight=1.5f;
		
		public float ForwardDistance {
			get {
				return this._forwardDistance;
			}
		}

		public float Height {
			get {
				return this._height;
			}
		}

		public float PositionDamping {
			get {
				return this._positionDamping;
			}
		}

		public float RotationDamping {
			get {
				return this._rotationDamping;
			}
		}

		public float TargetHeight {
			get {
				return this._targetHeight;
			}
		}
	}
}
