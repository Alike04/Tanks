using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Player
{
    public class DefaultShooter : IShooter
    {
        public IProjectile projectile { get; set; }

        public void Init(Player player)
        {
            
        }

        public void Tick()
        {
            
        }
    }
}

