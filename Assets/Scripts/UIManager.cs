using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text manaText;
    [SerializeField] private TMP_Text scoreText;

    public void UpdateMana(int mana)
    {
        manaText.text = "MANA: " + mana;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "SCORE: " + score;
    }
}
