using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ItemSlot : MonoBehaviour, IPointerClickHandler
{

    [SerializeField]
    private Sprite ItemIcon;

    [SerializeField]
    private TextMeshProUGUI itemNameText;

    [SerializeField]
    private GameObject StackSize;

    [SerializeField]
    private TextMeshProUGUI stackSizeText;

    private InventoryItem item;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }


    public void Set(InventoryItem item)
    {
        this.item = item;
        ItemIcon = item.data.icon;
        itemNameText.text = item.data.displayName;
        stackSizeText.text = item.StackSize.ToString();
        button.image.sprite = ItemIcon;

        if (item.StackSize > 1)
        {
            StackSize.SetActive(true);
            stackSizeText.enabled = true;
            stackSizeText.text = item.StackSize.ToString();
        }
        else
        {
            StackSize.SetActive(false);
            stackSizeText.enabled = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Left-clicked on item: " + item.data.displayName);
            Inventory.instance.RemoveItem(item.data);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            //TODO: USE ITEM
            Debug.Log("Right-clicked on item: NOT IMPLEMENTED YET" + item.data.displayName);
        }
    }
}
