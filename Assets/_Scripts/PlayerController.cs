using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    Mover mover;
    private void Start() 
    {
        mover = GetComponent<Mover>();
    }

    private void Update() 
    {
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();
        }
    }
    
    public void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            mover.MoveTo(hit.point);
        }
    }
}
