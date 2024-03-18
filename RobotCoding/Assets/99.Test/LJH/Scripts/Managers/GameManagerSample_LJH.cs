using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Legacy.LJH
{

    public class GameManagerSample_LJH : Singleton<GameManagerSample_LJH>
    {
        [SerializeField] private Player player;
        public Player Player => player;
    }
}