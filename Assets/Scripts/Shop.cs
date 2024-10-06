using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] Animator anim;

    public static Shop main;
    private bool isMenuOpen = true;
    private Outline[] outlines;
    private void Awake()
    {
        main = this;
        outlines = GetComponentsInChildren<Outline>();
    }

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("MenuOpen", isMenuOpen);
    }
    public void SetSelectedTower(int selectedTower)
    {
        switch (selectedTower)
        {
            case 0:
                outlines[0].enabled = true;
                outlines[1].enabled = false;
                outlines[2].enabled = false;
                break;
            case 1:
                outlines[0].enabled = false;
                outlines[1].enabled = true;
                outlines[2].enabled = false;
                break;
            case 2:
                outlines[0].enabled = false;
                outlines[1].enabled = false;
                outlines[2].enabled = true;
                break;
        }
    }
}