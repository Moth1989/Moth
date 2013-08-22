using UnityEngine;

namespace Moth
{
	public interface IInput 
	{
		Vector2 MousePosition{ get ; }
		bool OnPress{get ;}
		bool OnLongPress{get ;}
		bool OnRelease{get ;}
	}
	
}