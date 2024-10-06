using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartRound : MonoBehaviour
{
    [SerializeField] GameObject playButton;

    private UIManager uiManager;

    public void StartR()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        uiManager.HidePauseMessage();
        Time.timeScale = 1.0f;
    }
}
