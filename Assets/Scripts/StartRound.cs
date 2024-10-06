using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartRound : MonoBehaviour
{
    [SerializeField] GameObject playButton;
    public void StartR()
    {
        Time.timeScale = 1.0f;
    }
}
