using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlizzardTrap : MonoBehaviour {

    public float slowDuration;
    public float slowDecimal;

    public float maxTopWindStrength;
    public float minTopWindStrength;
    public float startingWindDirection;
    public float windRotationTime;
    public float maxScale;
    public float minScale;
    public float maxTimeToLive;
    public float minTimeToLive;
    
    public float maxTimeBetweenRounds;
    public float minTimeBetweenRounds;

    public int maxSwirlsPerRound;
    public int minSwirlsPerRound;

    private float maxWindStrength;
    private float currentWindStrength;
    private float currentWindDirection;
    private float timeToLive;
    private float timePassed;
    private float timeSinceStageChange;
    private float currentStageDuration;
    private lifeStages stage;

    private BuffSystem buffsys;

    private enum lifeStages
    {
        SWIRLING,
        WAITING
    }

	// Use this for initialization
	void Start () {
        stage = lifeStages.WAITING;
        timeSinceStageChange = currentStageDuration + 1;

        float scale = Random.Range(minScale, maxScale);
        Vector3 newScale = new Vector3();
        newScale.x = scale;
        newScale.y = scale;
        newScale.z = scale;
        transform.localScale = newScale;

        timeToLive = Random.Range(minTimeToLive, maxTimeToLive);

        buffsys = new BuffSystem();
	}
	
	// Update is called once per frame
	void Update () {
        timePassed += Time.deltaTime;

        if (timePassed >= timeToLive)
        {
            Destroy(gameObject);
        }

        timeSinceStageChange += Time.deltaTime;

        updateStage();

        if (stage == lifeStages.SWIRLING)
        {
            findNewWindStats();
            updatePosition();
        }
        
	}

    private void updateStage()
    {
        if (timeSinceStageChange >= currentStageDuration)
        {
            timeSinceStageChange = 0;
            switch (stage)
            {
                case lifeStages.SWIRLING:
                    stage = lifeStages.WAITING;
                    currentStageDuration = Random.Range(minTimeBetweenRounds, maxTimeBetweenRounds);
                    break;
                case lifeStages.WAITING:
                    stage = lifeStages.SWIRLING;
                    currentStageDuration = Random.Range(minSwirlsPerRound, maxSwirlsPerRound + 1) * windRotationTime;
                    startingWindDirection = Random.Range(0, 2 * Mathf.PI);
                    maxWindStrength = Random.Range(minTopWindStrength, maxTopWindStrength);


                    break;
                default:
                    Debug.LogError("No stage set on blizzard trap.");
                    break;
            }
        }
    }

    private void updatePosition()
    {
        float dist = currentWindStrength * Time.deltaTime;
        Vector3 posChange = new Vector3();
        posChange.x = dist * Mathf.Cos(currentWindDirection);
        posChange.z = dist * Mathf.Sin(currentWindDirection);
        posChange.y = 0;

        Vector3 newPos = transform.position;
        newPos += posChange;
        transform.position = newPos;
    }

    private void findNewWindStats()
    {
        float currentRotationTime = timePassed % windRotationTime;

        float oldWindStrength;
        float newWindStrength;

        if (currentRotationTime < 0.5)
        {
            oldWindStrength = 0.1f;
            newWindStrength = maxWindStrength;
        }
        else
        {
            oldWindStrength = maxWindStrength;
            newWindStrength = 0.1f;
        }

        currentWindStrength = Mathf.Lerp(oldWindStrength,
            newWindStrength, currentRotationTime);
        currentWindDirection = Mathf.Lerp(startingWindDirection,
            startingWindDirection + (2 * Mathf.PI), currentRotationTime / 2);

        currentWindDirection = currentWindDirection % (2 * Mathf.PI);
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject victim = other.gameObject;
        ValidBuffTarget valid = victim.GetComponent<ValidBuffTarget>();

        if (valid != null)
        {
            if (!checkIfInBuilding(victim) && (gameObject.tag.Equals("Player") || gameObject.tag.Equals("OwnedNPC")))
            {
                buffsys.slowApplyingSystem(victim, slowDuration, slowDecimal);
            }
            
        }
    }

    private bool checkIfInBuilding(GameObject victim)
    {
        InBuilding buildingCheck = victim.GetComponent<InBuilding>();
        if (buildingCheck == null)
        {
            return false;
        }
        else
        {
            return buildingCheck.getPlayerInBuilding();
        }
    }
}
