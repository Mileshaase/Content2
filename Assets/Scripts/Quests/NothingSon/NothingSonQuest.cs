using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static QuestLog;

public class NothingSonQuest : MonoBehaviour
{
    public GameManager GM;
    public QuestManager questManager;
    public QuestLog questLog;
    public newSkillTree skillTree;

    public GameObject player;
    public GameObject momGnome;
    public GameObject GnomeHouse;
    public GameObject Berry;
    public GameObject Wood;

    //public Transform[] LocationsOfItems;
    public bool questStarted;
    public int numBerry;
    public int numWood;
    public bool itemsCollected;
    

    public void Start()
    {
        //questStarted = true;
        questStarted = false;
        itemsCollected = false;
        numBerry = 2;
        numWood = 3;
        Debug.Log("Quest started is: " + questStarted);
        //Update Quest Log (start)
    }

    public void Update()
    {
        //float distanceGnomeHouse = Vector3.Distance(player.transform.position, GnomeHouse.transform.position);
        float distanceGnome = Vector3.Distance(player.transform.position, momGnome.transform.position);

        if ( distanceGnome < 3 && Input.GetKeyDown(KeyCode.E))
        {
            questStarted = true;
            questManager.allQuests["Good For Nothing Son"].isActive = true;
            //Gnome Dialogue with Player
            TalkToGnome();
            Debug.Log("Talking to Mom Gnome");
        }

        if (questStarted)
        {
            //float distanceBerry = Vector3.Distance(Player.transform.position, Berry.transform.position);
            //float distanceWood = Vector3.Distance(Player.transform.position, Wood.transform.position);

            if (numWood <= 0 && numBerry <= 0)
            {
                itemsCollected = true;
                Debug.Log("Quest nearly complete");
                //Update Quest Log (done)
            }

            if (itemsCollected && (distanceGnome < 2))
            {
                Debug.Log("Quest Complete!");
                questManager.allQuests["Good For Nothing Son"].isActive = false;
                skillTree.skillPoints += 3;
            }
        }

    }

    //Starting Quest
    public void StartQuest()
    {
        questStarted = true;
    }

    // Logic for Gnome Dialogue
    public void TalkToGnome()
    {
        
    }

/*    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Berry")
        {
            Debug.Log("berry collect");
            numBerry--;
            Debug.Log("num of berry: " + numBerry);
        }
        if(other.tag == "Wood")
        {
            Debug.Log("wood collect");
            numWood--;
            Debug.Log("num of wood: " + numWood);
        }
    }
*/

}