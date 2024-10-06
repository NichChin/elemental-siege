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
    private bool isMouseOn = false;

    private void Start()
    {
        Color placeable = new Color(62 / 255f, 255 / 255f, 42 / 255f, 1f);
        Color notPlaceable = new Color(255 / 255f, 32 / 255f, 48 / 255f, 1f);

        startColor = sr.color;
        hoverColor = isPlaceable ? placeable : notPlaceable;
    }


    private void OnMouseEnter()
    {
        isMouseOn = true;
        sr.color = hoverColor;

        GameObject towerToBuild = BuildManager.main.GetSelectedTower();
        GhostTowerManager.Instance.ShowGhostTower(towerToBuild, transform.position, hoverColor, 0.4f);
    }

    private void OnMouseExit()
    {
        sr.color = startColor;

        if (isMouseOn) return;
        isMouseOn = false;
        
        GhostTowerManager.Instance.HideGhostTower();
    }

    private void OnMouseDown()
    {
        if (tower != null || !isPlaceable) return;

        GhostTowerManager.Instance.HideGhostTower();

        GameObject towerToBuild = BuildManager.main.GetSelectedTower();
        tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);

    }

    private void SetGhostTowerOpacity(GameObject tower, float opacity)
    {
        SpriteRenderer[] renderers = tower.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer renderer in renderers)
        {
            Color color = renderer.color;
            color.a = opacity;
            renderer.color = color;
        }
    }

    private void SetGhostTowerRangeColor(GameObject tower, Color color, float opacity)
    {
        Transform rangeTransform = tower.transform.Find("Range");
        if (rangeTransform != null)
        {
            SpriteRenderer rangeRenderer = rangeTransform.GetComponent<SpriteRenderer>();
            if (rangeRenderer != null)
            
                rangeRenderer.color = color;
                color.a = opacity;
            
        }
    }

}
