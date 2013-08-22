using UnityEngine;
using System.Collections;
namespace Moth
{
	public class Locazition : MothBehaviour 
	{
		public string Language="";
		private static Locazition instance=null;
		public static Locazition Instance
		{
			get
			{
				if(instance==null)
				{
					instance=GameObject.FindObjectOfType(typeof(Locazition)) as Locazition;
					if(instance==null)
					{
						GameObject go=new GameObject("Language");
						instance=go.AddComponent<Locazition>();
					}
				}
				return instance;
			}
		}
	
	}
}