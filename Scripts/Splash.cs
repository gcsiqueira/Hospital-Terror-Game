using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Splash : MonoBehaviour
{
	public Text splashImage;
    public string loadLevel;

    IEnumerator Start() 
	{
        splashImage.canvasRenderer.SetAlpha(0.0f);

        FadeIn();

        yield return new WaitForSeconds(3.5f);

        FadeOut();

        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Menu");
    }

    void FadeIn()
    {
        splashImage.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOut()
    {
        splashImage.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}

