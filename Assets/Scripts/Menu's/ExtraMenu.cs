using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExtraMenu : MonoBehaviour
{
    public void Credits()
    {
        //Debug.Log("Options");
        SceneManager.LoadScene("Credits"); // Loads Credit Scnene
    }

    // Function to open options
    public void Facts()
    {
        Debug.Log("Options");
        SceneManager.LoadScene("Facts"); // Loads Facts Scnene
    }

    public void extra()
    {
        //Debug.Log("Options");
        SceneManager.LoadScene("Extra"); // Loads Extra Scnene
    }
    public void Albert()
    {
        //Debug.Log("Options");
        SceneManager.LoadScene("Albert"); // Loads Albert Scnene
    }
    public void Laika()
    {
        //Debug.Log("Options");
        SceneManager.LoadScene("Laika"); // Loads Laika Scnene
    }
    public void Fel()
    {
        //Debug.Log("Options");
        SceneManager.LoadScene("Felicette"); // Loads Fel Scnene
    }
}
