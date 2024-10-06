using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTowerManager : MonoBehaviour
{
    public static GhostTowerManager Instance { get; private set; }

    private GameObject ghostTower;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowGhostTower(GameObject towerPrefab, Vector3 position, Color color, float opacity)
    {
        if (ghostTower != null)
        {
            Destroy(ghostTower);
        }

        ghostTower = Instantiate(towerPrefab, position, Quaternion.identity);
        SetGhostTowerRangeColor(ghostTower, color, opacity);
        SetGhostTowerOpacity(ghostTower, opacity);
        ActivateRangeComponent(ghostTower, true);
        DisableAttackComponent(ghostTower, true); // ensure the ghost tower doesn't attack
    }

    public void HideGhostTower()
    {
        if (ghostTower != null)
        {
            Destroy(ghostTower);
            ghostTower = null;
        }
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
            {
                color.a = opacity;
                rangeRenderer.color = color;
            }
        }
    }
    private void ActivateRangeComponent(GameObject tower, bool isActive)
    {
        Transform rangeTransform = tower.transform.Find("Range");
        if (rangeTransform != null)
        {
            rangeTransform.gameObject.SetActive(isActive);
        }
    }

    private void DisableAttackComponent(GameObject tower, bool isDisabled)
    {
        Tower ghostTower = tower.GetComponent<Tower>();
        ghostTower.SetBPS(0f);
    }
}
