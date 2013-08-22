//using UnityEngine;
//using System.Collections;
//public class DragCamera : MonoBehaviour {
//
//	public Vector3 GroundPoint=Vector3.zero;
//	public Vector3 GroundNormal=Vector3.up;
//	
//	private Plane GrondPlane;
//
//	private void Start()
//	{
//		GrondPlane=new Plane(GroundNormal,GroundPoint);
//	}
//	private bool isDrag=false;
//	private Vector3 MousePosition=Vector3.zero;
//	private Vector3 DragVector3=Vector3.zero;
//	
//	private InputSystem _input=null;
//	private InputSystem _Input
//	{
//		get
//		{
//			if(_input==null)
//			{
//				_input=InputSystem.Instance;
//			}
//			return _input;
//		}
//	}
//	void Update () {
//		OnDrag();
//	}
//	
//	void OnDrag()
//	{
//		//Debug.LogError("Mouse Position : " +Input.mousePosition );
//		float hitdist;
//		Ray ray;
//		if(_Input.isDraging)
//		{
//			
//			ray=Camera.mainCamera.ScreenPointToRay(new Vector3(_Input.MousePosition.x,_Input.MousePosition.y,0f));
//			Debug.DrawRay(ray.origin,ray.direction,Color.red,1000f);
//			if(isDrag)
//			{
//				GrondPlane.Raycast(ray, out hitdist);
//				Debug.LogError("distance :" + hitdist);
//				Vector3 curClickPoi=ray.GetPoint(hitdist);
//				Vector3 posi=transform.position+MousePosition - curClickPoi;
//				posi=OnLimiInScreen(posi);
//				transform.position=posi;
//			}
//			else if(_Input.isDragBegin)
//			{
//				isDrag=true;
//				GrondPlane.Raycast(ray,out hitdist);
//				MousePosition=ray.GetPoint(hitdist);
//			}
//		}
//		else
//		{
//			isDrag=false;
//		}
//	}
//	
//	private VisiableZone _view=null;
//	public VisiableZone view
//	{
//		get
//		{
//			if(_view==null)
//			{
//				_view =CameraCollector.Instance.GetCameraByName(CameraCollector.GlOBAL_CAMERA).GetComponentInChildren<VisiableZone>();
//				if(_view==null)
//				{
//					Debug.LogError("There Must Set A VisableZone Under The Global Camera");
//				}
//				
//			}
//			return _view;
//		}
//	}
//	
//	Vector3 OnLimiInScreen(Vector3 detal)
//	{
//		if(detal.x>view.TopLeft.position.x)
//		{
//			detal.x=view.TopLeft.position.x;
//		}
//		else if(detal.x<view.BottomRight.position.x)
//		{
//			detal.x=view.BottomRight.position.x;
//		}
//		
//		if(detal.z<view.TopLeft.position.z)
//		{
//			detal.z=view.TopLeft.position.z;
//		}
//		else if(detal.z>view.BottomRight.position.z)
//		{
//			detal.z=view.BottomRight.position.z;
//		}
//		return detal;
//	}
//}
