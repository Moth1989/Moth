using UnityEngine;
using System.Collections;

namespace Moth
{
	public class GameManager : MothBehaviour {
		public static string ContainerName="GameManager";
		private static GameObject container=null;
		public static GameObject Container
		{
			get
			{
				if(container==null)
				{
					container=GameObject.Find(ContainerName);
					if(container==null)
					{
						Debug.LogError("Can't Find The GameManager Container");
					}
				}
				
				return container;
			}
		}
		public override void Clear ()
		{
			temp=null;
		}
		void Awake()
		{
			if(single==null) { single=this; }
			if(container==null) {container=this.gameObject; }
		}
		void Start()
		{
			ContainerName=this.gameObject.name;
			
			if(single==null) { single=this; }
			if(container==null) {container=this.gameObject; }
		}
		void OnDestory()
		{
			Clear();
			if(single==this) { single=null; }
			if(container==this.gameObject) {container=null; }
		}
		public override bool Init ()
		{
			if(base.Init())
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private static GameManager single=null;
		public static GameManager Single
		{
			get
			{
				if(single==null)
				{
					single=Container.GetComponent<GameManager>();
				}
				if(single==null)
				{
					single=Container.AddComponent<GameManager>();
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
