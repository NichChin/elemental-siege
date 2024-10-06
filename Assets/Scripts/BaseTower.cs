using System;
using UnityEngine;

[Serializable]
public class BaseTower
{

    public string name;
    public int cost;
    public GameObject prefab;

    public BaseTower(string _name, int _cost, GameObject _prefab)
    {
        name = _name; 
        cost = _cost; 
        prefab = _prefab;
    }

}
