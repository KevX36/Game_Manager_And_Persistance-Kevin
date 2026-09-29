using System;
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

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerinfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat",FileMode.Open);
            StatData data = (StatData)bf.Deserialize(file);
            file.Close();

            health = data.health;
            exp = data.exp;
            score = data.score;
            mana = data.mana;
            lv = data.lv;
            atk = data.atk;
        }



        UpdateStatText();
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);


        StatData data = new StatData();
        data.health = health;
        data.exp = exp;
        data.score = score;
        data.mana = mana;
        data.lv = lv;
        data.atk = atk;

        bf.Serialize(file,data);
        file.Close();
    }


}
[Serializable]
class StatData
{
    public int health;
    public int exp;
    public int score;
    public int mana;
    public int lv;
    public int atk;
}
