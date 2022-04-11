using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    [SerializeField] private int _sceneIndex;
    [SerializeField] private  bool _isOpen = false;
    [SerializeField] private int _countkey;
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Player>();
      

        if (OpenTeleport(player) && _isOpen)
        {
            SceneManager.LoadScene(_sceneIndex);
        }
    }

    public bool OpenTeleport (Player player)
    {
        if (player.CountKey == _countkey)
        {
            _isOpen = true;
            return true;
        }
        return false;
    }
}
