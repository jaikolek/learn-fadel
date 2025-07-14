using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learn.Three
{
    public class Player : MonoBehaviour, IUseSkill
    {
        [SerializeField] private SkillStorage skillStorage;

        private void Awake()
        {
            UIManager.Instance.SetPlayer(this);
            skillStorage.OnSkillChange += UIManager.Instance.OnSkillChanged;
        }

        private void Update()
        {
            skillStorage.Tick();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                RemoveSkill("Grab");
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                AddSkill("Grab");
            }
        }

        public void UseSkill(string skillName)
        {
            skillStorage.UseSkill(skillName);
        }

#if UNITY_EDITOR
        [Button("Adding Skill")]
#endif
        public void AddSkill(string name)
        {
            Skill skill = SkillManager.Instance.GetSkill(name);

            if (skill == null) return;
            
            skillStorage.AddSkill(skill);
        }

#if UNITY_EDITOR
        [Button("Removing Skill", 10)]
#endif
        public void RemoveSkill(string name)
        {
            Skill skill = SkillManager.Instance.GetSkill(name);

            if (skill == null) return;

            skillStorage.RemoveSkill(skill);
        }
    }
}
