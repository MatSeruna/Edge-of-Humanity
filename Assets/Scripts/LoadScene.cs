using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void GoToScene(int id)
    {
        SceneManager.LoadScene(id);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GoToScene(2);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
