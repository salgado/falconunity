using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corte : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
	{
		Debug.Log("colidiu!!!!!");

		if ((other.gameObject.tag == "pinca"))
		{
			Destroy(transform);
			Debug.Log("cortou!!!!!");
		}
	}

}
