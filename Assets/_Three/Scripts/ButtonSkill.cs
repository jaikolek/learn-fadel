using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

namespace Learn.Three
{
    public class ButtonSkill : MonoBehaviour
    {
        [SerializeField] private Button btnSkill;
        [SerializeField] private TextMeshProUGUI txtTime;

        [SerializeField] private Color disableColor;

        public string SkillName { get; set; }

        public void AddListener(UnityAction action)
        {
            btnSkill.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action)
        {
            btnSkill.onClick.RemoveListener(action);
        }

        public void RemoveAllListener()
        {
            btnSkill.onClick.RemoveAllListeners();
        }

        public void UpdateVisual(bool isDisable)
        {
            btnSkill.enabled = !isDisable;
            txtTime.gameObject.SetActive(isDisable);
            btnSkill.image.color = isDisable ? disableColor : Color.white;
        }

        public void OnCooldown(float time)
        {
            txtTime.SetText(time.ToString());
        }

        public void Release()
        {
            RemoveAllListener();
            SkillName = null;
            this.gameObject.SetActive(false);
        }
    }
}
