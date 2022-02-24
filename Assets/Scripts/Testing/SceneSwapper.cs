using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : ScriptableObject
{
    // TODO: This class isn't finished and needs to be checked. -KJ
    // Didn't finish it due to no answer on how the minigames are gonna
    // be 2D or 2.5D so just gonna do 2D since it's faster right now.

    string defaultSceneName;
    Scene defaultScene;
    Scene scene;
    bool inMinigame = false;

    void ChangeScene(string sceneToLoad)
    {
        // KJ: This is a gate, we stop everything we don't
        // want to come through!
        if (!inMinigame) return; // Stop if in minigame
        if (!IsVaildScene(sceneToLoad)) 
        {
            Debug.LogError($"Can't Load \"{sceneToLoad}\"");
            return; // Stop if invalid name
        }

        inMinigame = true;
        LoadSceneParameters parameters = new LoadSceneParameters(LoadSceneMode.Additive);
        scene = SceneManager.LoadScene(sceneToLoad, parameters);
    }

    void BackToMain()
    {
        SceneManager.UnloadSceneAsync(scene);
    }

    bool IsVaildScene(string name)
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < sceneCount; i++)
        {
            if (SceneManager.GetSceneByBuildIndex(i).name == name)
            {
                return true;
            }
        }
        return false;
    }
}
