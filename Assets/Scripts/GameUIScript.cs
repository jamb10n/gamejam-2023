using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameUIScript : MonoBehaviour
{
    public AudioClip GameOverSong; 
    public AudioClip VictorySong;

    public GameObject GameOverScreen;

    public GameObject VictoryScreen; 
    // Start is called before the first frame update
    void Start()
    {
        ClearScreens();
       // GameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearScreens()
    {
        GameOverScreen.SetActive(false);
        VictoryScreen.SetActive(false);
    }

    public void ShowGameOver()
    {
        StartCoroutine(GameOverScr());
    }


    IEnumerator GameOverScr()
    {
        var music = GameManager.Instance.Camera.GetComponent<AudioSource>();
        if (music != null && GameOverSong != null)
        {
            music.clip = GameOverSong;
            music.Play();
        }
        GameOverScreen.SetActive(true);
        var image = GameOverScreen.GetComponent<Image>();
        yield return StartCoroutine(FadeScreenIn(image));
        yield return new WaitForSeconds(10);
        GameManager.Instance.LoadLevel("MainMenu"); //change to load menu later on.  
    }

    public void ShowVictoryScreen()
    {
        StartCoroutine(VictoryScreenRun()); 
    }
    IEnumerator VictoryScreenRun()
    {
        var music = GameManager.Instance.Camera.GetComponent<AudioSource>();
        if (music != null && VictorySong != null)
        {
            music.clip = VictorySong;
            music.Play();
        }
        VictoryScreen.SetActive(true);
        var image = VictoryScreen.GetComponent<Image>();
        yield return StartCoroutine(FadeScreenIn(image));
        yield return new WaitForSeconds(10);
        GameManager.Instance.LoadLevel("MainMenu"); //change to load menu later on. 
    }

    IEnumerator FadeScreenIn(Image image)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0); 
        while (image.color.a < 1) 
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + 0.01f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
