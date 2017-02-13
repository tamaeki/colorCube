using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorColor : MonoBehaviour {

	public Color colorStart = Color.white;
	public Color colorEnd = Color.black;
	public float duration = 5.0F;
	public Renderer rend;

	void Start() {
		//need renderer to access the color componenet of objects
		rend = GetComponent<Renderer>();
	}

	void Update() {
		//lerp is a linear transition between two things, in this case white and black
		//mathf.pingpong makes sure that the two colors will transition back and forth
		//in whatever length of time you set and then transitions back to the beginning
		//I learned these two functions for the purpose of this homework assignment because
		//I wanted to show that not only do people absorb negativity into themselves, so does the world.
		//but the world bounces back from good to bad and bad to good
		//it's constantly in motion one way or another
		float lerp = Mathf.PingPong(Time.time, duration) / duration;
		rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
	}
}
