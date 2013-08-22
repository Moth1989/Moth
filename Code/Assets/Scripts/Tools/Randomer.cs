using UnityEngine;
using System.Collections;

public class Randomer 
{
	private float _probability=0f;
	public float Probability
	{
		get
		{
			return _probability;
		}
		set
		{
			if(value>1f)
			{
				_probability=1f;
			}
			else if(value<0f)
			{
				_probability=0f;
			}
			else
			{
				_probability=value;
			}
		}
	}
	
	public Randomer(float probability)
	{
		this._probability=probability;
	}
	private int _seed=0;
	private void OnSow()
	{
		Random.seed+=Time.frameCount+_seed;
		_seed+=Time.frameCount;
		_seed%=int.MaxValue;
	}
	public bool isLucky()
	{
		OnSow();
		int randomValue=Random.Range(0,100);
		if(randomValue<=100*Probability)
		{
			return true;
		}
		return false;
	}
}