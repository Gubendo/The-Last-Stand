using UnityEngine.UI;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    Item item;
    //public Button removeButton;
    public Image icon;

    public void addItem(Item newItem)
    {
        item = newItem;
        icon.sprite = newItem.icon;
        icon.enabled = true;
        //removeButton.interactable = true;
       // removeButton.image.enabled = true;
    }

    public void clearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        //removeButton.interactable = false;
        //removeButton.image.enabled = false;
    }

    /*public void OnRemoveButton()
    {
        Inventory.instance.removeItem(item);
    }*/

    public void useItem()
    {
        if (item != null)
        {
            item.use();
        }
    }

    public Item getItem()
    {
        return item;
    }
}