using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Interfaces
{
    public interface IShooter
    {
        public IProjectile projectile { get; set; }
        public void Init(Player.Player player);
        public void Tick();
    }
}

