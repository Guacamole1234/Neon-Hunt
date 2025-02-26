

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    private int m_CurrentWaypointIndex = 0; // Inicializa correctamente el índice

    void Start()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("No hay waypoints asignados.");
            return;
        }

        navMeshAgent.updateRotation = false; // ?? Desactiva la rotación automática del NavMeshAgent
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
    }


    void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
            {
                // Cambia al siguiente waypoint de forma cíclica
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);

                // ?? Aplicar rotación manualmente en el eje X (-90 grados) y mantener Y y Z
                transform.rotation = Quaternion.Euler(-90, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
    }

}
