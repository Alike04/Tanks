using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Player
{
    public class DefaultMover : IMover
    {
        private Player _player;
        private string _moveAxis;
        private string _turnAxis;
        private float _inputMoveValue;
        private float _inputTurnValue;
        MoveSettings _moveSettings;

        public void FixedTick()
        {
            Move();
            Turn();
        }

        public void Tick()
        {
            _inputMoveValue = Input.GetAxis(_moveAxis);
            _inputTurnValue = Input.GetAxis(_turnAxis);
        }
        private void Move()
        {
            Vector3 movement = _player.transform.forward * _moveSettings.moveBaseSpeed;
        }
        private void Turn()
        {
            float turn = _inputTurnValue * Time.deltaTime * _moveSettings.turnBaseSpeed;

            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

            _player.Rigidbody.MoveRotation(_player.Rigidbody.rotation * turnRotation);
        }

        public void Init(Player player, MoveSettings settings)
        {
            _moveAxis = "Vertical" + _player.Number;
            _turnAxis = "Horizontal" + _player.Number;
            _moveSettings = settings;
            _player = player;
        }
    }
}

