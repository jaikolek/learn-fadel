using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Learn.Three
{
    public class SkillManager : MonoBehaviour
    {
        [SerializeField] private List<Skill> skillList = new List<Skill>();

        public static SkillManager Instance;

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

        public Skill GetSkill(int index)
        {
            return skillList.Count > index ? skillList[index] : null;
        }

        public Skill GetSkill(string name)
        {
            foreach (Skill skill in skillList)
            {
                if (skill.GetName().Equals(name))
                {
                    return skill;
                }
            }

            return null;
        }
    }
}
