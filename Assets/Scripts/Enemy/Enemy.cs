using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Shootable
{
    [SerializeField] private string currentState;
    [SerializeField] private Pathing pathing;

    private StateMachine stateMachine;
    public NavMeshAgent NavMeshAgent { get; private set; }
    public Pathing Pathing { get => pathing; }

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        NavMeshAgent = GetComponent<NavMeshAgent>();

        stateMachine.Initialize();
    }

    protected override void AbstractKillShootable()
    {
        // animation!
    }
}
