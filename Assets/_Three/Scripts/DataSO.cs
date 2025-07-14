using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learn.Three
{
    [CreateAssetMenu(fileName = "Data SO", menuName = "Data/Data SO")]
    public class DataSO : ScriptableObject, IData
    {
        [SerializeField] private string dataName;

        public string GetData()
        {
            return dataName;
        }

        public void SetData(string dataName)
        {
            this.dataName = dataName;
        }
    }
}
