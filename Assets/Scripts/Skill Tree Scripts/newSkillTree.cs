using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;

public class newSkillTree : MonoBehaviour
{
    public List<List<Skill>> skillList;
    private List<Skill> attacksList;
    private List<Skill> utilityList;
    private List<Skill> passiveList;

    private GameObject skillType;
    private Image skillImage;
    private TMP_Text skillPointsText;
    private int skillPoints = 20;

    public class Skill
    {
        public string name;
        public Sprite sprite;
        public bool isRune;
        public bool unlocked;

        public Skill(string skiillName, bool rune)
        {
            name = skiillName;
            sprite = Resources.Load<Sprite>("Shitty Icons/" + name);
            isRune = rune;
            unlocked = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        attacksList = new List<Skill>()
        {
            new Skill("Sowilo", true),
            new Skill("Flamethrower", false),
            new Skill("Thurisaz", true),
            new Skill("Lightning Smite", false),
            new Skill("Hagalaz", true),
            new Skill("Hail", false),
            new Skill("Isa", true),
            new Skill("Ice Rock Wall", false),
            new Skill("Ehwaz", true),
        };

        utilityList = new List<Skill>()
        {
            new Skill("Ansuz", true),
            new Skill("Wunjo", true),
            new Skill("Heal in Forcefield", false),
            new Skill("Algiz", true),
            new Skill("Damage in Forcefield", false),
            new Skill("Uruz", true),
            new Skill("Kenaz", true),
        };

        passiveList = new List<Skill>()
        {
            new Skill("Nauthiz", true),
            new Skill("Raidho", true),
            new Skill("Perthro", true),
        };

        skillList = new List<List<Skill>>
        {
            attacksList, utilityList, passiveList,
        };

        for (int i = 0; i < 3; i++)
        {
            skillType = transform.GetChild(i+1).gameObject;
            for (int j = 0; j < skillList[i].Count; j++)
            {
                skillImage = skillType.transform.GetChild(j).GetComponent<Image>();
                skillImage.sprite = skillList[i][j].sprite;
                skillImage.name = skillList[i][j].name;
                if (!skillList[i][j].unlocked)
                {
                    skillImage.color = Color.black;
                }
            }
        }
        skillPointsText = transform.GetChild(4).GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            skillType = transform.GetChild(i+1).gameObject;
            for (int j = 0; j < skillList[i].Count; j++)
            {
                skillImage = skillType.transform.GetChild(j).GetComponent<Image>();
                if (!skillList[i][j].unlocked)
                {
                    skillImage.color = Color.black;
                }
                else
                {
                    skillImage.color = Color.white;
                }
            }
        }
        skillPointsText.text = "Skill Points: " + skillPoints;
    }

    public void UnlockSkill()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < skillList[i].Count; j++)
            {
                if (skillList[i][j].name == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name && skillPoints > 0 && !skillList[i][j].unlocked)
                {
                    if (!skillList[i][j].isRune && (skillList[i][j-1].unlocked && skillList[i][j+1].unlocked) || (skillList[i][j].isRune))
                    {
                        skillList[i][j].unlocked = true;
                        skillPoints--;
                    }
                }
            }
        }
    }
}