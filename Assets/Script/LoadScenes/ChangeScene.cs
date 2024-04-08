using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string scene;
    public GameObject image;
    public Slider slider;
    public Text text;

    public void onTurn()
    {
        image.SetActive(true);
        StartCoroutine(LoadLeaver());
    }

    IEnumerator LoadLeaver()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene); 
        while (!operation.isDone)
        {
            slider.value = operation.progress;
            text.text = (operation.progress * 100).ToString("0") + "%";
            yield return null;
        }
    }
}
