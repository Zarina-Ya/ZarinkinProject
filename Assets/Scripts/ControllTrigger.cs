using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllTrigger : MonoBehaviour
{
    [SerializeField] private AudioReverbZone _zone;




    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _zone.enabled = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _zone.enabled = false;
        }
    }
}
