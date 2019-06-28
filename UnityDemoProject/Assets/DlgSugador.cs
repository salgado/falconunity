using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DlgSugador : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space ))
        {
            hideMenu();
        }
    }

	void hideMenu()
	{
		transform.gameObject.SetActive(!transform.gameObject.activeInHierarchy);
	}

}
