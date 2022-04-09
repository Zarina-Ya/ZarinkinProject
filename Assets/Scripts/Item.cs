using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int _countItem;


    private void OnTriggerEnter(Collider other)
    {
        var playerInventory = other.gameObject.GetComponent<PlayerInventory>();
        if (playerInventory)
        {
            playerInventory.ItemCollected(_countItem);
            Destroy(gameObject);
        }
    }
}
