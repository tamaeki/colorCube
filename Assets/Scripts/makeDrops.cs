using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeDrops : MonoBehaviour {
	public GameObject drop;
	public GameObject drop2;

	//starts a coroutine that calls a method that instantiates black raindrop objects every 0.1 seconds
	//and another coroutine that instantiates a white raindrop every 1 second
	void Start () {
		StartCoroutine (makeRain());
		StartCoroutine (makeRain2());
	}
	//the black raindrops show up incredibly frequently
	IEnumerator makeRain(){
		while (true) {
			yield return new WaitForSeconds (.1f);
			rainDrops ();
		}
	}
	//white raindrops show up 5x less often
	IEnumerator makeRain2(){
		while (true) {
			yield return new WaitForSeconds (.5f);
			rainDrops2 ();
		}
	}

	//instantiates black rain drop objects
	public void rainDrops(){
		GameObject paintDrop = Instantiate (drop, new Vector3((Random.Range (-4f, 4f)), 6f, 0f), Quaternion.identity) as GameObject;
		paintDrop.name = "drop";
	}
	//instantiates rain drop objects
	public void rainDrops2(){
		GameObject paintDrop2 = Instantiate (drop2, new Vector3((Random.Range (-4f, 4f)), 6f, 0f), Quaternion.identity) as GameObject;
		paintDrop2.name = "drop2";
	}

	void Update () {
		//checks if the left mouse button has been clicked
		//if so, a black raindrop is instantiated at the point where the mouse clicked.
		if (Input.GetMouseButtonDown (0)) {
			Instantiate(drop, Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 1000, Quaternion.identity);
		}
		//checks if the right mouse button has been clicked
		//if so, a white raindrop is instantiated at the point where the mouse clicked.
		if (Input.GetMouseButtonDown (1)) {
			Instantiate(drop2, Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 1000, Quaternion.identity);
		}	
	}

}
