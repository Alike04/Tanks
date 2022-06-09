using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour, IDamageable
    {
        [SerializeField] float fireRate;
        [SerializeField] private MoveSettings settings;
        private IMover _mover;
        private IShooter _shooter;
        public event Action OnDie;
        public bool IsDead { get; set; }
        public int Health { get; set; }
        public int Number { get; private set; }
        public Rigidbody Rigidbody { get; private set; }
        private IMover _defaultMover;
        private IShooter _defaultShooter;
        private void Awake()
        {
            _defaultMover = new DefaultMover();
            _defaultMover.Init(this, settings);

            _defaultShooter = new DefaultShooter();
            _defaultShooter.Init(this);

            Rigidbody = GetComponent<Rigidbody>();

            SetMover();
            SetShooter();
        }

        public void Update()
        {
            if (IsDead) return;

            _mover.Tick();
            _shooter.Tick();
        }
        private void FixedUpdate()
        {
            if (IsDead) return;

            _mover.FixedTick();
        }
        public void SetShooter(IShooter shooter)
        {
            _shooter = shooter;
            _shooter.Init(this);
        }
        public void SetShooter()
        {
            _shooter = _defaultShooter;
        }
        public void SetMover(IMover moveable)
        {
            _mover = moveable;
            _mover.Init(this, settings);
        }
        public void SetMover()
        {
            _mover = _defaultMover;
        }


        public void TakeDamage(int amount)
        {
            if (Health > 0)
            {
                Health -= amount;
            }
            if (Health < 0)
            {
                Die();
            }
        }

        public void Die()
        {
            IsDead = true;
            OnDie?.Invoke();
            throw new System.NotImplementedException();
        }
    }
}

