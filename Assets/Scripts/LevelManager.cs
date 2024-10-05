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

    private void Awake()
    {
        main = this;
    }
}
