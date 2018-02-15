using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class basicBuilding : MonoBehaviour {

    private GameObject[] buildingPrefabs;

    private GameObject[] buildingButtons;

    private GameObject resourceManager;
    private GameObject buildingMenu;

    public GameObject Button_Template;

    void Start () {
        // Get Resource Manager.
        resourceManager = GameObject.Find ("resourceManager");

        // Get building menu object and build the menu.
        buildingMenu = GameObject.Find ("buildingMenuUI");
        buildBuildingMenu ();

        // Get all building Prefabs in buildingPrefabs folder.
        buildingPrefabs = Resources.LoadAll ("Prefabs/buildingPrefabs", typeof(GameObject)).Cast<GameObject> ().ToArray ();

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
        int counter = 0;
        foreach (var buildings in buildingPrefabs) {
            GameObject aButton = Instantiate (Button_Template) as GameObject;
            aButton.SetActive (true);
            buttonScript aButtonScript = aButton.GetComponent<buttonScript> ();
            aButtonScript.setName (buildings.name);
            aButtonScript.setNumber (counter);
            counter++;
            aButton.transform.SetParent (Button_Template.transform.parent);
        }
    }

    private void displayMenu () {
        // Enable Menu
        buildingMenu.GetComponent<Canvas> ().enabled = true;
    }


    private void createBuilding (int buildingNumber) {
        if (checkResources (buildingNumber)) {
            Instantiate (buildingPrefabs [buildingNumber], transform.position, Quaternion.identity);

            resourceManager.GetComponent<testingResources> ().useWood (buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().getWoodCost ());
            resourceManager.GetComponent<testingResources> ().useStone (buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().getStoneCost ());
            resourceManager.GetComponent<testingResources> ().useGold (buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().getGoldCost ());

            // These are a version of calling the function which I'm not sure which is better this or the above.
            //		resourceManager.SendMessage ("useWood", buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().getWoodCost ());
            //		resourceManager.SendMessage ("useStone", buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().getStoneCost ());
            //		resourceManager.SendMessage ("useGold", buildingPrefabs [buildingNumber].GetComponent<resourceCost> ().getGoldCost ());

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
