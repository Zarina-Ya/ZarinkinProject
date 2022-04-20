using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp
{
    private int _countKey;
    [SerializeField] private AudioSource _audioSource; // источник звука
    [SerializeField] private AudioClip _clip;

 
    public override void AddInventory(GameObject gameObject)
    {
        _countKey++;
        gameObject.GetComponent<Player>().CountKey++;
      //  _audioSource.PlayOneShot(_clip);
      _audioSource.Play();
        Debug.Log($"YOUR KEY: { _countKey}");
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player)
        {
            //_audioSource = GetComponent<AudioSource>();
            //_audioSource.Play();


            AddInventory(player.gameObject);


            
            Destroy(gameObject, 1.6f);
        }
    }
  

   
    

}
   
   