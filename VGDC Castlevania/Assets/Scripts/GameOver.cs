using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour {

    //public void Quit()
    //{
    //    Debug.Log("Quit");
    //    Application.Quit();
    //}

    //public void Retry()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

    private void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle(GUI.skin.button);
        myStyle.fontSize = 72;
        myStyle.normal.textColor = Color.gray;
        myStyle.hover.textColor = Color.white;

        if(GUI.Button(new Rect(640, Screen.height/2+50, 200, 100), "Retry", myStyle))
        {
            SceneManager.LoadScene("Scene1");
        }
        if (GUI.Button(new Rect(360, Screen.height/2+50, 200, 100), "Quit", myStyle))
        {
            Application.Quit();
        }
    }
}
