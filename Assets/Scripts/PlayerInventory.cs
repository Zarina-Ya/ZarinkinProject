using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{

     public int _countZarinok { get; private set; }
     public int _countVadimok { get; private set; }
     public int _countZolikov { get; private set; }

    public UnityEvent<PlayerInventory> OnItemCollected;
    public void ItemCollected(int val) // 0 - Zrinka, 1- Vadimka , 2- Zolick
    {
        switch (val)
        {
            case 0: 
                _countZarinok ++;
                break;

            case 1: 
                _countVadimok ++;
                break;

            case 2:
                _countZolikov ++;
                break;

                default:
               
                break;
        }

        OnItemCollected.Invoke(this);
    }
}
