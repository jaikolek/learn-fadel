using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;

namespace Learn.One
{
    public class PoolManager : MonoBehaviour
    {
        public RectTransform rctTrfParent;
        public AssetReferenceT<GameObject> objPoolPrefab;

        public int input;

        private int count;
        public int Count
        {
            get => count;
            set
            {
                count = value;
                OnCountChanged?.Invoke(value);
            }
        }

        public event Action<int> OnCountChanged;

        public List<GameObject> poolList = new List<GameObject>();

        private void Awake()
        {
            OnCountChanged += Init;

            Count = 4;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Count = input;
            }
        }

        private async void Init(int count)
        {
            Release();

            for (int i = 0; i < count; i++)
            {
                await GetAsync();
            }
        }

        private void Release()
        {
            if (poolList.Count <= 0 || poolList == null) return;

            foreach (GameObject obj in poolList)
            {
                if (obj.TryGetComponent(out ObjectPool objPool))
                {
                    objPool.Release();
                }
            }
        }

        public async Task GetAsync()
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
                Debug.Log($"Here 2");
                Debug.Log($"Picture Laoded");
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}
