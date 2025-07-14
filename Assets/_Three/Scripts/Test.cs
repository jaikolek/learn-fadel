using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Learn.Three
{
    public class Test : MonoBehaviour
    {
        private List<Skill> skillList = new List<Skill>();
        public event Action<List<Skill>> OnSkillChange;

        public void SetSkill(Skill skill)
        {
            skillList.Add(skill);
            OnSkillChange?.Invoke(skillList);
        }

        private void Start()
        {
            foreach (Skill skill in skillList)
            {
                if (skill as IUse != null)
                {
                    skill.Use();
                }
            }
        }
    }

    public class Skill : IUse, IDrop, ITick
    {
        private string name;

        public bool IsActive { get; private set; }

        public Skill(string name)
        {
            this.name = name;
        }

        public void Use()
        {
            Debug.Log($"Use : {name}");
        }

        public void Drop()
        {
            Debug.Log($"Drop : {name}");
        }

        public void Tick(float deltaTime) // update
        {
            Debug.Log($"Tick {name}");
        }
    }

    public interface IUse
    {
        public void Use();
    }

    public interface IDrop
    {
        public void Drop();
    }

    public interface ITick
    {
        public void Tick(float deltaTime);
    }
}
