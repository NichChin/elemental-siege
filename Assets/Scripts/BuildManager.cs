using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private BaseTower[] towers;

    
    private int selectedTower;



    private void Awake()
    {
        main = this;
    }

    public BaseTower GetSelectedTower()
    {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower)
    {
        print(_selectedTower);
        selectedTower = _selectedTower;
    }
}
