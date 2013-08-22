using UnityEngine;
using System.Collections;

namespace Moth
{
	public static class FloatExtension 
	{
		public static int FormatToInt(this float f)
		{
			return Mathf.RoundToInt(f);
		}
	}
}
