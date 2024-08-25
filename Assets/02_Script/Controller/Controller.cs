using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ControllerSystem
{
    public static class Controller
    {

        public static T GetController<T>()
        {
            return ControllerContainer.Instance.GetController<T>();
        }

        public static IController<T> GetIController<T>()
        {
            return ControllerContainer.Instance.GetIController<T>();
        }
    }
}


