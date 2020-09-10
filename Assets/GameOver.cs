using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour
{

	void Start()
	{
		gameObject.GetComponent<Text>().enabled = false;
	}

	public void Lose()
	{
		gameObject.GetComponent<Text>().enabled = true;
	}
}
