using UnityEngine;
using System.Collections;
using Moth;
public class GameProgress : MothBehaviour {

	// GameProgress 第一次放入队列时 执行的初始化操作【添加，以及初始化 】 ~~
	public virtual void OnAdd()
	{
		
	}
	// 资源添加后的，第一次启动 ~~
	public virtual void OnRun()
	{
		
	}
	
	// 让该GameProgress 处于 休眠的状态 ~~ 
	public virtual void OnSuspend()
	{
		
	}
	
	// 从休眠状态唤醒，进入正常运转 ~~
	public virtual void OnResume()
	{
		
	}
	
	// 当该GameProgress 被移除队列的时候，调用， 主要是移除资源 ~~
	public virtual void OnRemove()
	{
		
	}
	
}
