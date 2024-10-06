using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text manaText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text healthText;

    public void UpdateMana(int mana)
    {
        manaText.text = "MANA: " + mana;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "SCORE: " + score;
    }

    public void UpdateHealth(int health)
    {
        healthText.text = "HEALTH: " + health;
    }
}
