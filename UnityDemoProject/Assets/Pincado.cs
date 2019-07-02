using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pincado : MonoBehaviour {

	// Use this for initialization

	public Transform ponta;

	private bool pincando = false;
	private bool pincado = false;

	// escuta os botões do Falcon
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

				break;

			case 2:
				
				break;
			case 3:
				break;
				
		}
	} 

	private void Pincar(GameObject other)
	{
		if ( !pincado )
		{
			FalconUnity.setForceField(0,new Vector3(0,2,0)); //força para baixo

			GetComponent<Rigidbody>().isKinematic = true;
			GetComponent<SphereCollider>().enabled = false;

			transform.position = ponta.position;
			transform.rotation = ponta.rotation;

			transform.SetParent(ponta);
			Debug.Log("colidiu com CELULAS VERMELHAS");

			pincado = !pincado;
			
		}
		

		Debug.Log("colidiu");
	}

    private void SoltarObjeto()
    {
        //celula.transform.position = ponta.position*2;
		if ( pincado )
		{
			FalconUnity.setForceField(0,new Vector3(0,0,0));  //restaura força

			//afasta da ponta
			transform.position = ponta.position + new Vector3(0,-0.5f,0);
			
			transform.SetParent(null);

			gameObject.GetComponent<Rigidbody>().isKinematic = false;
			gameObject.GetComponent<SphereCollider>().enabled = true;
			gameObject.GetComponent<Rigidbody>().useGravity = true;

			pincado = !pincado;

			//estado_celula = "solto";

			// Debug.Log(celula.gameObject.tag);
		}
        
    }

	private static void PiscaEnterHaptic()
    {
		FalconUnity.setForceField(0,new Vector3(1f,1f,1f)); //força para baixo

        //FalconUnity.applyForce(0, new Vector3(2, 2, 2), 0.5f);
    }
	private static void PiscaExitHaptic()
    {
		FalconUnity.setForceField(0,new Vector3(0,0,0)); //restaura força para baixo
        //FalconUnity.applyForce(0, new Vector3(2, 2, 2), 0.5f);
    }

	private void OnTriggerEnter(Collider other) {

		PiscaEnterHaptic();
		Debug.Log("T1 Enter " + other.gameObject.tag);
		if(other.gameObject.tag == "pinca")
		{
			Pincar( other.gameObject);

			pincando = true;
		}
		
	}

	private void OnTriggerStay(Collider other) {
		Debug.Log("T2 Stay pinçando = " + pincando);
		if (pincando)
		{
			//float scaleBlood = 0.001f;
			//transform.localScale -= new Vector3(scaleBlood, scaleBlood, scaleBlood);
			//Destroy( GetComponent("FixedJoint"));



		}
		
	}

	private void OnTriggerExit(Collider other) {
		Debug.Log("T3 Exit");
		PiscaExitHaptic();

		if(other.gameObject.tag == "pinca")
		{
			pincando = false;
		}
	}

}
