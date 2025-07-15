using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learn.Four
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private StatUI healthUI;
        [SerializeField] private Player player;

        private void Awake()
        {
            player.OnHealthChange += healthUI.OnHealthChanged;
            player.Init();
        }
    }
}
