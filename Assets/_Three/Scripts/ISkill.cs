using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learn.Three
{
    public interface ISkill
    {
        public string GetName(); // UI
        public void Use(); // Logic
        public void Tick();
    }
}
