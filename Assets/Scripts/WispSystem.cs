using System.Collections;
using UnityEngine;

public class WispSystem : MonoBehaviour
{
    public GameManager GM;
    public GameObject Wisp;
    public GameObject Player;
    public GameObject Gnome;
    public Transform[] FirstSetOfPoints;
    private bool firstPath = false;
    private bool OnFirstPath = false;
    private GameObject CurrentWisp;
    private int index;

    public QuestLog questLog;

    public void Start()
    {
        index = 0;
    }

    public void Update()
    {
        if (firstPath)
        {
            CurrentWisp = Instantiate(Wisp, FirstSetOfPoints[index].position, FirstSetOfPoints[index].rotation);
            firstPath = false;
            OnFirstPath = true;
        }

        if (OnFirstPath)
        {
            float distance = Vector3.Distance(Player.transform.position, CurrentWisp.transform.position);
            if (distance <= 4)
            {
                Destroy(CurrentWisp);
                index++;

                if (index < FirstSetOfPoints.Length)
                {
                    CurrentWisp = Instantiate(Wisp, FirstSetOfPoints[index].position, FirstSetOfPoints[index].rotation);
                }
                else
                {
                    OnFirstPath = false;

                    Debug.Log("start new Quest");
                    questLog.allQuests[0].completed = true;
                    questLog.allQuests[1].isActive = true;
                    questLog.allQuests[1].currentQuest = true;

                    StartCoroutine(GM.SaveTheGnome());
                }
            }
        }
    }

    public void StartFirstPath()
    {
        firstPath = true;
    }
}