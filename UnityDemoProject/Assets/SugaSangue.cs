using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugaSangue : MonoBehaviour {

	// Use this for initialization
	private bool sugando = false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
		if(other.gameObject.tag == "sugador")
		{
			sugando = true;
		}
		
	}

	private void OnTriggerStay(Collider other) {
		Debug.Log("T2 Stay sugando = " + sugando);
		if (sugando)
		{
			float scaleBlood = 0.001f;
			transform.localScale -= new Vector3(scaleBlood, scaleBlood, scaleBlood);
		}
		
	}

	private void OnTriggerExit(Collider other) {
		Debug.Log("T3 Exit");
		PiscaExitHaptic();

		if(other.gameObject.tag == "sugador")
		{
			sugando = false;
		}
	}

	private void OnCollisionEnter(Collider other) {

		Debug.Log("C1 Enter");
		
	}

	private void OnCollisionStay(Collider other) {
		Debug.Log("C2 Stay");
		
	}

	private void OnCollisionExit(Collider other) {
		Debug.Log("C3 Exit");
		
	}
}
