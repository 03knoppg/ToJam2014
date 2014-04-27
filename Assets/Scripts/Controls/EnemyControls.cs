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

	void Start()
	{

		InvokeRepeating("fireLazor", 0, lazorCD);
		heroShip = ((GameObject)GameObject.Find ("Done_Player")).transform;
	}

	void OnTriggerEnter(Collider collider)
	{
		print("BAM! i'm :" + name);
		Damager damager;
		if((damager = collider.gameObject.GetComponent<Damager>()) != null)
		{
			print("Owch " + damager.Damage);
			
			GameObject exploder2 = (GameObject) Instantiate(exploder);
			exploder2.transform.parent = transform;
			exploder2.transform.localPosition = Vector3.zero;
			
		}
	}

	void Update(){

		transform.LookAt (heroShip); 
	}
	
	/*void fireRandomLazor()
	{
		fireLazors((laserColour)((int)(Random.Range(0, 4))));
	}*/
	
	public void fireLazor()
	{
		if (heroShip!= null && Vector3.Distance(transform.position, heroShip.transform.position) < maxDist ) {

			GameObject lazor2 = (GameObject)Instantiate (lazor);
			
			lazor2.transform.position = transform.position + lazorOffset;
			lazor2.transform.rotation = transform.rotation;
			
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
