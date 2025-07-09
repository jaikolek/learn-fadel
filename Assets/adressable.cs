using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class adressable : MonoBehaviour
{
    [SerializeField] AssetReferenceGameObject _UI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _UI.InstantiateAsync();
        }
    }
}
