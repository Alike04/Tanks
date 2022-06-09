using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Interfaces
{
    public interface IMover
    {
        public void Tick();
        public void FixedTick();
        void Init(Player.Player player, MoveSettings settings);
    }
}

