using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "MoveSettings")]
    public class MoveSettings : ScriptableObject
    {
        [SerializeField] public float moveBaseSpeed;
        [SerializeField] public float turnBaseSpeed;
    }
}

