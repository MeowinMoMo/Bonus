using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    [SerializeField] private GameObject[] Guide;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;


    private void Update()
    {
        if(Vector2.Distance(Guide[currentWaypointIndex].transform.position, transform.position) < 1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= Guide.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, Guide[currentWaypointIndex].transform.position, Time.deltaTime * speed );

    }
}
