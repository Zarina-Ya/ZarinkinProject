using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
   // [SerializeField] protected GameObject _prefab;

    public abstract void AddInventory(GameObject gameObject);
}
