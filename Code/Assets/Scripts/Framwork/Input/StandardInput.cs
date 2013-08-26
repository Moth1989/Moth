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
		public bool OnPressDown {
			get {
				return Input.GetMouseButtonDown(0);
			}
		}
		
		public bool OnPressUp {
			get {
				return Input.GetMouseButtonUp(0);
			}
		}
		
		public bool OnPressOn {
			get {
				return Input.GetMouseButton(0);
			}
		}
	}
}