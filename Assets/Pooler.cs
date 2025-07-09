using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    public static Pooler Instance;
    
    private List<GameObject> PooledObj;
    public int Amount;

    [SerializeField] private GameObject objPool;

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
            tmp = Instantiate(objPool);
            tmp.SetActive(false);
            PooledObj.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < PooledObj.Count; i++)
        {
            if (!PooledObj[i].activeInHierarchy)
            {
                return PooledObj[i];
            }
        }
        return null;
    }
}
