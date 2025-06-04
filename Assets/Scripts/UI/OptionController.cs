using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionController : MonoBehaviour
{
    public GameObject optionPanel;

    public void ShowOptions()
    {
        optionPanel.SetActive(true);
    }

    public void HideOptions()
    {
        optionPanel.SetActive(false);
    }
}
