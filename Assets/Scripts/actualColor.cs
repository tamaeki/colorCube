using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actualColor : MonoBehaviour {
	public GameObject bigCube;
	public Renderer rend;
	private int j;
	public Color[] cubes;


	void Start () {
		//need the renderer to change the color of the cubes
		rend = GetComponent<Renderer>();
		rend.enabled = true;
	
	}
	//checks if any of the small cubes have reached the max darkness
	//if so, they are dropped from the scene and fall down through the platform
	//I wanted the darkest parts of the cube to fall through the platform because
	//people often lose parts of themselves without realizing
	//and it's usually from some kind of societal pressures
	void Update () {
		if (rend.material.color == cubes [19]) {
			transform.position = new Vector2 (transform.position.x, transform.position.y - .2f);
		}
	}

	//if a raindrop collides with a box collider around any of the mini cubes
	//increment the darkness of that cube's color by one level
	//all the box colliders for each of the small cubes is exactly the same size
	//and they are all placed on top of each other
	//i have no idea how unity decides which cube to make darker if all the colliders are overlapping
	void OnTriggerEnter2D(Collider2D hit){
		if ((hit.tag == "change")&&(j<20)){
			j++;
			rend.material.color = cubes [j];

			//Debug.Log (j);
		}
		//if a white droplet hits any of the cubes, the darkness is alleviated by one level
		//you can't go past the lightness of the color the cube originally started at though
		if ((hit.tag == "changeGood")&&(j>0)) {
			j--;
			rend.material.color = cubes[j];
		}
	}
}