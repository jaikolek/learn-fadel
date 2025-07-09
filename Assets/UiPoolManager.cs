using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiPoolManager : MonoBehaviour
{
    private int currDex = 0;
    private List<string> currentItems = new List<string>();

    private void Start()
    {
        int amountU = UiPool.Instance.Amount;
        for (int i = 0; i <= amountU; i++)
        {
            currentItems.Add("Items " + i);    
        }
        UiPool.Instance.Return();
        currDex = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowList();
        }
    }


    public void ShowList()
    {
        if (currDex >= currentItems.Count)
        {
            return;
        }
        
            GameObject btnObj = UiPool.Instance.GetPooledObject();
            btnObj.SetActive(true);

            // Set text dan klik
            Text label = btnObj.GetComponentInChildren<Text>();
            if (label != null) label.text = currentItems[currDex];

            Button btn = btnObj.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(() =>
                {
                    //Debug.Log("Clicked: " + item);
                    btnObj.SetActive(false); 
                });
            }
        
    }





}
