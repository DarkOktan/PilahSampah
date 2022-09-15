using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlace : MonoBehaviour {

	public float speed;
	public Sprite[] listSprite;

	private float YPos;
	private Vector3 screenPoint, offset;

	private Scoring scoringSystem;

	private void Awake()
	{
		scoringSystem = FindObjectOfType<Scoring>();
	}

	// Use this for initialization
	void Start () {
		int index = Random.Range(0, listSprite.Length); // Randoming Something
		gameObject.GetComponent<SpriteRenderer>().sprite = listSprite[index]; // Random Sprite
	}
	
	// Update is called once per frame
	void Update () {
		TrashMovement();
	}

	void TrashMovement(){
		// Vector3 direction = -transform.right * speed * Time.deltaTime;
		// transform.position = transform.position + direction;

		if (!GameManager.Instance.IsMoving) return;

		float XDir = (speed * Time.deltaTime * -1f) + transform.position.x;
		transform.position = new Vector3(XDir, transform.position.y);
	}

	void OnMouseDown(){
		YPos = transform.position.y;
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag(){
		Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos) + offset;
		transform.position = worldPos;
	}

	void OnMouseUp(){
		transform.position = new Vector3(transform.position.x, YPos, transform.position.z);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(gameObject.tag))
		{
			scoringSystem.AddingScore(true);

			Destroy(gameObject);
		}
		else 
		{
			scoringSystem.AddingScore(false);

			Destroy(gameObject);
		}
	}
}
