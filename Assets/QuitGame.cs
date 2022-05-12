using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        // KJ: Put this here since some people probably don't know
        //     that in Unity Quit doesn nothing in editor! :)
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.ExitPlaymode();
        }

        Application.Quit();
    }
}
