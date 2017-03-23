using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class BuyCards : MonoBehaviour
{
    #region variables
    public int NumberOfCardsEachPack = 5;
    public int Luck;
    public Text AngelText;
    public Text UnicornText;
    public Text JokerText;
    public Text MasterOfMusicText;
    public Text MysticText;
    public Text HoundMasterText;
    public Text PackPanelText;
    public Text MoneyText;
    public int LootTable;
    public int AngelCount;
    public int UnicornCount;
    public int JokerCount;
    public int MasterOfMusicCount;
    public int MysticCount;
    public int HoundMasterCount;
    public static int Money = 10000;
    #endregion

    public void Awake()
    {
        MoneyText.text = "Money:" + Money.ToString();
    }
    public void SellACard(int CardSold)
    {
        switch ((CardSort)CardSold)
        {
            case CardSort.Angel:
                if (AngelCount>=1)
                {
                    AngelCount--;
                    Money += 500;
                }

                break;

            case CardSort.Unicorn:
                if (UnicornCount >= 1)
                {
                    UnicornCount--;
                    Money += 500;
                }

                break;

            case CardSort.Joker:
                if (JokerCount >= 1)
                {
                    JokerCount--;
                    Money += 250;
                }

                break;
            case CardSort.MasterOfMusic:
                if (MasterOfMusicCount >= 1)
                {
                    MasterOfMusicCount--;
                    Money += 250;
                }

                break;

            case CardSort.Mystic:
                if (MysticCount >= 1)
                {
                    MysticCount--;
                    Money += 50;
                }

                break;

            case CardSort.Houndmaster:
                if (HoundMasterCount >= 1)
                {
                    HoundMasterCount--;
                    Money += 50;
                }

                break;
        }
        AngelText.text = AngelCount.ToString();
        UnicornText.text = UnicornCount.ToString();
        JokerText.text = JokerCount.ToString();
        MasterOfMusicText.text = MasterOfMusicCount.ToString();
        HoundMasterText.text = HoundMasterCount.ToString();
        MysticText.text = MysticCount.ToString();
        MoneyText.text = "Money:" +Money.ToString();
    }

    public void BuyTheCards(int PackType)
    {
        string DrawnCards = "";

        switch ((CardType)PackType)
        {
            case CardType.Normal:
                if(Money >= 500)
                {
                    Money -= 500;
                }
                else
                {
                    return;
                }
                break;

            case CardType.Rare:
                if (Money >= 2500)
                {
                    Money -= 2500;
                }
                else
                {
                    return;
                }
                break;

            case CardType.Epic:
                if (Money >= 4000)
                {
                    Money -= 4000;
                }
                else
                {
                    return;
                }
                break;
        }

        for (int i = 0; i < NumberOfCardsEachPack; i++)
        {
           int rareValue = 0;
           int epicValue = 0;
           

            switch ((CardType)PackType)
           {
               case CardType.Normal:
                   rareValue = 40;
                   epicValue = 10;
                   break;

               case CardType.Rare:

                   rareValue = 60;
                   epicValue = 20;
                    break;

               case CardType.Epic:
                   rareValue = 80;
                   epicValue = 30;
                   break;
           }
            MoneyText.text = "Money:" + Money.ToString();
            Luck = Random.Range(0, 100);
            LootTable = Random.Range(0, 100);

           if (Luck <= epicValue)
           {
                if(LootTable <= 50)
                {
                    DrawnCards += ("Angel\n");
                    AngelCount++;
                    AngelText.text = AngelCount.ToString();
                    Debug.Log("Angel");                  
                }

                if (LootTable > 50)
                {
                    DrawnCards += ("Unicorn\n");
                    UnicornCount++;
                    UnicornText.text = UnicornCount.ToString();
                    Debug.Log("Unicorn");
                }
                            
           }
           else if (Luck <= rareValue)
           {
                if (LootTable <= 50)
                {
                    DrawnCards += ("Joker\n");
                    JokerCount++;
                    JokerText.text = JokerCount.ToString();
                    Debug.Log("Joker");
                }

                if (LootTable > 50)
                {
                    DrawnCards +=("Master Of Music\n");
                    MasterOfMusicCount++;
                    MasterOfMusicText.text = MasterOfMusicCount.ToString();
                    Debug.Log("MasterOfMusic");
                }
  
                
           }
           else
           {
                if (LootTable <= 50)
                {
                    DrawnCards += ("Hound Master\n");
                    HoundMasterCount++;
                    HoundMasterText.text = HoundMasterCount.ToString();
                    Debug.Log("HoundMaster");
                }

                if (LootTable > 50)
                {
                    DrawnCards += ("Mystic\n");
                    MysticCount++;
                    MysticText.text = MysticCount.ToString();
                    Debug.Log("mystic");
                }
                             
           }

           PackPanelText.text = DrawnCards;
        }


    }
}

//AngelCount
//Card[] EpicArray = Resources.LoadAll<Card>("Cards/Epic");
