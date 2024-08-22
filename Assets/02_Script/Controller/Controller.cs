using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ControllerSystem
{
    public static class Controller
    {

        public static T GetController<T>()
        {
            return ControllerContainer.Instance.GetController<IController<T>>().Cast<T>();
        }
    }
}


