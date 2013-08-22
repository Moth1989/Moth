using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Moth
{
	public class GameProgressManager : MothBehaviour
	{
		private List<GameProgress> GameProgressList=new List<GameProgress>();
		private List<GameProgress> GameProgressPushList=new List<GameProgress>();
		
		private int popCount=0;
		private int topIndex
		{
			get
			{
				return GameProgressList.Count-1;
			}
		}
		public void Push(params GameProgress[] progresses)
		{
			if(progresses!=null&&progresses.Length>0)
			{
				for(int i=0;i<progresses.Length;i++)
				{
					GameProgressPushList.Add(progresses[i]);
					return;
				}
			}
			Debug.LogError("Progress does not exise ; Progress is null");
		}
		public void Pop(int count=1)
		{
			if(GameProgressList.Count>0 && GameProgressList.Count>=(popCount+count))
			{
				popCount+=count;
			}
			return;
		}
		
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
}