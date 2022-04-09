using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp
{
    private int _countKey;
 
    public override void AddInventory(GameObject gameObject)
    {
        _countKey++;
        gameObject.GetComponent<Player>().CountKey++;
        Debug.Log($"YOUR KEY: { _countKey}");
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player)
        {
            AddInventory(player.gameObject);
            Destroy(gameObject);
        }
    }
}
   
   