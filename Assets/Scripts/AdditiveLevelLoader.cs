using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveLevelLoader : MonoBehaviour
{
    public string levelName;
    private Scene scene;

    // Start is called before the first frame update
    private void Start()
    {        
        SceneManager.LoadScene(levelName, LoadSceneMode.Additive);
        scene = SceneManager.GetSceneByName(levelName);
    }

    private void OnDestroy()
    {
        SceneManager.UnloadSceneAsync(scene);
    }
}
