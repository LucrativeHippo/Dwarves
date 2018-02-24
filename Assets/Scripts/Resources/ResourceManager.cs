using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManger : MonoBehaviour {

    private const int FOOD = 0;
    private const int WOOD = 1;
    private const int STONE = 2;
    private const int SAND = 3;
    private const int COAL = 4;
    private const int IRON = 5;
    private const int GOLD = 6;
    private const int DIAMOND = 7;

    private int[] resources = new int[8];

    private bool meat;
    private bool fruit;
    private bool veg;

    private int getResource(int resource)
    {
        return resources[resource];
    }

    private void setResource (int resource, int amount)
    {
        if (amount < 0)
        {
            amount = 0;
        }

        resources[resource] = amount;
    }

    private void changeResource (int resource, int change)
    {
        resources[resource] += change;

        if (resources[resource] < 0)
        {
            resources[resource] = 0;
        }
    }


    public int getFood()
    {
        return getResource(FOOD);
    }

    public int getWood()
    {
        return getResource(WOOD);
    }

    public int getStone()
    {
        return getResource(STONE);
    }

    public int getSand()
    {
        return getResource(SAND);
    }

    public int getCoal()
    {
        return getResource(COAL);
    }

    public int getIron()
    {
        return getResource(IRON);
    }

    public int getGold()
    {
        return getResource(GOLD);
    }

    public int getDiamond()
    {
        return getResource(DIAMOND);
    }

    public void setFood(int val)
    {
        setResource(FOOD, val);
    }

    public void setWood(int val)
    {
        setResource(WOOD, val);
    }

    public void setStone(int val)
    {
        setResource(STONE, val);
    }

    public void setSand(int val)
    {
        setResource(SAND, val);
    }

    public void setCoal(int val)
    {
        setResource(COAL, val);
    }

    public void setIron(int val)
    {
        setResource(IRON, val);
    }

    public void setGold(int val)
    {
        setResource(GOLD, val);
    }

    public void setDiamond(int val)
    {
        setResource(DIAMOND, val);
    }

    public void changeFood(int val)
    {
        changeResource(FOOD, val);
    }

    public void changeWood(int val)
    {
        changeResource(WOOD, val);
    }

    public void changeStone(int val)
    {
        changeResource(STONE, val);
    }

    public void changeSand(int val)
    {
        changeResource(SAND, val);
    }

    public void changeCoal(int val)
    {
        changeResource(COAL, val);
    }

    public void changeIron(int val)
    {
        changeResource(IRON, val);
    }

    public void changeGold(int val)
    {
        changeResource(GOLD, val);
    }

    public void changeDiamond(int val)
    {
        changeResource(DIAMOND, val);
    }

    public bool hasMeat()
    {
        return meat;
    }

    public bool hasFruit()
    {
        return fruit;
    }

    public bool hasVeg()
    {
        return veg;
    }

    public void setHasMeat(bool val)
    {
        meat = val;
    }

    public void setHasFruit(bool val)
    {
        fruit = val;
    }

    public void setHasVeg(bool val)
    {
        veg = val;
    }


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
