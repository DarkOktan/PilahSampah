using UnityEngine;

public class Scoring : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI scoringText;

	public int score;

	private void Start()
	{
		UpdateText();
	}

	public void AddingScore(bool isAnswerTrue)
	{
		score += (isAnswerTrue) ? 25 : -10;

		GameManager.Instance.audioSourceController.PlayOneShot(isAnswerTrue);
		GameManager.Instance.GameOverChecker(score);

		UpdateText();
	}

    public void UpdateText()
	{
		scoringText.text = score.ToString();
	}
}
