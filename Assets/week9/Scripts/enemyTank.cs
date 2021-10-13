using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyTank : Tank
{

    //objeye bağlı NavMeshAgent componenti alındı
    public NavMeshAgent agent {get {return GetComponent<NavMeshAgent>(); }}

    public Transform[] waypoints;
    Vector3[] waypointsPositions;

    private void Awake()
    {
        waypointsPositions = new Vector3[waypoints.Length];

        for (int i = 0; i< waypoints.Length; i++)
        {
            waypointsPositions[i] = waypoints[i].position;
        }
    }




    Animator fsm {get {return GetComponent<Animator>();}}
    protected override void Move()
    {
        //iki tank arasındaki mesafe
        //agent.SetDestination(other.position);
        float distance = Vector3.Distance(transform.position, other.position);
        fsm.SetFloat("Distanc", distance);

        float distanceFromCurrentWayPoint = Vector3.Distance(transform.position, waypointsPositions[index]);
        fsm.SetFloat("DistanceFromCurrentWayPoint", distanceFromCurrentWayPoint);
    }

    float delay;
    float freq = 3;
    public void Shoot()
    {
        //freq= saniyede kaç kere çalıştırılacağını söyler
        //eğer 5 verirsek saniyede 5 kere çalışacak
        if((delay += Time.deltaTime)>1f/freq) //saniyenin 5te birinde burası çalışacak
        {
            Fire();
            delay = 0;
            //delayin sıfırlanması gerekir yoksa çok fazla bomba atar
        }
    }

    public void Chase()
    {
        //takip edecek
        agent.SetDestination(other.position); //other=player
        //agent.isStopped = false;
    }

    public void ChaseExit()
    {
        //agent.isStopped = true;
    }
    public void Patrol()
    {
        //agent.isStopped = true;

    }

    int index;
    public void FindNewWayPoint()
    {
        switch(index)
        {
            case 0:
                index = 1;
                break;
            case 1:
                index = 0;
                break;
        }
        agent.SetDestination(waypointsPositions[index]);
    }
    
}
