using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Snake
{
	public class SnakeMovement : MonoBehaviour
	{

		[Header("Speeds")]
		public float f_Speed = 2.0f;
		[SerializeField] private float f_RotationSpeed = 180.0f;

		[Header("Snake Parts")]
		[SerializeField] private GameObject tailPrefab;
		public List<GameObject> tailObjects = new List<GameObject>();

		[HideInInspector]
		[SerializeField] private Text scoreText;
		[HideInInspector]
		[SerializeField] private int scoreNumber = 0;
		[SerializeField] private Text bestScoreText;

		int bestScoreNumber = 0;


		void Start()
		{
			bestScoreNumber = PlayerPrefs.GetInt("bestScore");
			tailObjects.Add(gameObject);
		}


		void Update()
		{
			transform.Translate(Vector3.forward * f_Speed * Time.deltaTime);

			if (Input.GetKey(KeyCode.D))
			{
				transform.Rotate(Vector3.up * f_RotationSpeed * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.A))
			{
				transform.Rotate(Vector3.down * f_RotationSpeed * Time.deltaTime);
			}


			scoreText.text = scoreNumber.ToString();
			bestScoreText.text = bestScoreNumber.ToString();

		}

		public void AddTail()
		{
			Vector3 newTailPosition = tailObjects[tailObjects.Count - 1].transform.position;
			f_Speed += 0.2f;
			f_RotationSpeed += 5.0f;
			tailObjects.Add(Instantiate(tailPrefab, newTailPosition, Quaternion.identity) as GameObject);
			scoreNumber++;
			if (scoreNumber > bestScoreNumber) PlayerPrefs.SetInt("bestScore", scoreNumber);
		}
	}
}