using Snake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snake.TailMovement
{
	public class TailMovement : MonoBehaviour
	{

		[Header("Snake Stats")]
		[SerializeField] private float f_Speed;
		[SerializeField] private GameObject m_TailTarget;
		[SerializeField] private Vector3 tailTargetPosition;
		[SerializeField] private int i_NumberTarget;
		[SerializeField] private SnakeMovement mainSnake;



		void Start()
		{
			mainSnake = GameObject.FindWithTag("SnakeHead").GetComponent<SnakeMovement>();
			m_TailTarget = mainSnake.tailObjects[mainSnake.tailObjects.Count - 2];
			i_NumberTarget = mainSnake.tailObjects.IndexOf(gameObject);
		}


		void Update()
		{

			f_Speed = mainSnake.f_Speed + 2.5f;
			tailTargetPosition = m_TailTarget.transform.position;
			transform.LookAt(tailTargetPosition);
			transform.position = Vector3.Lerp(transform.position, tailTargetPosition, Time.deltaTime * f_Speed);
		}

		void OnTriggerEnter(Collider other)
		{

			if (other.TryGetComponent(out SnakeMovement snakeMovement) && i_NumberTarget > 2)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}
}