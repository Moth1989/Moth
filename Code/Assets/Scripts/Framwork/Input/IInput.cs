using UnityEngine;

namespace Moth
{
	public interface IInput 
	{
		Vector2 MousePosition{ get; }
		bool OnPressOn{ get; }
		bool OnPressDown{ get; }
		bool OnPressUp{ get;}
	}
	
}