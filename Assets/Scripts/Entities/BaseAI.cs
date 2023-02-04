using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(AttributeComponent))]
public class BaseAI : BaseEntityController
{
    public List<Vector3> Waypoints;

    public int CurrentWaypoint = 0; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void DumbMoveToTarget(Vector3 target)
    {
        if (Vector3.Distance(transform.position, target) <0.1f)
        {
            MovementController.Direction = MovementDirection.None;
            return; 
        }

        var distance = transform.position - target;
        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            if (distance.x > 0)
            {
                MovementController.Direction = MovementDirection.Left;
            }
            else
                MovementController.Direction = MovementDirection.Right; 
        }
        else
        {
            if (distance.y > 0)
            {
                MovementController.Direction = MovementDirection.Down;
            }
            else
                MovementController.Direction = MovementDirection.Up; 
        }

        
    }


    protected void WaypointMove()
    {
        if (Waypoints.Count < 1) { return; }

        DumbMoveToTarget(Waypoints[CurrentWaypoint]);
        if (Vector3.Distance(transform.position, Waypoints[CurrentWaypoint]) < 0.1f)
        {
            CurrentWaypoint++; 
            if (CurrentWaypoint >= Waypoints.Count)
            {
                CurrentWaypoint = 0;
            }
        }
    }
}
