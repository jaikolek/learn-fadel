using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiPool : MonoBehaviour
{
    public static UiPool Instance;

    private List<GameObject> PooledObj;
    public int Amount;

    [SerializeField] private GameObject UiPF;
    [SerializeField] private Transform contentP;

    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
        }
    }

    private void Start()
    {
        PooledObj = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < Amount; i++)
        {
            tmp = Instantiate(UiPF, contentP);
            tmp.SetActive(false);
            PooledObj.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (var ui in PooledObj)
        {
            if (!ui.activeInHierarchy)
            {
                return ui;
            }
        }
        return null;
        /* for (int i = 0; i < PooledObj.Count; i++)
         {
             if (!PooledObj[i].activeInHierarchy)
             {
                 return PooledObj[i];
             }
         }
         return null;*/
    }

    public void Return()
    {
        foreach (var ui in PooledObj)
        {
            ui.SetActive(false);
        }
    }
}
