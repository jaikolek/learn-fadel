using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learn.Three
{
    public enum RoleType
    {
        Global,
        Wizard,
        Knight,
        Scout,
    }

    [CreateAssetMenu(fileName = "Skill", menuName = "Skill/Skill")]
    public class Skill : ScriptableObject, ISkill
    {
        [SerializeField] private string skillName;
        [SerializeField] private RoleType roleType;
        [SerializeField] private float cooldown;

        private float cooldownTime;
        public float CooldownTime
        {
            get => cooldownTime;
            set
            {
                cooldownTime = value;
                OnCooldown?.Invoke(value);
            }
        }

        public event Action<float> OnCooldown;
        public event Action OnSkillReady;

        public bool IsCooldown { get; private set; }

        private void Awake()
        {
            cooldownTime = 0f;
        }

        public virtual string GetName()
        {
            return skillName;
        }

        public virtual void Use()
        {
            IsCooldown = true;
            CooldownTime = cooldown;

            Debug.Log($"Use {skillName}");
        }

        public virtual void Tick()
        {
            // logic skill

            if (!IsCooldown) return;

            if (CooldownTime > 0)
            {
                CooldownTime -= Time.deltaTime;
            }
            else
            {
                IsCooldown = false;
                OnSkillReady?.Invoke();
            }
        }
    }
}
