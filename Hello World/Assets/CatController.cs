using UnityEngine;
using System.Collections;

public class CatController : MonoBehaviour {

	public float moveSpeed;
	private Vector3 moveDirection;
	private bool isRed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 currentPosition = transform.position;
		
		if (Input.GetButton ("Fire1")) {
			
			Vector3 moveToward = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			
			moveDirection = moveToward - currentPosition;
			moveDirection.z = 0;
			moveDirection.Normalize();
			
		}
		
		Vector3 target = moveDirection * moveSpeed + currentPosition;
		transform.position = Vector3.Lerp (currentPosition, target, Time.deltaTime);

	
		if (Input.GetKeyDown (KeyCode.P)) {
		
			gameObject.GetComponent<Renderer>().material.color = Color.red;
		}


	}


	void OnMouseDown() {
		if (isRed == false) {
			gameObject.GetComponent<Renderer> ().material.color = Color.red;
			isRed = true;
		}
		else if (isRed == true) {
			gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			isRed = false;
		}

		/*if (gameObject.GetComponent<Renderer> ().material.color == Color.blue) 
		{
			gameObject.GetComponent<Renderer> ().material.color = Color.red;
		}
		else if (gameObject.GetComponent<Renderer> ().material.color == Color.red) 
		{
			gameObject.GetComponent<Renderer> ().material.color = Color.blue;
		}
*/

	}
}
