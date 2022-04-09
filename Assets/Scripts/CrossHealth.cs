using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHealth : PickUp
{
    [SerializeField] private int _addHeath;
    public override void AddInventory(GameObject gameObject)
    {
        if (gameObject.GetComponent<Player>().AddHealth(_addHeath))
        {
            Debug.Log($"ADD Heath: { _addHeath}");

            Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if(player) AddInventory(player.gameObject);
    }

}
