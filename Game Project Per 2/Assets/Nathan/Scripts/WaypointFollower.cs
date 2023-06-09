using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{    
    private int _currentWaypointIndex = 0;

    [Header("Platform Speed")]
    [SerializeField] private float _speed = 2f;

    [Header("Platform Waypoints")]
    [SerializeField] private GameObject[] _waypoints;

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(_waypoints[_currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            _currentWaypointIndex++;
        }
        if (_currentWaypointIndex >= _waypoints.Length)
        {
            _currentWaypointIndex = 0;
        }

        transform.position = Vector2.MoveTowards(
            transform.position, 
            _waypoints[_currentWaypointIndex].transform.position, 
            Time.deltaTime * _speed);

    }
}
