using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ControllerSystem
{
    public static class Controller
    {
        public static IController<T> GetController<T>()
        {
            return ControllerContainer.Instance.GetController<T>();
        }
    }
}


