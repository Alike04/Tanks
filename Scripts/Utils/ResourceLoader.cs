using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class ResourceLoader : MonoBehaviour
    {
        public static T Load<T>(string path) where T : UnityEngine.Object
        {
            return Resources.Load<T>(path);
        }
    }
}

