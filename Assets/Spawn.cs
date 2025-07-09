using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Spawn : MonoBehaviour
{
    
    //private float speed = 10f;

   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Summon();  
        }
        //Debug.Log("predss");
        // StartCoroutine(deaktif(tes));
    }

    public void Summon()
    {
        GameObject tes = Pooler.Instance.GetPooledObject();

        if (tes != null)
        {
            tes.transform.position = transform.position;
            tes.SetActive(true);
        }
    }

  
    
}
