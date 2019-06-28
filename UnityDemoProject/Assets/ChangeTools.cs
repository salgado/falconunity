using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTools : MonoBehaviour {

	// tools options
	public GameObject sugador;
	public GameObject pinca;
	public GameObject bisturi;

	// Use this for initialization
	void Start () {
		SphereManipulator.onFalconButtonPressed +=FalconPressed;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            changeNextTools();
        }
    }

    private void changeNextTools()
    {
        if (!sugador.activeInHierarchy &&
            !pinca.activeInHierarchy)
        {
            //FalconUnity.setForceField(0,new Vector3(0,2,0)); //força para baixo
            PiscaHaptic();  //pisca forca

            sugador.transform.parent.tag = "sugador";
            sugador.SetActive(true);
            pinca.SetActive(false);
            bisturi.SetActive(false);

        }
        else if (!pinca.activeInHierarchy &&
            !bisturi.activeInHierarchy)
        {
            PiscaHaptic();  //pisca forca

            sugador.transform.parent.tag = "pinca";
            sugador.SetActive(false);
            pinca.SetActive(true);
            bisturi.SetActive(false);

        }
        else
        {
            PiscaHaptic();  //pisca forca

            sugador.transform.parent.tag = "bisturi";
            sugador.SetActive(false);
            pinca.SetActive(false);
            bisturi.SetActive(true);

        }
    }

    private static void PiscaHaptic()
    {
        FalconUnity.applyForce(0, new Vector3(1, 1, 1), 0.5f);
    }

    void FalconPressed(int button)
	{
		switch(button){
			case 0:		
				break;
			case 1: 
				changeNextTools();
				break;

			case 2:
				
				break;
			case 3:
				break;
				
		}
	} 
}
