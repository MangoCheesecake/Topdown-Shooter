using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public ScreenFader sf;

    public void PlayAgain()
    {
        StartCoroutine(NewGame());
    }

    public void Quit()
    {
        StartCoroutine(MainMenu());
    }

    public IEnumerator NewGame()
    {
        yield return StartCoroutine(sf.FadeToBlack());
        SceneManager.LoadScene("Main");
        yield return StartCoroutine(sf.FadeToClear());
    }

    public IEnumerator MainMenu()
    {
        yield return StartCoroutine(sf.FadeToBlack());
        SceneManager.LoadScene("Main Menu");
        yield return StartCoroutine(sf.FadeToClear());
    }
}
