using UnityEngine;
using System.Collections;
using Moth;
public class LookTargetTest : MonoBehaviour {
	
	public TargetParams tp=null;
	private LookTarget lt=null;
	public MothTarget t=null;
	void Start()
	{
		lt=new LookTarget();
	}
	void Update()
	{
		lt.SmoothFollow(transform , t ,tp);
	}
}
