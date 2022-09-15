using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public void Play()
	{
		GameManager.Instance.LoadSceneSingle(1);
		GameManager.Instance.audioSourceController.PlayOneShot(true);
	}
}
