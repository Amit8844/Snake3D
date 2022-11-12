using System.Collections;
using UnityEngine;

public class FoodGeneration : MonoBehaviour {

	public float xSize = 14.0f;
	public float zSize = 9.0f;

	public GameObject foodPrefab;
	public GameObject currentFood;
	public Vector3 currentFoodPosition;

	void AddNewFood(){
		RandomPosition();
		currentFood = GameObject.Instantiate(foodPrefab, currentFoodPosition, Quaternion.identity) as GameObject;

	}
	void RandomPosition(){
		currentFoodPosition = new Vector3(Random.Range(-xSize, xSize), 0.35f, Random.Range(-zSize, zSize));

	}
	// Update is called once per frame
	void Update () {
		if(!currentFood){
			AddNewFood();
		}
	}
}
