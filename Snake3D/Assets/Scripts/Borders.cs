using Snake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Borders : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		
		if (other.TryGetComponent(out SnakeMovement snake))
		{  
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
