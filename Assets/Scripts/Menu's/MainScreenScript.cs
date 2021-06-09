using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScreenScript : MonoBehaviour
{
    // Functon to start gae

    public void start()
    {
        //Debug.Log("Options");
        SceneManager.LoadScene("Play"); // Loads Play Scnene
    }

    // Function to open options
    public void options()
    {
        //Debug.Log("Options");
        SceneManager.LoadScene("Options"); // Loads Options Scnene
    }

    // Function to open Extra
    public void Extra()
    {
        //Debug.Log("Extra");
        SceneManager.LoadScene("Extra"); // Loads Extra Scnene
    }

    // Function to close game
    public void exitgame()
    {
        //Debug.Log("exitgame");
        Application.Quit(); // Closes game
    }

    public void click()
    {
        //Debug.Log("clicked");
    }
}