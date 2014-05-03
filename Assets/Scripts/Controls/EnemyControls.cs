using UnityEngine;
using System.Collections;

public class EnemyControls : MonoBehaviour {

	public float lazorCD;
	public float maxDist;
	Transform heroShip;
	public laserColour laserColor;
	public Vector3 lazorOffset;
	public GameObject lazor;
	public GameObject exploder;
	public bool isLatcher;
	bool dead;

	void Start()
	{

		InvokeRepeating("fireLazor", Random.Range(0, lazorCD), lazorCD);
		heroShip = ((GameObject)GameObject.Find ("Done_Player")).transform;
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.GetComponent<LaserBolt>() != null && collider.GetComponent<LaserBolt>().source == gameObject)
			return;
		//print("BAM! i'm :" + name);
		Damager damager;
		if(dead != null && collider.name != "LatchCollider")
		{
			dead = true;
			//print("Owch " + damager.Damage);
			
			GameObject exploder2 = (GameObject) Instantiate(exploder);
			exploder2.transform.parent = transform;
			exploder2.transform.localPosition = Vector3.zero;
			exploder2.GetComponent<SparkleExplode>().duration = 0.5f;
		}
	}

	void Update(){

		transform.LookAt (heroShip); 
	}

	
	public void fireLazor()
	{
		if (heroShip!= null && Vector3.Distance(transform.position, heroShip.transform.position) < maxDist ) {

			GameObject lazor2 = (GameObject)Instantiate (lazor);
			
			lazor2.transform.position = transform.position + lazorOffset;
			lazor2.transform.rotation = transform.rotation;
			lazor2.transform.rotation = Quaternion.Euler(lazor2.transform.rotation.eulerAngles + new Vector3(Random.Range(0,5),Random.Range(0,5),Random.Range(0,5)));
			lazor2.GetComponent<LaserBolt>().source = gameObject;
			lazor2.GetComponent<LaserBolt>().speed = 3; 

			if(laserColor == laserColour.blue)
				lazor2.renderer.material.SetColor("_Color", Color.blue);
			else if(laserColor == laserColour.red)
				lazor2.renderer.material.SetColor("_Color", Color.red);
			else if(laserColor == laserColour.green)
				lazor2.renderer.material.SetColor("_Color", Color.green);
			else if(laserColor == laserColour.yellow)
				lazor2.renderer.material.SetColor("_Color", Color.yellow);
			
		}
	}
}
