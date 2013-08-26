using UnityEngine;
using System.Collections;

namespace Moth
{
	public enum DevelopmentPhaseType
	{
		Editor, // PC 端开发编辑的时候 ~~
		Debug, // PC 端编辑完测试的时候 ~~
		Release // 根据不同平台发布的时候 ~~
	}
	public enum DevelopmentPlatform
	{
		Window,
		Mac,
		Andorid,
		IPhone
	}
}
