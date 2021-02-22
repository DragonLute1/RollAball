using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PPSceneResetScript : MonoBehaviour
{
    public void SceneReload()
    {
        SceneManager.LoadScene(0);
    }
}
