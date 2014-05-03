using System;
using UnityEngine;

public enum Exploder{
	Sparkles
}

public enum Weapon{
	LaserBolt
}

public class Connector : MonoBehaviour
{
	static Connector instance;
	static Connector Instance { 
		get { 
			if(instance == null)
				instance = GameObject.Find("Connector").GetComponent<Connector>();

			return instance;
		}
	}

	public GameObject SparkleExplode;

	public static GameObject GetConnection(Exploder x)
	{
		switch(x){
		case Exploder.Sparkles:
			return Instance.SparkleExplode;
		default:
			return null;
		}
	}




	public GameObject LaserBolt;

	public static GameObject GetConnection(Weapon w)
	{
		switch(w){
		case Weapon.LaserBolt:
			return Instance.LaserBolt;
		default:
			return null;
		}


	}

}


