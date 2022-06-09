using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Camera
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;
        private UnityEngine.Camera _camera;
        private bool _isTrace;
        private void Awake()
        {
            _camera = UnityEngine.Camera.main;
        }
        private void Start()
        {
            GameManager.Instance.OnStart += () => { _isTrace = true; };
        }
        private void Update()
        {
            if (!_isTrace) return;
            var points = GameManager.Instance.GetPlayersPosition();
        }
    }
}

