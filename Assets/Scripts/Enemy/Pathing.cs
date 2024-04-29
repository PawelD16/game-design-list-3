using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathing : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints = new();

    public List<Transform> Waypoints { get { return waypoints; } }
}
