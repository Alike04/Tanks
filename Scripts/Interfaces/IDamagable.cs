using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface IDamageable
    {
        public bool IsDead { get; set; }
        public int Health { get; set; }
        public event Action OnDie;
        public void Die();
        public void TakeDamage(int amount);
    }
}

