using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BetweenLevels : MonoBehaviour
{
    public Image blackScreen;
    public float fadeDuration = 1.0f;

    #region Levels

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void GoToLevel1()
    {
        StartCoroutine(FadeOut(1));
    }

    public void GoLevel2()
    {
        StartCoroutine(FadeOut(2));
    }

    public void GoLevel3()
    {
        StartCoroutine(FadeOut(3));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion

    #region FADES

    public IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color color = blackScreen.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            blackScreen.color = color;
            yield return null;
        }

        color.a = 0f;
        blackScreen.color = color;
        blackScreen.enabled = false;
    }

    public IEnumerator FadeOut(int sceneIndex)
    {
        blackScreen.enabled = true;
        float elapsedTime2 = 0f;
        Color color = blackScreen.color;

        while (elapsedTime2 < fadeDuration)
        {
            elapsedTime2 += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, elapsedTime2 / fadeDuration);
            blackScreen.color = color;
            yield return null;
        }

        color.a = 1f;
        blackScreen.color = color;

        SceneManager.LoadScene(sceneIndex);

        
    }

    #endregion
}
