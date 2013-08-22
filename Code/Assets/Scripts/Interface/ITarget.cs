using UnityEngine;
using System.Collections;

namespace Moth
{
	public interface ITarget 
	{
	
		Vector3 Position{ get ; }
		Quaternion Rotation{ get ;}
		Vector3 Forward{ get ;}
	}
}
