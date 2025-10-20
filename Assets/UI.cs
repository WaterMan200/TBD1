using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{

    private float timer;
    private bool startTimer;
    private bool paused = false;
    public GameObject player1;
    public GameObject player2;
    public GameObject pauseScreen;
    public GameObject endScreen;
    public GameObject connectorScreen;
    public GameObject gameScreen;
    public GameObject mainScreen;
    public GameObject cardScreen;
    public TextMeshProUGUI gameScreenTimerText;
    public TextMeshProUGUI playerWinText;

    void Start()
    {
        timer = 3f;
        Time.timeScale = 0f;
    }
    void Update()
    {
        if(startTimer == true)
        {
            timer -= Time.unscaledDeltaTime;
            gameScreenTimerText.text = ("" + Mathf.CeilToInt(timer));
            Debug.Log(timer);
            if(timer <= 0f)
            {
                PlayerMove playerMove1 = player1.GetComponent<PlayerMove>();
                PlayerMove playerMove2 = player2.GetComponent<PlayerMove>();
                playerMove1.RoundStart();
                playerMove2.RoundStart();
                gameScreen.transform.GetChild(0).gameObject.SetActive(false);
                gameScreen.transform.GetChild(1).gameObject.SetActive(false);
                Time.timeScale = 1f;
                startTimer = false;
                timer = 3f;
            }
        }
    }
    public void StartGame()
    {
        startTimer = true;
    }
    public void Pause()
    {
        if(paused != true)
        {
            pauseScreen.SetActive(true);
            GameObject button = pauseScreen.transform.GetChild(1).gameObject;
            EventSystem.current.SetSelectedGameObject(button);
            paused = true;
            Time.timeScale = 0f;
        }
    }
    public void UnPause()
    {
        if(paused)
        {
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
            paused = false;
        }
    }
    public void ControllersConnected()
    {
        PlayerMove playerMove1 = player1.GetComponent<PlayerMove>();
        PlayerMove playerMove2 = player2.GetComponent<PlayerMove>();
        if(playerMove1.P1Player())
        {
            if(playerMove2.P2Player())
            {
                connectorScreen.SetActive(false);
                mainScreen.SetActive(true);
                GameObject button = mainScreen.transform.GetChild(1).gameObject;
                EventSystem.current.SetSelectedGameObject(button);
            }
        }
    }
    public void P1Win()
    {
        gameScreen.SetActive(false);
        endScreen.SetActive(true);
        GameObject button = endScreen.transform.GetChild(1).gameObject;
        EventSystem.current.SetSelectedGameObject(button);
        playerWinText.text = "Player 1 Wins";
        Time.timeScale = 0f;
    }
    public void P2Win()
    {
        gameScreen.SetActive(false);
        endScreen.SetActive(true);
        GameObject button = endScreen.transform.GetChild(1).gameObject;
        EventSystem.current.SetSelectedGameObject(button);
        playerWinText.text = "Player 2 Wins";
        Time.timeScale = 0f;
    }
    public void P1Round()
    {
        gameScreen.SetActive(false);
        cardScreen.SetActive(true);
        GameObject button = cardScreen.transform.GetChild(1).gameObject;
        EventSystem.current.SetSelectedGameObject(button);
        Time.timeScale = 0f;
    }
    public void P2Round()
    {
        gameScreen.SetActive(false);
        cardScreen.SetActive(true);
        GameObject button = cardScreen.transform.GetChild(1).gameObject;
        EventSystem.current.SetSelectedGameObject(button);
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        endScreen.SetActive(false);
        mainScreen.SetActive(true);
        GameObject button = mainScreen.transform.GetChild(1).gameObject;
        EventSystem.current.SetSelectedGameObject(button);
        PlayerMove playerMove1 = player1.GetComponent<PlayerMove>();
        PlayerMove playerMove2 = player2.GetComponent<PlayerMove>();
        playerMove1.Start();
        playerMove2.Start();
        gameScreen.transform.GetChild(0).gameObject.SetActive(true);
        gameScreen.transform.GetChild(1).gameObject.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
