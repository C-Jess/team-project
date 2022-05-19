using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadTesting : MonoBehaviour
{
    public string levelName;
    private Scene mainLevel;
    private Scene minigameLevel;

    // Start is called before the first frame update
    void Start()
    {
        mainLevel = SceneManager.GetActiveScene();
        
        SceneManager.LoadScene(levelName, LoadSceneMode.Additive);
        minigameLevel = SceneManager.GetSceneByName(levelName);
    }

    public void ToggleLevel()
    {
        if (mainLevel == SceneManager.GetActiveScene())
        {
            SceneManager.SetActiveScene(minigameLevel);
        }
        else
        {
            SceneManager.SetActiveScene(mainLevel);
        }
    }
}
