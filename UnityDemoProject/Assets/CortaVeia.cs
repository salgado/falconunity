using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CortaVeia : MonoBehaviour {

	// Use this for initialization
	private bool cortando = false;

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
		if(other.gameObject.tag == "bisturi")
		{
			cortando = true;
		}
		
	}

	private void OnTriggerStay(Collider other) {
		Debug.Log("T2 Stay sugando = " + cortando);
		if (cortando)
		{
			//float scaleBlood = 0.001f;
			//transform.localScale -= new Vector3(scaleBlood, scaleBlood, scaleBlood);
			Destroy( GetComponent("FixedJoint"));

		}
		
	}

	private void OnTriggerExit(Collider other) {
		Debug.Log("T3 Exit");
		PiscaExitHaptic();

		if(other.gameObject.tag == "bisturi")
		{
			cortando = false;
		}
	}


}
