using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class StartOptions : MonoBehaviour
{
    private PlayMusic playMusic;                                        //Reference to PlayMusic script
    private Pause pause;
    private float fastFadeIn = .01f;                                    //fade time
    private ShowPanels showPanels;                                      //reverence to script
    public int sceneToStart = 1;                                        //sets scene to start in
    public bool changeScenes = true;                                    //If true, load a new scene when Start is pressed.
    public bool changeMusicOnStart;

    public AnimationClip fadeColorAnimationClip;                        //Animation clip for fade
    [HideInInspector]public bool inMainMenu = true;                     //If true, pause button disabled in main menu     
    [HideInInspector]public Animator animColorFade;
    [HideInInspector]public Animator animMenuAlpha;
    [HideInInspector]public AnimationClip fadeAlphaAnimationClip;       //Reference to ShowPanels script

    private static StartOptions startOptions;
    public static StartOptions Instance
    {
        get
        {
            if (!startOptions) startOptions = FindObjectOfType<StartOptions>();
            return startOptions;
        }
    }

    void Awake()
	{
        //Get a reference to ShowPanels
        showPanels = GetComponent<ShowPanels> ();

        //Get a reference to PlayMusic
        playMusic = GetComponent<PlayMusic> ();

        pause = GetComponent<Pause>();
	}


	public void BuyCards()
	{

        //If changeMusicOnStart is true, fade out volume of music
        if (changeMusicOnStart) 
		{
			playMusic.FadeDown(fadeColorAnimationClip.length);
		}

            //Call the StartGameInScene function to start game without loading a new scene.
        //StartGameInScene();
        showPanels.ShowBuyCardsPanel();
        showPanels.HideMenu();
        

    }

    public void MainMenu()
    {

        //If changeMusicOnStart is true, fade out volume of music
        if (changeMusicOnStart)
        {
            playMusic.FadeDown(fadeColorAnimationClip.length);
        }

        //Call the StartGameInScene function to start game without loading a new scene.
        showPanels.HideBuyCardsPanel();
        showPanels.HideCardCollectionPanel();
        //StartGameInScene();
        showPanels.ShowMenu();
       

    }

    public void ShowCollection()
    {

        //If changeMusicOnStart is true, fade out volume of music
        if (changeMusicOnStart)
        {
            playMusic.FadeDown(fadeColorAnimationClip.length);
        }

        showPanels.HideMenu();
        showPanels.ShowCardCollectionPanel();
    }

	public void PlayNewMusic()
	{
        //Fade music 
        playMusic.FadeUp (fastFadeIn);
        //Play selected music
        playMusic.PlaySelectedMusic (1);
	}
}
