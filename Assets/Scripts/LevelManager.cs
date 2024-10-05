using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    [SerializeField] public Transform startPoint;
    [SerializeField] public Transform[] path;

    [SerializeField] private int mana; // for testing purposes to edit in the inspector
    [SerializeField] private int score; // for testing purposes to edit in the inspector

    private UIManager uiManager;

    private void Awake()
    {
        main = this;
    }

    private void Start() {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        uiManager.UpdateMana(mana);
        uiManager.UpdateScore(score);
    }

    public void IncreaseMana(int amount) {
        mana += amount;
        uiManager.UpdateMana(mana);
        Debug.Log("Mana increased. Current mana: " + mana);
    }

    public void IncreaseScore(int amount) {
        score += amount;
        uiManager.UpdateScore(score);
        Debug.Log("Score increased. Current score: " + score);
    }

    public int GetMana()
    {
        return mana;
    }
}
