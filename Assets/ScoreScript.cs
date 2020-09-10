using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour
{

	private int score = 0;

	void Start()
	{
		GetComponent<Text>().text = "SCORE: " + score.ToString();
	}

	public void ScoreUp(int point)
	{
		score += point;
		GetComponent<Text>().text = "SCORE: " + score.ToString();
	}
}
