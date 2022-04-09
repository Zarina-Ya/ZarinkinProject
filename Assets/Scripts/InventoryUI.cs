using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{

    private TextMeshProUGUI m_TextMeshProUGUI;
    [SerializeField] private int _countItem;

    // Start is called before the first frame update
    private void Awake()
    {
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void UpdateItemText(PlayerInventory playerInventory)
    {
        switch (_countItem)
        {
            case 0:
                m_TextMeshProUGUI.text = playerInventory._countZarinok.ToString();
                break;

            case 1:
                m_TextMeshProUGUI.text = playerInventory._countVadimok.ToString();
                break;

            case 2:
                m_TextMeshProUGUI.text = playerInventory._countZolikov.ToString();
                break;

            default: break;
        }
    }
}
