using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void NewGameBtn(string newGameLevel)
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGameBtn()
    {
        Application.Quit();
    }
}
