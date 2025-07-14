using Learn.Three;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learn.Three
{
    [CreateAssetMenu(fileName = "Place SO", menuName = "Data/Place SO")]
    public class PlaceSO : ScriptableObject, IData
    {
        [SerializeField] private string placeName;

        public string GetData()
        {
            return placeName;
        }

        public void SetData(string placeName)
        {
            this.placeName = placeName;
        }
    }
}
