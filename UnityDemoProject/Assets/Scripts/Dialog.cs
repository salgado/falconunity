using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {

	public Text textDisplay;
	public string[] sentences;
	private int index;
	public float typingSpeed;

	public GameObject continueButton;
	public GameObject painel;

	public static bool novaMissao = false;

	// Use this for initialization
	void Start () {
		novaMissao = true;
		StartCoroutine(Type());
	}
	
	void Update()
	{
		if (novaMissao)
		{
			painel.SetActive(true);
			
			if(textDisplay.text == sentences[index])	
			{
				continueButton.SetActive(true);
			}

			if (continueButton.activeSelf)
			{
				if(Input.GetKeyDown(KeyCode.Space))	
				{
					NextSentence();
				}
			}
	
		}
	}
	IEnumerator Type(){
		foreach(char letter in sentences[index].ToCharArray())
		{
			textDisplay.text += letter;
			yield return new WaitForSeconds(typingSpeed);
		}
	}

	public void NextSentence()
	{
		continueButton.SetActive(false);

		if (index < sentences.Length -1)
		{
			index++;
			textDisplay.text = "";
			
			if(sentences[index] == "fechar")
			{
				//fim de missão
				painel.SetActive(false);
				novaMissao = false;
				index++;
			}
			StartCoroutine(Type());
		}
		else
		{
			textDisplay.text = "";
		}
	}
}
