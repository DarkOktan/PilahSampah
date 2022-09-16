using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText, countDownText;

	public float timerCountDown;

	private float _currentTime;

	private void Start()
	{
		_currentTime = timerCountDown;
		ShowingScore();
	}

	private void Update()
	{
		CountDown();
	}

	public void CountDown()
	{
		_currentTime -= Time.deltaTime;
		countDownText.text = $"Back To Main menu in {Mathf.RoundToInt(_currentTime)} second";

		if (_currentTime <= 0)
		{
			GameManager.Instance.LoadSceneSingle(0);
		}
	}

	public void ShowingScore()
	{
		Scoring scoring = FindObjectOfType<Scoring>();
		scoreText.text = $"Score: {scoring.score}";

	}

    public void RetryButton()
	{
		GameManager.Instance.LoadSceneSingle(1);
		GameManager.Instance.audioSourceController.PlayOneShot(true);
	}
}
