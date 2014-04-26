using UnityEngine;
using System.Collections;

public class Contols : MonoBehaviour {

	Vector3 velocity;	//velocity of spaceship
	float speed;


	// Init space ship position and velocity
	void Start () {
		transform.position = new Vector3 (0, 0, 0);
		velocity = new Vector3 ( 0, 0, 0);
		speed = 0.01f;
	}
	
	// Update is called once per frame
	void Update () {

		float x = 0;
		float y = 0;
		float z = 0;

		//slows down if no key pressed
		velocity = velocity*0.9f;
		if (velocity.sqrMagnitude < new Vector3(0.01f, 0.01f, 0.01f).sqrMagnitude)
			velocity = new Vector3 (0, 0, 0);


		//handle button presses
		if (Input.GetKey ("w")) {
			print("w pressed");
			y = speed;
			updateSpeed( x, y, z );
		} 

		if (Input.GetKey ("s")) {
			print ("s pressed");
			y = -speed;
			updateSpeed (x, y, z);
		}

		if (Input.GetKey ("a")) {
			print ("a pressed");
			x = speed;
			updateSpeed( x, y, z );
		}

		if (Input.GetKey ("d")) {
			print("d pressed");
			x = -speed;
			updateSpeed( x, y, z );
		}

		//update object speed
		print (transform.position);
		transform.position = transform.position + velocity;
	}

	void updateSpeed(float x, float y, float z){

		velocity = new Vector3( x, y, z );

	}
}
