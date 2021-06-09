using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsScript : MonoBehaviour
{
    // Function to open Volume
    public void Volume()
    {
        //Debug.Log("Volume");
        SceneManager.LoadScene("Options_Volume"); // Loads Volume Scnene
    }

    // Function to open Controls
    public void Controls()
    {
        //Debug.Log("Controls");
        SceneManager.LoadScene("Options_Controls"); // Loads Controls Scnene
    }

    // Function to open Language
    public void Language()
    {
       // Debug.Log("Language");
        SceneManager.LoadScene("Options_Language"); // Loads Language Scnene
    }

    // Function to go back to main screen
    public void back()
    {
        //Debug.Log("Back");
        SceneManager.LoadScene("Main"); // Loads Main scene
    }
}
