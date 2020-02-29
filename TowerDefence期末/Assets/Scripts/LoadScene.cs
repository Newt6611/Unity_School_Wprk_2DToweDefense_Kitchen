using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Animator ani;
    public Animator restartAni;

    public static bool isMenu = true;

    void Update()
    {
        if (!isMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                StartCoroutine(SceneTrasition(0));
                isMenu = true;
            }
        }
        else
        {
            return;
        }
    }

    public void LoadMainGame()
    {
        GameManager.gameTime = 120f;
        StartCoroutine(SceneTrasition(1));
        isMenu = false;
    }

    public void LoadMainMenu()
    {
        StartCoroutine(SceneTrasition(0));
        isMenu = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        isMenu = false;
        GameManager.gameTime = 120f;
        GameManager.timeCanGo = true;
        GameManager.SetWinOrLose(WinGameOrLoasGame.notYet);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator SceneTrasition(int scene)
    {
        ani.SetTrigger("end");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(scene);
    }

}
