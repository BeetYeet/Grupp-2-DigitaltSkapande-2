using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMaster : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas searchGameCanvas;
    public Canvas optionsCanvas;
    public void Start()
    {
        enableMainMenu();
    }

    public void enableMainMenu()
    {
        mainMenuCanvas.enabled = true;
        searchGameCanvas.enabled = true;
        optionsCanvas.enabled = false;
    }
    public void enableOptionsMenu()
    {
        mainMenuCanvas.enabled = false;
        searchGameCanvas.enabled = false;
        optionsCanvas.enabled = true;
    }
}