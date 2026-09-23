using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI statTexts;

    public void UpdateStatText()
    {
        statTexts.text = $"Lv: {lv}\r\nHealth: {health}\r\nMana: {mana}\r\nATK: {atk}\r\nEXP:{exp}\r\nScore: {score}";
    }
    public int health = 10;
    public int exp = 0;
    public int score = 0;
    public int mana = 5;
    public int lv = 1;
    public int atk = 5;
    public static GameManager instance;
    public void LevelUp()
    {
        health += 10;
        exp += lv * 20;
        score += 100;
        mana += 5;
        lv += 1;
        atk += 5;
        UpdateStatText();
    }
    public void LevelLoss()
    {
        if (lv > 1)
        {
            health -= 10;
            exp -= (lv - 1) * 20;
            score -= 100;
            mana -= 5;
            lv -= 1;
            atk -= 5;
            UpdateStatText();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
        else
        {
            Destroy(this);
        }

            Load();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Load()
    {




        UpdateStatText();
    }
    public void Save()
    {
        
        
    }
    
    public void LoadLevel1()
    {
        Save();
        SceneManager.LoadScene("level 1");
        Load();
    }
    public void LoadLevel2()
    {
        Save();
        SceneManager.LoadScene("Level 2");
        Load();
    }
    public void LoadLevel3()
    {
        Save();
        SceneManager.LoadScene("Level 3");
        Load();
    }
}
