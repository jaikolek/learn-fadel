using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Learn.Three
{
    public class ButtonSkill : ObjectPool
    {
        [SerializeField] private Button btnSkill;
        [SerializeField] private TextMeshProUGUI txtTime;
        [SerializeField] private TextMeshProUGUI txtName;

        [SerializeField] private Color disableColor;

        private string skillName;
        public string SkillName
        {
            get => skillName;
            set
            {
                skillName = value;
                txtName.SetText(skillName);
            }
        }

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
            txtName.gameObject.SetActive(!isDisable);
            btnSkill.image.color = isDisable ? disableColor : Color.white;
        }

        public void OnCooldown(float time)
        {
            txtTime.SetText($"{time:0.0}");
        }

        public void OnUse()
        {
            UpdateVisual(true);
        }

        public void OnSkillReady()
        {
            UpdateVisual(false);
        }

        public override void Release()
        {
            RemoveAllListener();
            SkillName = null;

            base.Release();
        }
    }
}
