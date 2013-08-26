using UnityEngine;
using System.Collections;

namespace Moth
{
	public class GameManager : MothBehaviour {
		
		private static GameManager single=null;
		public static GameManager Single
		{
			get
			{
				if(single==null)
				{
					single=GameContainer.ManagerContainer.GetComponent<GameManager>();
				}
				if(single==null)
				{
					single=GameContainer.ManagerContainer.AddComponent<GameManager>();
				}
				return single;
			}
		}
#if UNITY_EDITOR
		[SerializeField]
#endif
		private DevelopmentPhaseType phase=DevelopmentPhaseType.Editor;
		public DevelopmentPhaseType Phase
		{
			get
			{
				return phase;
			}
		}
		
		private GameTempData temp=null;
		public GameTempData Temp
		{
			get
			{
				if(temp==null)
				{
					temp=new GameTempData();
					temp.Init();
				}
				return temp;
			}
		}
	}
}
