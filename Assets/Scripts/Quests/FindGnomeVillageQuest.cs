using UnityEngine;
using UnityEngine.AI;

public class FindGnomeVillageQuest : MonoBehaviour
{
    public GameManager GM;
    public GameObject Player;
    public NavMeshAgent Gnome;
    public Transform[] path;
    public bool OnFirstPath = false;
    private int index;
    public QuestLog questLog;

    public void Start()
    {
        index = 0;
    }

    public void Update()
    {
        if (OnFirstPath)
        {
            float distance = Vector3.Distance(Player.transform.position, Gnome.transform.position);
            if (distance <= 4)
            {
                if (!Gnome.pathPending && Gnome.remainingDistance < 0.1f)
                {
                    index++;
                    if (index < path.Length)
                    {
                        MoveToNextWaypoint();
                    }
                }
            }
        }
    }

    void MoveToNextWaypoint()
    {
        // Set the next waypoint as the target destination
        Gnome.SetDestination(path[index].position);
    }

    public void StartPath()
    {
        OnFirstPath = true;
        // Start moving towards the first waypoint
        Gnome.SetDestination(path[index].position);
    }
}