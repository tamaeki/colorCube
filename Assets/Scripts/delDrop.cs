using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delDrop : MonoBehaviour {

	public Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		
	}
	

	void Update () {
		//if the rain drops spawn off the platform, delete them after a certain height
		if (transform.position.y < -5f)
			Destroy (gameObject);
	}

	//checks to see what the raindrop is colliding with
	//if the collision tag is "flat" then the raindrop is scaled in the x direction slightly
	//to give the appearance of flattening as it collides with a surface
	void OnTriggerEnter2D(Collider2D flat){
		if (flat.tag == "flat") {
			transform.localScale += new Vector3 (.2f, 0f, .5f);
			//the flattened drops would sink through the ground before
			//so in order to keep them stationary
			//the velocity of flattened drops is 0 and gravity is turned off
			rb.velocity = new Vector2 (0f, 0f);
			rb.gravityScale = 0;
			rb.isKinematic = false;
		}

		//if the collision tag is "change" the raindrop will disappear on collision
		//while the cube gets darker in color
		//the idea was that the cube is absorbing the negativity/darkness of the drops
		if (flat.tag == "change") {
			Destroy (gameObject);
		}
	}

}
