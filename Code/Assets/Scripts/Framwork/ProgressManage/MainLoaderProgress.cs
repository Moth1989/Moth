using UnityEngine;
using System.Collections;
using Moth;
public class MainLoaderProgress : GameProgress 
{
	void Start()
	{
		GameProgressManager.Instance.Push(this);
	}
}

