using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashGenerator : MonoBehaviour {

	public float delayTime;

	public GameObject[] listTrash;

	private float currentTime;

	// Use this for initialization
	void Start () {
		currentTime = delayTime;
		GameManager.Instance.IsMoving = true;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime -= Time.deltaTime;
		if (currentTime <= 0.0f)
		{
			currentTime = delayTime;

			int randomIndex = Random.Range(0, listTrash.Length);
			GameObject objectToCreate = listTrash[randomIndex];
			Instantiate(objectToCreate, transform.position, objectToCreate.transform.rotation);
		}
	}
}
