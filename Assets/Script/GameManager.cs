using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singletons
    public static GameManager Instance;

    void MakeInstance()
	{
		if (Instance)
		{
            Destroy(gameObject);
		}
		else {
            DontDestroyOnLoad(gameObject);
            Instance = this;
		}
	}

	private void Awake()
	{
		MakeInstance();
	}
	#endregion

	public AudioSourceController audioSourceController;

	public bool IsMoving = true;

	public void LoadSceneSingle(int buildIndex)
	{
		SceneManager.LoadScene(buildIndex);
	}
	public void LoadSceneAdditive(int buildIndex)
	{
		SceneManager.LoadScene(buildIndex, LoadSceneMode.Additive);
	}

	public void GameOverChecker(int currentScore)
	{
		if (currentScore >= 150) {
			IsMoving = false;
			LoadSceneAdditive(2);
		}else if (currentScore <= -5)
		{
			IsMoving = false;
			LoadSceneAdditive(2);
		}
	}
}
