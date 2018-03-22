using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class buildingsBuilt : MonoBehaviour {

    private GameObject[] buildingPrefabs;
    private int[] buildingLimits;
    private int[] currentBuildings;

    void Start () {
        buildingPrefabs = Resources.LoadAll ("Prefabs/buildingPrefabs", typeof(GameObject)).Cast<GameObject> ().ToArray ();

        int counter = 0;
        foreach (var building in buildingPrefabs) {
            buildingLimits [counter] = buildingPrefabs [counter].GetComponent<resourceCost> ().getBuildingLimit ();
            currentBuildings [counter] = 0;
            counter++;
        }
    }

    /// <summary>
    /// Increases the building count.
    /// </summary>
    /// <param name="aBuilding">A building.</param>
    public void increaseBuildingCount (GameObject aBuilding) {
        int counter = 0;
        foreach (var building in buildingPrefabs) {
            if (aBuilding == building) {
                currentBuildings [counter]++;
            }
            counter++;
        }
    }

    /// <summary>
    /// Checks if Building is a it's building limit.
    /// </summary>
    /// <returns><c>true</c>, if at building limit, <c>false</c> otherwise.</returns>
    /// <param name="aBuilding">A building.</param>
    private bool buildingAtLimit (GameObject aBuilding) {
        int counter = 0;
        foreach (var building in buildingPrefabs) {
            if (aBuilding == building) {
                if (currentBuildings [counter] >= buildingLimits [counter]) {
                    return true;
                }
            }
        }
        return false;
    }
}
