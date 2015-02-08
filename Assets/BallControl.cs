using UnityEngine;
using System.Collections;
//after done, makes the tag for cam 1,2,3 cam 1,2,3 not camera 1,2,3. but now, i must finish
public class BallControl : MonoBehaviour
{

	private bool turn1 = true;
	private bool inZone = false;
	//what we manipulate
	private GameObject football;
	private float startTime=0f;
	private GameObject activeCamera;

	public Camera camera1;
	public Camera camera2;
	public Camera camera3;
	//I AM TOO LAZY TO MAKE A THREAD, so i am using update to count start. alot lol
	void Start(){

		camera1.enabled = true;
		camera2.enabled = false;
		camera3.enabled = false;
	//	activeCamera = GameObject.FindGameObjectWithTag ("Camera1");
		football=GameObject.FindGameObjectWithTag ("Football");

		//football.transform.position =(new Vector3 (1f, 5.1f, 1f));
	//	newRound ();
	}
	//edit speed in the unity engine
	public float speed=1000;
	// called whenever physics happens... ye
	void FixedUpdate ()
	{

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		rigidbody.AddForce (movement*speed*Time.deltaTime);
		//fix laterif (football. == 0) {
		//	Debug.Log ("Switch");
		//}
		//rigidbody.AddExplosionForce (100, movement, 5);
	}

	void Update(){
		float timeNow=Time.time;
	
		if (timeNow - startTime > 20) {
			newRound ();
		}
		if (football.transform.position.y > 0) {
			if (timeNow - startTime > 4 && inZone) {
				Debug.Log ("I DID ITTTTTTTTTTT");
			}
		}
		else{
			newRound ();
		}
	}
	
	void OnTriggerEnter(Collider col){
		//Debug.Log (col.gameObject.tag);
		if (col.gameObject.tag == "MiddleTrigger") {

			if(turn1)
				camera1.enabled=false;
			else
				camera3.enabled=false;
			camera2.enabled=true;
		}
		if (turn1)
		if (col.gameObject.tag == "TriggerArea2") {
			startTime = Time.time;
			inZone = true;
		} else if (!turn1)
		if (col.gameObject.tag == "TriggerArea1") {
			startTime = Time.time;
			inZone = true;
		}
	}

	private void newRound(){
		startTime = Time.time;
		camera2.enabled = false;
		Debug.Log ("u ded");
		inZone=false;
		//switch camerass

		if (turn1) {
			camera1.enabled=true;
		} else {
			camera3.enabled=true;
		}
		camera1.enabled=!camera1.enabled;
		camera3.enabled=!camera3.enabled;

		turn1 = !turn1;
		football.transform.position =(new Vector3 (50f, 50f, 5f));
	}
}