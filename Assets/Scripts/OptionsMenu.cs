using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public void OnOptionsButtonPressed()
    {
        AudioManager.instance.AssignSlider();  // assign the slider when it's visible
    }
}

