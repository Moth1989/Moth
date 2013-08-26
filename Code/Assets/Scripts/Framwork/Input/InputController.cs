using UnityEngine;
using System.Collections;

namespace Moth
{
	public class InputController : MothBehaviour , IInput {
		public bool isEnable=true;
		public bool IsEnable
		{
			get
			{
				return isEnable;
			}
			set
			{
				isEnable=value;
			}
		}
		private static InputController controller=null;
		public static InputController Controller
		{
			get
			{
				if(controller==null)
				{
					controller=GameObject.FindObjectOfType(typeof(InputController)) as InputController;
					if(controller==null)
					{
						GameObject go=new GameObject("InputController");
						go.transform.parent=GameManager.Single.transform;
						controller=go.AddComponent<InputController>();
					}
				}
				controller.Init();
				return controller;
			}
		}
		public override bool Init ()
		{
			if(base.Init ())
			{
				mInput=null;
			}
			return false;
		}
		public override void Clear ()
		{
			Init();
		}
		private IInput mInput=null;
		private IInput input
		{
			get
			{
				if(mInput==null)
				{
					switch (GameManager.Single.Phase)
					{
						case DevelopmentPhaseType.Editor:
						{
							mInput = new StandardInput();
							break;
						}
						case DevelopmentPhaseType.Debug:
						{
							mInput = new StandardInput();
							break;
						}
						case DevelopmentPhaseType.Release:
						{
							mInput = new TouchInput();
							break;
						}
						default:
						{
							mInput = new StandardInput();
							break;
						}
					}
				}
				return mInput;
			}
		}
		void OnDestory()
		{
			Clear();
			if(controller==this) controller=null;
		}
		public Vector2 MousePosition {
			get {
				return input.MousePosition;
			}
		}
		public bool OnPressDown {
			get {
				if(!isEnable){ return false; }
				return input.OnPressDown;
			}
		}
		public bool OnPressOn {
			get {
				if(!isEnable){ return false; }
				return input.OnPressOn;
			}
		}
		public bool OnPressUp {
			get {
				if(!isEnable){ return false; }
				return input.OnPressUp;
			}
		}
	}
}
