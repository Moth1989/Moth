using UnityEngine;
using System.Collections;
namespace Moth
{
	public class MothBehaviour : MonoBehaviour,IInit ,IClear
	{
		public virtual bool Init ()
		{
			return true;
		}
		public virtual void Clear()
		{
			
		}
	}
}
