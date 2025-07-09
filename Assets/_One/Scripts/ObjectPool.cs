using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learn.One
{
    public class ObjectPool : MonoBehaviour
    {
        public float delay = 2f;

        private void OnEnable()
        {
            StartCoroutine(Delay(delay));
        }

        private IEnumerator Delay(float delay)
        {
            yield return new WaitForSeconds(delay);
            this.gameObject.SetActive(false);
        }
    }
}