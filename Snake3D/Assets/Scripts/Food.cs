using Snake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.Interactable
{
	public class Food : MonoBehaviour
	{

		void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out SnakeMovement snake))
			{
				other.GetComponent<SnakeMovement>().AddTail();
				Destroy(gameObject);
			}
		}
	}
}