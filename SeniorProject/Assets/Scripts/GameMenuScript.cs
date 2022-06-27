using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour
{

 public void NewGame () 
 {
  SceneManager.LoadScene("Game");
 }
 
 public void QuitGame ()
 {
  Debug.Log ("QUIT!");
  Application.Quit();
 }
  
}
