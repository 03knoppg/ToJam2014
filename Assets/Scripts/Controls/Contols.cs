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
	public float width;		//max x movement
	public float height;		//max y movement


	// Init space ship position and velocity
	void Start () {
		transform.localPosition = new Vector3 (0, 0, 0);
		velocity = new Vector3 ( 0, 0, 0);
		speed = 0.025f;
		//width = 2;
		//height = 2;
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
		
		//handle direction button presses
		if (Input.GetKey ("w")) {
			//print("w pressed");
			if (transform.localPosition.y < height){
				y = speed;
				velocity = new Vector3( x, y, z );
			}
		} 
		
		if (Input.GetKey ("s")) {
			//print ("s pressed");
			if (transform.localPosition.y > -height){
				y = -speed;
				velocity = new Vector3( x, y, z );
			}
		}
		
		if (Input.GetKey ("a")) {
			//print ("a pressed");
			if (transform.localPosition.x > -width){
				x = -speed;
				velocity = new Vector3( x, y, z );
			}
		}
		
		if (Input.GetKey ("d")) {
			//print("d pressed");
			if (transform.localPosition.x < width){
				x = speed;
				velocity = new Vector3( x, y, z );
			}
		}

		//stops if close to boarder
		//if (transform.localPosition.x > width || transform.localPosition.x < -width || transform.localPosition.y > height || transform.localPosition.y < - height ) {
		//	velocity = new Vector3 (0, 0, 0);
		//}
		
		//update object speed
		transform.localPosition = transform.localPosition + velocity;
		print (transform.localPosition);
	}

	void updateRotation(){
		//make ship point in movement direction
		float smooth = 2.0F;
		float tiltAngle = 30.0F;

		//get input axis
		float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
		float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

		//move object based on movements
		Quaternion target = Quaternion.Euler(-tiltAroundX, -tiltAroundZ+2, -tiltAroundZ);
		transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smooth);
	}

	void laserButton(){
		//handle weapon key presses. passes msg to Graham's laser functions
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
