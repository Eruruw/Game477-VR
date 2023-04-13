using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderController : MonoBehaviour
{
    public int orderNum;
    public int checkOrder;
    private int randInt;
    public CloneSocketObject[] objSpawns;

    void Start()
    {
        orderNum = 100100;
        checkOrder = 0;
        System.Random rnd = new System.Random();
        randInt = rnd.Next(1, 3);
        for(int i = 0; i < randInt; i++)
        {
            randInt = rnd.Next(2);
            if(randInt == 0)
            {
                orderNum += 10000;
            }
            else if(randInt == 1)
            {
                orderNum += 1000;
            }
        }
        randInt = rnd.Next(2);
        if(randInt == 1)
        {
            orderNum += 10;
        }
        randInt = rnd.Next(2);
        if(randInt == 1)
        {
            orderNum += 1;
        }
        Debug.Log(orderNum.ToString());
        gameObject.SetActive(false);
    }

    public async void CheckOrder()
    {
        await Task.Delay(100);
        if(checkOrder == orderNum)
        {
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("Incorrect");
        }

        DestroyObjs(ReturnLayer(GetAllObjs()));

        foreach (CloneSocketObject spawn in objSpawns)
        {
            spawn.numObjs = 0;
            spawn.CloneInteractable();
        }

        Start();
    }

    private GameObject[] GetAllObjs()
    {
        return Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];
    }

    private GameObject[] ReturnLayer(GameObject[] objList)
    {
        for(int i = 0; i < objList.Length; i++)
        {
            if (objList[i].layer != 7)
            {
                objList[i] = null;
            }
        }

        return objList;
    }

    private void DestroyObjs(GameObject[] objs)
    {
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i] != null)
            {
                print(i);
                print(objs[i].gameObject);
                Destroy(objs[i]);
            }
        }
    }
}