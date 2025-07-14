using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Learn.Three
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private ButtonSkill btnSkillPrefab;
        [SerializeField] private RectTransform rctTrfParent;
        
        [SerializeField] private List<ButtonSkill> btnSkillList = new List<ButtonSkill>();

        public static UIManager Instance;

        private IUseSkill player;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        public void SetPlayer(IUseSkill player)
        {
            this.player = player;
        }

        public void OnSkillChanged(List<Skill> skillList)
        {
            ReleaseAll(); // release

            foreach (Skill skill in skillList)
            {
                Init(skill, () =>
                {
                    player.UseSkill(skill.GetName());
                });
            }
        }

        public void Init(Skill skill, UnityAction OnUse)
        {
            ButtonSkill btnSkill = GetButtonSkill();

            if (btnSkill == null)
            {
                ButtonSkill generateBtnSkill = Instantiate<ButtonSkill>(btnSkillPrefab, rctTrfParent);
                generateBtnSkill.name = "button " + skill.GetName();

                generateBtnSkill.SkillName = skill.GetName();
                generateBtnSkill.AddListener(OnUse);

                btnSkillList.Add(generateBtnSkill);
            }
            else
            {
                btnSkill.name = "button " + skill.GetName();

                btnSkill.SkillName = skill.GetName();
                btnSkill.AddListener(OnUse);

                btnSkill.gameObject.SetActive(true);
            }
        }

        public void ReleaseAll()
        {
            foreach (ButtonSkill btnSkill in btnSkillList)
            {
                btnSkill.Release();
            }
        }

        public ButtonSkill GetButtonSkill()
        {
            foreach (ButtonSkill btnSkill in btnSkillList)
            {
                if (!btnSkill.gameObject.activeInHierarchy)
                {
                    return btnSkill;
                }
            }

            return null;
        }
    }
}
