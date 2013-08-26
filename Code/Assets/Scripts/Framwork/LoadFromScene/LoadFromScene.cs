#define NO_SUPPOR_ASYNC_LOAD
using UnityEngine;
using System.Collections;

public class LoadFromScene : MonoBehaviour {
	
	public delegate void OnLoadFinish(GameObject Bundle);
	private static LoadFromScene instance=null;
	private static LoadFromScene Instance
	{
		get
		{
			if(instance==null)
			{
				GameObject loadFromSceneManager=GameObject.Find("LoadFromSceneManager");
				if(loadFromSceneManager==null)
				{
					loadFromSceneManager=new GameObject("LoadFromSceneManager");
				}
				
				instance = loadFromSceneManager.GetComponent<LoadFromScene>();
				if(instance==null)
				{
					instance=loadFromSceneManager.AddComponent<LoadFromScene>();
				}
			}
			return instance;
		}
	}
	
	public static void Request(string SceneName , string BundleName , OnLoadFinish OnLoadDelegate)
	{
		
		Instance.StartCoroutine(Instance.RequestInternal(SceneName,BundleName, OnLoadDelegate));
	}
	
	
	
	private IEnumerator RequestInternal(string SceneName ,string BundleName , OnLoadFinish OnLoadDelegate)
	{
		yield return StartCoroutine(LoadScene(SceneName));
		foreach(GameObject obj 
					in  Object.FindObjectsOfType(typeof(GameObject)) 
					as GameObject[] )
		{
			if(obj.name.ToLower() == BundleName.ToLower() 
				&& obj.transform.parent == null )
			{
				OnLoadDelegate(obj);
				break;
			}
		}
	}
	
	
	
	public IEnumerator LoadScene(string SceneName)
	{
		Debug.Log("Load Scene : " + SceneName);
#if NO_SUPPOR_ASYNC_LOAD
		Application.LoadLevelAdditive(SceneName);
#else
		
#endif
		yield return null;
		
	}
	
}
