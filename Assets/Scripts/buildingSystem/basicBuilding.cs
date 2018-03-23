using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class basicBuilding : MonoBehaviour {

    public GameObject Button_Template;

    private GameObject[] buildingPrefabs;
    private Object[] buildingPrefabsObjects;

    private GameObject buildingMenu;
    private GameObject buildingMenuUIContent;
    private GameObject AllUIObjects;

    void Start () {

        AllUIObjects = GameObject.Find ("AllUIObjectsCanvas");
        buildingMenu = AllUIObjects.transform.GetChild (2).gameObject;

        buildingMenuUIContent = buildingMenu.transform.GetChild (0).GetChild (0).GetChild (0).gameObject;

        // Get all building Prefabs in buildingPrefabs folder.
        buildingPrefabs = Resources.LoadAll ("Prefabs/buildingPrefabs", typeof(GameObject)).Cast<GameObject> ().ToArray ();
        buildingPrefabsObjects = buildingPrefabs;
    }

    public void recieveAction () {
        displayMenu ();
    }

    private void buildBuildingMenu () {
        GameObject tempGameObject;
        int counter = 0;
        foreach (var theBuildings in buildingPrefabs) {
            tempGameObject = Instantiate (Button_Template) as GameObject;
            tempGameObject.SetActive (true);
            tempGameObject.GetComponent<buildingButtonScript> ().setButton (counter, this, buildingPrefabs [counter]);
            tempGameObject.transform.SetParent (buildingMenuUIContent.transform, false);
            counter++;
        }
    }

    private void displayMenu () {
        buildingMenu.SetActive (true);
        buildingMenu.transform.GetChild (0).gameObject.SetActive (true);
        clearUI ();
        buildBuildingMenu ();

    }

    private void clearUI () {
        foreach (Transform child in buildingMenuUIContent.transform) {
            Destroy (child.gameObject);
        }
    }

    private void createBuilding (int buildingNumber) {
        if (checkResources (buildingNumber)) {
            // Create Building.
            Instantiate (buildingPrefabsObjects [buildingNumber], this.transform.position, Quaternion.identity);

            buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().purchase ();
            // Disable Building Menu.
            buildingMenu.transform.GetChild (0).gameObject.SetActive (false);
            buildingMenu.SetActive (false);

            Destroy (gameObject);
        } else {
            Debug.Log ("Not Enough Resources to build Building: " + buildingNumber);
        }
    }

    private bool checkResources (int buildingNumber) {
        return buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().canAfford ();
    }

    public void buttonClicked (int number) {
        createBuilding (number);
    }
}
