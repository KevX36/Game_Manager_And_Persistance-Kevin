using UnityEngine;
using TMPro;
public class stats : MonoBehaviour
{
    public int health = 10;
    public int exp = 0;
    public int score = 0;
    public int mana = 5;
    public int lv = 1;
    public int atk = 5;
    public TextMeshProUGUI statTexts;
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
        if(lv > 1)
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
    public void UpdateStatText()
    {
        statTexts.text = $"Lv: {lv}\r\nHealth: {health}\r\nMana: {mana}\r\nATK: {atk}\r\nEXP:{exp}\r\nScore: {score}";
    }
}
