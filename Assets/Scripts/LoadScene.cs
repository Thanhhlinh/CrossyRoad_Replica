using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string nameScene;
    public void Loadscene()
    {
        SceneManager.LoadScene(nameScene);
    }
}
