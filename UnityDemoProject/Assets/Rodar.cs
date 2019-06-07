using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rodar : MonoBehaviour {

	bool rodando = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//rodar();	
		if (Input.GetKeyDown(KeyCode.Space))
		{
			rodando = !rodando;
		}

		rodar();
		
	}

	public void rodar()
	{
		
		if (rodando)
		{
			transform.Rotate ( new Vector3(0,Time.deltaTime*-880,0) );			
			Debug.Log("Rodando Objeto");
		}
		
	}
}
