using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMachine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player)
        {
            player.Hit(1);
        }
    }
}
