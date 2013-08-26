using UnityEngine;
using System.Collections;

namespace Moth
{
	public class StandardInput : IInput {
	
		public Vector2 MousePosition {
			get {
				return new Vector2(Input.mousePosition.x,Input.mousePosition.y);
			}
		}
		public bool OnPress {
			get {
				return Input.GetMouseButtonDown(0);
			}
		}
		public bool OnRelease {
			get {
				return Input.GetMouseButtonUp(0);
			}
		}
		public bool OnLongPress {
			get {
				return Input.GetMouseButton(0);
			}
		}
	}
}