using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
  public void OnPlayButton ()
    {
        SceneManager.LoadScene(1); //det beh�ver egentlig ikke v�re 1 den er sat til, det er bare vigtigt at den scene vi gerne vil �ndre til's 'ID' inde p� build settings er det samme som det der st�r her
    }
    public void OnQuitButton ()
    {
        Application.Quit();
        Debug.Log("quitting");
    }
}
