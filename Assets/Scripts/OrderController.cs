using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderController : MonoBehaviour
{
    public GameTimer timer;
    public int orderNum;
    public int checkOrder;
    public CloneSocketObject[] objSpawns;

    void Start()
    {
        orderNum = 100100;
        checkOrder = 0;
        int rand = UnityEngine.Random.Range(1, 4);
        for(int i = 0; i < rand; i++)
        {
            int rand2 = UnityEngine.Random.Range(0, 2);
            if(rand2 == 0)
            {
                orderNum += 10000;
            }
            else if(rand2 == 1)
            {
                orderNum += 1000;
            }
        }
        rand = UnityEngine.Random.Range(0, 2);
        if(rand == 1)
        {
            orderNum += 10;
        }
        rand = UnityEngine.Random.Range(0, 2);
        if (rand == 1)
        {
            orderNum += 1;
        }
        Debug.Log(orderNum.ToString());
    }

    public async void CheckOrder()
    {
        await Task.Delay(100);
        Debug.Log(checkOrder.ToString());
        if(checkOrder == orderNum)
        {
            timer.timeLeft += 60f;
        }
        else
        {
            timer.timeLeft -= 15f;
        }

//        DestroyObjs(ReturnLayer(GetAllObjs()));

//        foreach (CloneSocketObject spawn in objSpawns)
//        {
//            spawn.numObjs = 0;
//            spawn.CloneInteractable();
//        }

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
                IngredientController IC = objs[i].gameObject.GetComponent<IngredientController>();
                if(IC != null)
                {
                    print(i);
                    print(objs[i].gameObject);
                    Destroy(objs[i]);
                }
            }
        }
    }
}