using UnityEngine;
using System.Collections;

public enum laserColour{
	red,
	green,
	blue,
	yellow
}

public class Contols : MonoBehaviour {

	Vector3 velocity;		//velocity of spaceship
	public float speed; 	//speed factor
	public delegate void LaserAction( laserColour colour );
	public static event LaserAction OnPressed;
	public int width;		//max x movement
	public int height;		//max y movement


	// Init space ship position and velocity
	void Start () {
		transform.localPosition = new Vector3 (0, 0, 0);
		velocity = new Vector3 ( 0, 0, 0);
		speed = 0.01f;
		width = 640;
		height = 480;
	}
	
	// Update is called once per frame
	void Update () {

		updateSpeed ();
		updateRotation ();
		laserButton ();

	}

	void updateSpeed(){

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
			velocity = new Vector3( x, y, z );
		} 
		
		if (Input.GetKey ("s")) {
			print ("s pressed");
			y = -speed;
			velocity = new Vector3( x, y, z );
		}
		
		if (Input.GetKey ("a")) {
			print ("a pressed");
			x = -speed;
			velocity = new Vector3( x, y, z );
		}
		
		if (Input.GetKey ("d")) {
			print("d pressed");
			x = speed;
			velocity = new Vector3( x, y, z );
		}
		
		//update object speed
		transform.localPosition = transform.localPosition + velocity;
	}

	void updateRotation(){

		float smooth = 2.0F;
		float tiltAngle = 30.0F;
		
		float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
		float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
		Quaternion target = Quaternion.Euler(-tiltAroundX, 0, -tiltAroundZ);
		transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smooth);
	}

	void laserButton(){

		if (Input.GetKey ("i") && OnPressed != null){
			OnPressed( laserColour.red );
		}
		
		if (Input.GetKey ("l") && OnPressed != null){
			OnPressed( laserColour.green );
		}
		
		if (Input.GetKey ("k") && OnPressed != null){
			OnPressed( laserColour.blue );
		}
		
		if (Input.GetKey ("j") && OnPressed != null){
			OnPressed( laserColour.yellow );
		}
	}
}
