using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public ScreenFader sf;

    public void NewGameButton()
    {
        StartCoroutine(NewGame());
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public IEnumerator NewGame()
    {
        yield return StartCoroutine(sf.FadeToBlack());
        SceneManager.LoadScene("Main");
        yield return StartCoroutine(sf.FadeToClear());
    }
}
