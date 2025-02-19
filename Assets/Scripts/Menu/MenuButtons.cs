using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject PlayNormal;
    public PlayButtonAnimations playButton;
    public GameObject PlayHover;
    public PlayHoverButtonAnimation PlayHoverAnimation;

    public GameObject Options;
    public OptionsButtonAnimation optionsButton;
    public GameObject OptionsHoverButton;

    public GameObject soundBar;
    public SoundBarAnimation soundBarAnimation;

    public GameObject Exit;
    public ExitButtonAnimation exitButton;

    public SurviveButtonAnimation surviveButton;
    public LevelButtonAnimation levelButton;

    public GameObject levelSelection;
    public GameObject comingSoon;

    //MAIN BUTTONS
    public void PlayMenuNormal()
    {
        optionsButton.GoOut();
        exitButton.GoOut();
        surviveButton.GoIn();
        levelButton.GoIn();
        Invoke("DisablePlayNormal", 0.5f);
        Invoke("EnablePlayHover", 0.5f);
    }
    public void OptionsMenu()
    {
        playButton.GoOut();
        exitButton.GoOut();
        soundBarAnimation.GoIn();
        Invoke("DisableOptionsNormal", 0.5f);
        Invoke("EnableOptionsHover", 0.5f);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


    //AFTER CLICK PLAY
    public void PlayMenuHover()
    {
        optionsButton.GoIn();
        exitButton.GoIn();
        PlayHoverAnimation.GoOut();
        surviveButton.GoOut();
        levelButton.GoOut();
        levelSelection.SetActive(false);
        Invoke("EnablePlayNormal", 0.5f);
        Invoke("DisablePlayHover", 0.5f);
    }
    public void LoadSurvive()
    {
        SceneManager.LoadScene(1);
    }
    
    public void LevelMenu()
    {
        levelSelection.SetActive(true);
        surviveButton.GoOut();
    }

    public void Level1()
    {
        SceneManager.LoadScene(3);
    }
    public void Level2()
    {
        SceneManager.LoadScene(5);
    }
    public void ComingSoon()
    {
        comingSoon.SetActive(true);
        Invoke("DisableComingSoon", 2f);
    }

    //AFTER OPTIONS

    public void OptionsHover()
    {  
        playButton.GoIn();
        exitButton.GoIn();
        soundBarAnimation.GoOut();
        Invoke("EnableOptionsNormal", 0.5f);
        Invoke("DisableOptionsHover", 0.5f);
    }

    void DisablePlayNormal()
    {
        PlayNormal.SetActive(false);
    }
    void EnablePlayNormal()
    {
        PlayNormal.SetActive(true);
    }
    void DisablePlayHover()
    {
        PlayHover.SetActive(false);
    }
    void EnablePlayHover()
    {
        PlayHover.SetActive(true);
    }


    void DisableOptionsNormal()
    {
        Options.SetActive(false);
    }
    void EnableOptionsHover()
    {
        OptionsHoverButton.SetActive(true);
    }
    void EnableOptionsNormal()
    {
        Options.SetActive(true);
    }
    void DisableOptionsHover()
    {
        OptionsHoverButton.SetActive(false);
    }




    void DisableComingSoon()
    {
        comingSoon.SetActive(false);
    }
}
