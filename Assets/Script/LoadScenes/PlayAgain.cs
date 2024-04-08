using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayAgain : MonoBehaviour
{
    public bool onStop;
    public GameObject board;
    public string scence;
    public GameObject image;
    public Slider slider;
    public Text text;

    void Start()
    {
        onStop = false;
        board.SetActive(false);
    }

    void Update()
    {
        if (onStop)
        {
            Time.timeScale = 0f;
            board.SetActive(true);
        }
    }

    public void onTurn()
    {
        if (onStop)
        {
            Application.LoadLevel(scence);
            onStop = false;
            Time.timeScale = 1f;
            board.SetActive(false);
        }
        else
        {
            onStop = true;
        }
    }

    public void turnBack()
    {
        if (onStop)
        {
            image.SetActive(true);
            StartCoroutine(LoadLeaver());
            onStop = false;
            Time.timeScale = 1f;
            board.SetActive(false);
        }
    }

    IEnumerator LoadLeaver()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("bases");
        while (!operation.isDone)
        {
            slider.value = operation.progress;
            text.text = (operation.progress * 100).ToString("0") + "%";
            yield return null;
        }
    }
}
