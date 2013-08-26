using UnityEngine;
using System.Collections;

namespace Moth
{
	//游戏运行之后，需要存储的一些临时数据~~
	public class GameTempData : IInit{
	
			//数据的初始化操作，只在游戏启动刚开始执行一次~~
			public bool Init ()
			{
				return true;
			}
	}
	
}