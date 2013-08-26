using UnityEngine;
using System.Collections;
namespace Moth
{
	public class PauseBehaviour : MothBehaviour {
		
		
		protected virtual void OnUpdate()
		{
			
		}
		
		public void Update()
		{
			OnUpdate();
		}
	}
	
}