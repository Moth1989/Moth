using UnityEngine;
using System.Collections;

namespace Moth
{
	public class GameContainer : MothBehaviour {
	
		public static string MANAGER="GameManager";
		private static GameObject managerContainer=null;
		public static GameObject ManagerContainer
		{
			get
			{
				if(managerContainer==null)
				{
					managerContainer=GameObject.Find(MANAGER);
				}
				if(managerContainer==null)
				{
					managerContainer=new GameObject(MANAGER);
				}
				return managerContainer;
			}
		}
	}
}
