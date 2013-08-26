using UnityEngine;
using System.Collections;

namespace Moth
{
	[AddComponentMenu("Moth/Target/Default")]
	public class MothTarget : MothBehaviour , ITarget {
	
		public Vector3 Forward {
			get {
				return transform.forward;
			}
		}
		public Vector3 Position {
			get {
				return transform.position;
			}
		}
		public Quaternion Rotation {
			get {
				return transform.rotation;
			}
		}
		
	}
}
