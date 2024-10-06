using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] public bool isPlaceable;

    private Color hoverColor;

    private GameObject tower;
    private Color startColor;
    private Color placeable = new Color(62 / 255f, 255 / 255f, 42 / 255f, 1f);
    private Color notPlaceable = new Color(255 / 255f, 32 / 255f, 48 / 255f, 1f);

    private void Start()
    {
        startColor = sr.color;
        hoverColor = isPlaceable ? placeable : notPlaceable;
    }


    private void OnMouseEnter()
    {
        if(BuildManager.main.GetSelectedTower().cost > LevelManager.main.GetMana() || tower != null)
        {
            sr.color = notPlaceable;
        }
        else
        {
            sr.color = placeable;
        }
        
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if (tower != null || !isPlaceable) return;

        BaseTower towerToBuild = BuildManager.main.GetSelectedTower();


        if (towerToBuild.cost > LevelManager.main.GetMana())
        {
            print("not enough moneys");
            return;
        }

        LevelManager.main.DecreaseMana(towerToBuild.cost);
        tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);

    }

}
