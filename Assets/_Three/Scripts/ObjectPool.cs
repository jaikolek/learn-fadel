using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learn.Three
{
    public abstract class ObjectPool : MonoBehaviour
    {
        public virtual void Release()
        {
            this.gameObject.SetActive(false);
        }
    }
}
