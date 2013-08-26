using UnityEngine;
using System.Collections;
using Moth;
public class DragCamera : MonoBehaviour {

	public Vector3 GroundPoint=Vector3.zero;
	public Vector3 GroundNormal=Vector3.up;
	
	private Plane GrondPlane;

	private void Start()
	{
		GrondPlane=new Plane(GroundNormal,GroundPoint);
	}
	private Vector3 FirstPressPosition=Vector3.zero;
	private Vector3 UpdatePressPosition=Vector3.zero;

	private InputController input
	{
		get{
			return InputController.Controller;
		}
	}
	void Update () 
	{
		OnDrag();
	}
	
	void OnDrag()
	{
		float hitDist;
		Ray ray;
		if(input.OnPressOn)
		{
			ray=Camera.mainCamera.ScreenPointToRay(new Vector3(input.MousePosition.x,input.MousePosition.y,0f));
			if(input.OnPressDown)
			{
				GrondPlane.Raycast(ray,out hitDist);
				FirstPressPosition=ray.GetPoint(hitDist);
			}
			else
			{
				GrondPlane.Raycast(ray, out hitDist);
				UpdatePressPosition=ray.GetPoint(hitDist);
				Vector3 posi=transform.position + FirstPressPosition - UpdatePressPosition;
				transform.position=posi;
			}
		}
	}
}
