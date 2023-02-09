using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction currentAction; // This type of "IAction" must have all the methods written in it

        public void StartAction(IAction action)
        {
            if(currentAction == action) return;
            if(currentAction != null)
            {
                Debug.Log(" Cancelling" + " " + currentAction);
                action.Cancel();

            }
            currentAction = action;
        }
    }
}
