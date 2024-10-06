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

    private void Start()
    {
        Color placeable = new Color(62 / 255f, 255 / 255f, 42 / 255f, 1f);
        Color notPlaceable = new Color(255 / 255f, 32 / 255f, 48 / 255f, 1f);

        startColor = sr.color;
        hoverColor = isPlaceable ? placeable : notPlaceable;
    }


    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if (tower != null || !isPlaceable) return;

        GameObject towerToBuild = BuildManager.main.GetSelectedTower();
        tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);

    }

}
