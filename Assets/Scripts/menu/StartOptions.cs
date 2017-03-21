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

     //Once the level has loaded, check if we want Music
    void OnLevelWasLoaded()
	{
		//if changeMusicOnStart is true, call the PlayLevelMusic function of playMusic
		if (changeMusicOnStart)
		{
			playMusic.PlayLevelMusic ();
		}	
	}


	public void LoadDelayed()
	{
        //Call HideMenu function in showPanels to hide the main menu
        showPanels.HideMenu ();

        //Load the selected scene
        SceneManager.LoadScene (sceneToStart);
	}

	public void HideDelayed()
	{
        //Call HideMenu function in showPanels to hide the main menu
        showPanels.HideMenu();
	}

	public void StartGameInScene()
	{
        //Pause button now works since we are no longer in Main menu.
        inMainMenu = false;

		//If changeMusicOnStart is true, fade out volume of music 
		if (changeMusicOnStart) 
		{
			//Wait until game has started, then play new music
			Invoke ("PlayNewMusic", fadeAlphaAnimationClip.length);
		}
		//Set trigger for animator to start animation fading out Menu UI
		animMenuAlpha.SetTrigger ("fade");
		Invoke("HideDelayed", fadeAlphaAnimationClip.length);
		
	}


	public void PlayNewMusic()
	{
        //Fade music 
        playMusic.FadeUp (fastFadeIn);
        //Play selected music
        playMusic.PlaySelectedMusic (1);
	}
}
