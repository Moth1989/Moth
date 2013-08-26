using UnityEngine;
using System.Collections;

public class EnvironmentManager : MonoBehaviour {

	private bool mLoading = false;
	private GameObject mCurrentEnvironment= null;
	public bool IsLoading
	{
		get
		{
			return mLoading;
		}
	}
	
	public void OnLoadComplete(GameObject obj)
	{
		mCurrentEnvironment=obj;
		mCurrentEnvironment.transform.parent=transform;
		mLoading=false;
	}
		
	public GameObject CurrentEnvironment
	{
		get
		{
			return mCurrentEnvironment;
		}
	}
	
	public bool Load(string SceneName, string BundleName)
	{
		if(SceneName == "" || BundleName =="")
			return false;
		UnLoad();
		mLoading=true;
		LoadFromScene.Request(SceneName,BundleName,OnLoadComplete);
		return true;
	}
	
	public void UnLoad()
	{
		if(mCurrentEnvironment!=null)
		{
			Object.Destroy(mCurrentEnvironment);
			Resources.UnloadUnusedAssets();
		}
		mCurrentEnvironment=null;
	}
}
