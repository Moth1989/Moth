using UnityEngine;
using System.Collections;


namespace Moth
{
	public interface IInit {
		
		bool Init();
	}
	
	public interface IClear
	{
		void Clear();
	}
	
	public interface ITarget 
	{
	
		Vector3 Position{ get ; }
		Quaternion Rotation{ get ;}
		Vector3 Forward{ get ;}
	}
}