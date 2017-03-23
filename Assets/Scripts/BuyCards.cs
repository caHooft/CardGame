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
    public int LootTable;
    public int AngelCount;
    public int UnicornCount;
    public int JokerCount;
    public int MasterOfMusicCount;
    public int MysticCount;
    public int HoundMasterCount;
    #endregion
    
    public void BuyTheCards(int PackType)
    {
        string DrawnCards = "";

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
