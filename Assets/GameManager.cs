using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this);
        Load();
    }
    public stats Stats;
    
    public void Load()
    {
        Stats = FindAnyObjectByType<stats>();



        Stats.UpdateStatText();
    }
    public void Save()
    {

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
