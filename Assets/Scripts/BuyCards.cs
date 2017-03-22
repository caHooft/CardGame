using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BuyCards : MonoBehaviour
{
    public int Luck;
    public int LootTable;
    public int AngelCount;
    public int unicornCount;
    //public int LootTable;
    //public int AngelCount;
    public int NumberOfCardsEachPack = 5;

     public void BuyTheCards(int PackType)
     {

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
                    Debug.Log("Got Angel");
                    Card[] EpicArray = Resources.LoadAll<Card>("Cards/Epic");
                    //EpicArray[0].looks 
                }

                if (LootTable > 50)
                {
                    Debug.Log("Got Unicorn");
                }
                

            
                 Debug.Log("Got epic");
           }
           else if (Luck <= rareValue)
           {
                Card[] RareArray = Resources.LoadAll<Card>("Cards/Rare");
                Debug.Log("Got rare");
           }
           else
           {
                Card[] NormalArray = Resources.LoadAll<Card>("Cards/Normal");
                Debug.Log("Got normal");
           }
      }
    }
}
