using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Learn.One
{
    public class PoolManager : MonoBehaviour
    {
        public RectTransform rctTrfParent;
        public AssetReferenceT<GameObject> objPoolPrefab;

        public List<GameObject> poolList = new List<GameObject>();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) // get
            {
                GetAsync();
                //Get();
            }
        }

        public async void GetAsync()
        {
            if (objPoolPrefab.Asset == null)
            {
                await LoadAssetAsync();
            }

            if (poolList.Count <= 0)
            {
                poolList.Add(Instantiate());
                return;
            }

            foreach (GameObject obj in poolList)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    return;
                }
            }

            poolList.Add(Instantiate());
        }

        public void Get()
        {
            if (poolList.Count <= 0)
            {
                poolList.Add(Instantiate());
                return;
            }

            foreach (GameObject obj in poolList)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    return;
                }
            }

            poolList.Add(Instantiate());
        }

        private GameObject Instantiate()
        {
            return Instantiate(objPoolPrefab.Asset as GameObject, rctTrfParent);
        }

        private async Task LoadAssetAsync()
        {
            try
            {
                AsyncOperationHandle<GameObject> handle = objPoolPrefab.LoadAssetAsync();
                await handle.Task;
                Debug.Log($"Picture Laoded");
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}
