using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private List<Transform> points;

        public List<Transform> Points { get => points; }
    }
}

