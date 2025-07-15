using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Learn.Four
{
    public class StatUI : MonoBehaviour
    {
        [SerializeField] private Image imgFront;
        [SerializeField] private Image imgBack;

        [SerializeField] private TextMeshProUGUI txtHealth;

        public void OnHealthChanged(float health, float maxHealth)
        {
            txtHealth.SetText(health.ToString());
            SetStat(health / maxHealth);
        }

        private void SetStat(float stat)
        {
            imgFront.fillAmount = stat;
        }
    }
}
