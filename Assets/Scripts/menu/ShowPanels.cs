using UnityEngine;
using System.Collections;

public class ShowPanels : MonoBehaviour
{

	public GameObject optionsPanel;							//Store a reference to the Game Object OptionsPanel 
	public GameObject optionsTint;							//Store a reference to the Game Object OptionsTint 
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;							//Store a reference to the Game Object PausePanel 
    public GameObject BuyCardsPanel;                        //Store a reference to the Game Object BuyCardsPanel 
    public GameObject CardCollectionPanel;                  //Store a reference to the Game Object CardCollectionPanel 
    public GameObject PackPanel;                            //Store a reference to the Game Object PackPanel 
    
    public void ShowOptionsPanel()
	{
		optionsPanel.SetActive(true);
		optionsTint.SetActive(true);
	}

	//Call this function to deactivate and hide the Options panel during the main menu
	public void HideOptionsPanel()
	{
		optionsPanel.SetActive(false);
		optionsTint.SetActive(false);
	}

    //Call this function to activate and display the main menu panel during the main menu
    public void ShowBuyCardsPanel()
    {
        BuyCardsPanel.SetActive(true);
    }

    //Call this function to deactivate and hide the main menu panel during the main menu
    public void HideBuyCardsPanel()
    {
        BuyCardsPanel.SetActive(false);
    }

    public void ShowCardCollectionPanel()
    {
        CardCollectionPanel.SetActive(true);
    }

    
    public void HideCardCollectionPanel()
    {
        CardCollectionPanel.SetActive(false);
    }

    public void ShowPackPanel(int PackType)
    {

        switch ((CardType)PackType)
        {
            case CardType.Normal:
                if(BuyCards.Money >=500)
                {
                    PackPanel.SetActive(true);
                }
                break;

            case CardType.Rare:
                if (BuyCards.Money >= 2500)
                {
                    PackPanel.SetActive(true);
                }
                break;

            case CardType.Epic:
                if (BuyCards.Money >= 4000)
                {
                    PackPanel.SetActive(true);
                }
                break;
        }
    }
    
    //Call this function to deactivate and hide the main menu panel during the main menu
    public void HidePackPanel()
    {
        PackPanel.SetActive(false);
    }

    //Call this function to activate and display the main menu panel during the main menu
    public void ShowMenu()
	{
		menuPanel.SetActive (true);
	}

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu()
	{
		menuPanel.SetActive (false);
	}
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel()
	{
		pausePanel.SetActive (true);
		optionsTint.SetActive(true);
	}

    //Call this function to deactivate and hide the EndGamePanel during game play
    public void HidePausePanel()
	{
		pausePanel.SetActive (false);
		optionsTint.SetActive(false);

	}

}
