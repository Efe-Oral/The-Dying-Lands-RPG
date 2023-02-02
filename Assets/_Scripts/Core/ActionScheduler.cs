using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ActionScheduler : MonoBehaviour
    {
        MonoBehaviour currentAction;

        public void StartAction(MonoBehaviour action)
        {
            if(action != null)
            {
                currentAction = action;
                Debug.Log("Cancelling" + currentAction);
            }
        }
    }
}
