using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pincar : MonoBehaviour {

	public Transform ponta;
	private float velocidade=2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
 

		float moverX = Input.GetAxis("Horizontal");  
        float moverY = Input.GetAxis("Vertical");  
   
        Vector3 direcaoMovimento = new Vector3 (moverX,moverY);  
  
        transform.Translate (direcaoMovimento * velocidade * Time.deltaTime); 

	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "celulas-vermelhas")
		{
			other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			other.gameObject.GetComponent<SphereCollider>().enabled = false;

			other.transform.position = ponta.position;
			other.transform.rotation = ponta.rotation;

			other.transform.SetParent(ponta);
			Debug.Log("colidiu com CELULAS VERMELHAS");
		}

		Debug.Log("colidiu");
	}
}
