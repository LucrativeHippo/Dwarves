using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class basicBuilding : MonoBehaviour {

    private GameObject[] buildingPrefabs;
    private Object[] buildingPrefabsObjects;

    private GameObject resourceManager;
    private GameObject buildingMenu;

    public GameObject Button_Template;

    private GameObject buildingMenuUIContent;



    void Start () {
        // Get Resource Manager.
        resourceManager = GameObject.Find ("resourceManager");

        // Get building menu object.
        buildingMenu = GameObject.Find ("buildingMenuUI");

        buildingMenuUIContent = GameObject.Find ("buildingUIContent");

        // Get all building Prefabs in buildingPrefabs folder.
        buildingPrefabs = Resources.LoadAll ("Prefabs/buildingPrefabs", typeof(GameObject)).Cast<GameObject> ().ToArray ();
        buildingPrefabsObjects = buildingPrefabs;

        // Build Menu.
        buildBuildingMenu ();

        // Log the names of all buildings.
        foreach (var building in buildingPrefabs) {
            Debug.Log ("Building Name: " + building.name);
        }
    }

    public void recieveAction () {
        displayMenu ();
    }

    private void buildBuildingMenu () {
        Button testHardCodedButton = GameObject.Find ("BuildButton").GetComponent<Button> ();
        testHardCodedButton.onClick.AddListener (() => createBuilding (0));


        // TODO: Finish below for creating buttons to build stuff.
        GameObject tempGameObject;
        int counter = 0;
        foreach (var theBuildings in buildingPrefabs) {
            tempGameObject = Instantiate (Button_Template) as GameObject;
            tempGameObject.SetActive (true);
            buttonScript aButtonScript = tempGameObject.GetComponent<buttonScript> ();
            aButtonScript.setBuildingScript (this);
            aButtonScript.setName (theBuildings.name);
            aButtonScript.setNumber (counter);
            tempGameObject.transform.SetParent (Button_Template.transform.parent, false);
            counter++;
        }
    }

    private void displayMenu () {
        buildingMenu.GetComponent<Canvas> ().enabled = true;
    }


    private void createBuilding (int buildingNumber) {
        if (checkResources (buildingNumber)) {
            // Create Building.
            Instantiate (buildingPrefabsObjects [buildingNumber], transform.position, Quaternion.identity);

            // Use Resources.
            resourceManager.GetComponent<testingResources> ().useWood (buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().getWoodCost ());
            resourceManager.GetComponent<testingResources> ().useStone (buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().getStoneCost ());
            resourceManager.GetComponent<testingResources> ().useGold (buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().getGoldCost ());

            // Disable Building Menu.
            buildingMenu.GetComponent<Canvas> ().enabled = false;
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

    public void buttonClicked (int number) {
        Debug.Log (number + " button clicked.");
        createBuilding (number);
    }
}
