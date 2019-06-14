using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pincar : MonoBehaviour {

	public Transform ponta;
	private float velocidade=2;
	private Collision celula;
	private String estado_celula = "solto";

	// Use this for initialization
	void Start () {
		SphereManipulator.onFalconButtonPressed +=FalconPressed;
	}
	
	void FalconPressed(int button)
	{
		switch(button){
			case 0:		
				Debug.Log("OPA!!!! Botao 0 Pressionado");
				SoltarObjeto();
				
				break;
			case 1: 
				Debug.Log("OPA!!!! Botao 1 Pressionado");

				break;

			case 2:
				
				break;
			case 3:
				break;
				
		}
	} 
	// Update is called once per frame
	void Update () {
 

		float moverX = Input.GetAxis("Horizontal");  
        float moverY = Input.GetAxis("Vertical");  
   
        Vector3 direcaoMovimento = new Vector3 (moverX,moverY);  
  
        transform.Translate (direcaoMovimento * velocidade * Time.deltaTime); 

		if (Input.GetKeyDown(KeyCode.Space))
        {
            SoltarObjeto();
        }

    }

    private void SoltarObjeto()
    {
        //celula.transform.position = ponta.position*2;
		if (celula != null)
		{
			FalconUnity.setForceField(0,new Vector3(0,0,0));  //restaura força

			celula.transform.SetParent(null);

			celula.gameObject.GetComponent<Rigidbody>().isKinematic = false;
			celula.gameObject.GetComponent<SphereCollider>().enabled = true;
			celula.gameObject.GetComponent<Rigidbody>().useGravity = true;


			//estado_celula = "solto";

			Debug.Log(celula.gameObject.tag);
		}
        
    }

    void OnCollisionEnter(Collision other)
	{
		if ( (other.gameObject.tag == "celulas-teste") && 
			(estado_celula == "solto"))
		{
			FalconUnity.setForceField(0,new Vector3(0,2,0)); //força par baixo

			other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			other.gameObject.GetComponent<SphereCollider>().enabled = false;

			other.transform.position = ponta.position;
			other.transform.rotation = ponta.rotation;

			other.transform.SetParent(ponta);
			Debug.Log("colidiu com CELULAS VERMELHAS");

			celula = other;
			estado_celula = "preso";
		}

		Debug.Log("colidiu");
	}

	void OnCollisionExit(Collision other)
	{
			estado_celula = "solto";
		
	}
}
