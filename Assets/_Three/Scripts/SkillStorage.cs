using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learn.Three
{
    [System.Serializable]
    public class SkillStorage
    {
        [SerializeField] private List<Skill> skillList = new List<Skill>();
        
        public event Action<List<Skill>> OnSkillChange;

        public void AddSkill(Skill skill)
        {
            foreach (Skill storeSkill in skillList)
            {
                if (storeSkill.Equals(skill)) // non duplicate
                {
                    return;
                }
            }

            skillList.Add(skill);
            OnSkillChange?.Invoke(skillList);
        }

        public void RemoveSkill(Skill skill)
        {
            skill.ResetSkill();
            skillList.Remove(skill);
            OnSkillChange?.Invoke(skillList);
        }

        private Skill GetSkill(string skillName)
        {
            foreach (Skill storeSkill in skillList)
            {
                if (storeSkill.GetName().Equals(skillName))
                {
                    return storeSkill;
                }
            }

            return null;
        }

        public void UseSkill(string skillName)
        {
            Skill skill = GetSkill(skillName);

            if (skill == null) return;

            skill.Use();
        }

        public void Tick()
        {
            foreach (Skill storeSkill in skillList)
            {
                storeSkill.Tick();
            }
        }
    }
}
