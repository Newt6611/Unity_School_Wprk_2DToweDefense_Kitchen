using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public enum WinGameOrLoasGame
{
    win, lose, notYet
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private static int isWin;

    public GameObject sliperPre;
    public GameObject insecticidePre;
    public GameObject mouseDrugPre;
    public GameObject swatterPre;

    public GameObject toolToBuild;

    // Animation
    public Animator ResartAni;
    public Animator WinAni;

    Vector2 mousePos;
    // cursor particle
    public GameObject cursorParticle;

    // Time
    public static float gameTime = 120f;
    public TextMeshProUGUI timeText;
    float minutes;
    float second;
    public static bool timeCanGo;

    // Sound 
    public AudioSource audio;
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one GameManger in scene! ");
            return;
        }
        Instance = this;
        isWin = (int)WinGameOrLoasGame.notYet;
    }

    void Start()
    {
        timeCanGo = true;
    }

    void Update()
    {
        GameStament();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(cursorParticle, new Vector3(mousePos.x, mousePos.y, 10), Quaternion.identity);
        }

        if (timeCanGo)
        {
            gameTime -= Time.deltaTime;
        }
        else
        {
            return;
        }
        UI();

    }

    public GameObject GetToolToBuild()
    {
        return toolToBuild;
    }

    public void SetToolToBuild(GameObject tool)
    {
        toolToBuild = tool;
    }

    public static void SetWinOrLose(WinGameOrLoasGame w)
    {
        isWin = (int)w;
    }

    private void GameStament()
    {
        if (gameTime <= 0f)
        {
            SetWinOrLose(WinGameOrLoasGame.win);
            audio.Stop();
        }

        if (isWin == (int)WinGameOrLoasGame.win)
        {
            SetWinOrLose(WinGameOrLoasGame.notYet);
            WinAni.SetTrigger("win");
            LoadScene.isMenu = true;
            timeCanGo = false;
            audio.Stop();
            StartCoroutine(DelayTime(5f));
        }
        else if (isWin == (int)WinGameOrLoasGame.lose)
        {
            LoadScene.isMenu = false;
            audio.Stop();
            timeCanGo = false;
            ResartAni.SetTrigger("start");
        }
        else if (isWin == (int)WinGameOrLoasGame.notYet)
        {
            return;
        }
    }

    void UI()
    {
        minutes = Mathf.Floor(gameTime / 60);
        second = gameTime % 60;
        timeText.text = minutes + ":" + second.ToString("00");
    }

    IEnumerator DelayTime(float time)
    {
        SetWinOrLose(WinGameOrLoasGame.notYet);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(0);
    }

}
