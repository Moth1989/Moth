using UnityEngine;
using System.Collections;

namespace Moth
{
	public class TouchInput : IInput {
	
		public Vector2 MousePosition {
			get {
				return Input.GetTouch(0).position;
			}
		}
		public bool OnPressOn {
			get {
				if(Input.touchCount>1) return false;
				TouchPhase phase=Input.GetTouch(0).phase;
				return phase==TouchPhase.Stationary||phase==TouchPhase.Moved;
			}
		}
		public bool OnPressDown {
			get {
				if(Input.touchCount>1) return false;
				return Input.GetTouch(0).phase==TouchPhase.Began;
			}
		}
		public bool OnPressUp {
			get {
				if(Input.touchCount>1) return false;
				return Input.GetTouch(0).phase==TouchPhase.Ended;
			}
		}
	}
}
