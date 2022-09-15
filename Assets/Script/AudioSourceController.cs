using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceController : MonoBehaviour
{
	public AudioClip trueAnswerClip, wrongAnswerClip;

	private AudioSource source;

	private void Awake()
	{
		source = GetComponent<AudioSource>();
	}

	public void PlayOneShot(bool isTrueAnswer)
	{
		source.PlayOneShot((isTrueAnswer) ? trueAnswerClip : wrongAnswerClip);
	}
}
