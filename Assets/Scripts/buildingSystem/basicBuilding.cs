using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class basicBuilding : MonoBehaviour {

	private GameObject[] buildingPrefabs;

	private GameObject resourceManager;

	void Start () {
		// Get Resource Manager;
		resourceManager = GameObject.Find ("resourceManager");

		// Get all building Prefabs in buildingPrefabs folder.
		buildingPrefabs = Resources.LoadAll ("Prefabs/buildingPrefabs", typeof(GameObject)).Cast<GameObject> ().ToArray ();

		// Log the names of all buildings.
		foreach (var t in buildingPrefabs) {
			Debug.Log ("Building Name: " + t.name);
		}
	}

	public void recieveAction () {
		displayMenu ();
	}

	private void displayMenu () {
		// TODO: Display a Popup menu for the user to select the building they wish to build.

		// For testing atm.
		createBuilding (0);
	}

	private void createBuilding (int buildingNumber) {
		if (checkResources (buildingNumber)) {
			Instantiate (buildingPrefabs [buildingNumber], transform.position, Quaternion.identity);

			resourceManager.GetComponent<testingResources> ().useWood (buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().getWoodCost ());
			resourceManager.GetComponent<testingResources> ().useStone (buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().getStoneCost ());
			resourceManager.GetComponent<testingResources> ().useGold (buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().getGoldCost ());

			//		resourceManager.SendMessage ("useWood", buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().getWoodCost ());
			//		resourceManager.SendMessage ("useStone", buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().getStoneCost ());
			//		resourceManager.SendMessage ("useGold", buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().getGoldCost ());
		} else {
			Debug.Log ("Not Enough Resources to build Building: " + buildingNumber);
		}
	}

	private bool checkResources (int buildingNumber) {
		int currentWood = resourceManager.GetComponent<testingResources> ().getWood ();
		int currentStone = resourceManager.GetComponent<testingResources> ().getStone ();
		int currentGold = resourceManager.GetComponent<testingResources> ().getGold ();

		int woodCost = buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().getWoodCost ();
		int stoneCost = buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().getStoneCost ();
		int goldCost = buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().getGoldCost ();

		if (woodCost > currentWood || stoneCost > currentStone || goldCost > currentGold) {
			return false;
		} else {
			return true;
		}
	}
}
