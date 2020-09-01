  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T :MonoBehaviour
{
	static T sing_Object;
	public static T Sing_Object;
	public static T Instance
	{
		get 
		{
			if (sing_Object == null)
			{
				sing_Object = FindObjectOfType<T> ();
			}
			return sing_Object;
		}
	}

}
