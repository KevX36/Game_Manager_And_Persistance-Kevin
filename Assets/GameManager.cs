using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        DontDestroyOnLoad(this);
        Load();
    }
    public stats Stats;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Load()
    {
        if (Stats == null)
        {
            Stats = FindAnyObjectByType<stats>();
        }
        string path = Application.persistentDataPath + "/stats.save";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();






            FileStream stream = new FileStream(path, FileMode.Open);


            try
            {
                Stats = bf.Deserialize(stream) as stats;
                Stats.UpdateStatText();
            }
            finally
            {
                stream.Close();
            }

            Debug.Log("loaded");

        }
        else { Debug.LogError("no save found"); }

        
    }
    public void Save()
    {
        if (Stats == null)
        {
            Stats = FindAnyObjectByType<stats>();
        }
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/stats.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        stats data = Stats;

        bf.Serialize(stream, data);
        stream.Close();
        Debug.Log("saved");
    }
    
    public void LoadLevel1()
    {
        SceneManager.LoadScene("level 1");
        Load();
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
        Load();
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
        Load();
    }
}
