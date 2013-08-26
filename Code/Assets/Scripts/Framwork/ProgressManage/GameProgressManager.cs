using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Moth;
public class GameProgressManager:MothBehaviour
{
	private static GameProgressManager instance=null;
	public static GameProgressManager Instance
	{
		get
		{
			if(instance==null)
			{
				instance=GameManager.Container.GetComponent< GameProgressManager >();
				if(instance==null)
				{
					instance=GameManager.Container.AddComponent< GameProgressManager >();
				}
			}
			instance.Init();
			return instance;
		}
	}
	public override bool Init ()
	{
		if(base.Init())
		{
			GameProgressList=new List<GameProgress>();
			GameProgressPushList=new List<GameProgress>();
			popCount=0;
			return true;
		}
		return false;
	}
	
	public override void Clear ()
	{
		GameProgressList=null;
		GameProgressPushList=null;
		popCount=0;
	}
	void Awake()
	{
		if( instance == null ) { instance = this; }
	}
	void Start()
	{
		if( instance == null ) { instance = this; }
	}
	void OnDestroy()
	{
		Clear();
		if( instance == this ) { instance = null; }
	}
	// 检查进程是否已经在队列之中 rr
	public bool IsProgressOnStack(GameProgress progress)
	{
		return GameProgressList.Contains(progress);
	}
	// 最后放入的进程 rr
	public GameProgress LastProgree
	{
		get
		{
			return GameProgressList[topIndex];
		}
	}
	// 游戏进程队列 rr
	private List<GameProgress> GameProgressList=null;
	// 等待放入游戏进程的队列 rr
	private List<GameProgress> GameProgressPushList=null;
	
	// 需要从游戏进程队列中抛弃的进程数量 rr
	private int popCount=0;
	// 游戏队列的最后一个元素 rr
	private int topIndex
	{
		get
		{
			return GameProgressList.Count-1;
		}
	}
	// 将要放入游戏进程队列的进程,放入等待队列中, 等待放入游戏进程队列 rr
	public void Push(params GameProgress[] progresses)
	{
		if(progresses!=null&&progresses.Length>0)
		{
			for(int i=0;i<progresses.Length;i++)
			{
				if(!IsProgressOnStack(progresses[i]))
				{
					GameProgressPushList.Add(progresses[i]);
				}
				else
				{
					Debug.LogError(progresses[i].name + "Can't Add Twice .");
				}
			}
			return;
		}
		Debug.LogError("Progress does not exise ; Progress is null");
	}
	
	// 根据提供的数量,自动释放游戏进程中最近放入的进程 rr
	public void Pop(int count=1)
	{
		if(GameProgressList.Count>0 && GameProgressList.Count>=(popCount+count))
		{
			popCount+=count;
		}
		return;
	}
	
	// 自动更新游戏进程队列 rr
	void Update()
	{
		if(popCount>0)
		{
			GameProgressList[topIndex].OnSuspend();
			GameProgressList[topIndex].OnRemove();
			GameProgressList.RemoveAt(topIndex);
			if(GameProgressList.Count>=1)
			{
				GameProgressList[topIndex].OnResume();
			}
			popCount--;
		}
		else if(GameProgressPushList.Count>0)
		{
			if(GameProgressList.Count>=1)
				GameProgressList[topIndex].OnSuspend();
			GameProgressList.Add(GameProgressPushList[0]);
			GameProgressPushList.RemoveAt(0);
			GameProgressList[topIndex].OnAdd();
			GameProgressList[topIndex].OnRun();

		}
	}
	
}