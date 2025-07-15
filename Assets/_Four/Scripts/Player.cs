using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learn.Four
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private float health;
        public float Health
        {
            get => health;
            set
            {
                health = value;
                OnHealthChange?.Invoke(health, maxHealth);
            }
        }

        public event Action<float, float> OnHealthChange;

        public void Init()
        {
            OnHealthChange?.Invoke(health, maxHealth);
        }

#if UNITY_EDITOR
        [Button("Change Health")]
#endif
        public void ChangeHealth(float value)
        {
            Health += value;
        }
    }
}
