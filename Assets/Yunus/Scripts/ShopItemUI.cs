using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ShopItemUI : MonoBehaviour
{
    [SerializeField] Color itemNotSelectedColor;
    [SerializeField] Color itemSelectedColor;

    [Space(10f)]
    [SerializeField] Image itemImage;
    [SerializeField] Text itemName;
    [SerializeField] Text itemPriceText;
    [SerializeField] Button itemPurchaseButton;

    [Space(10f)]

    [SerializeField] Button itemButton;
    [SerializeField] Image itemButtonImage;
    [SerializeField] Outline itemOutline;

    public void SetItemPosition(Vector2 pos)
    {
        GetComponent<RectTransform>().anchoredPosition += pos;
    }

    public void SetItemImage(Sprite sprite)
    {
        itemImage.sprite = sprite;
    }

    public void SetItemName(string name)
    {
        itemName.text = name;

    }

    public void SetItemPrice(int price)
    {
        itemPriceText.text = price.ToString();
    }

    public void SetItemAsPurchased()
    {
        itemPurchaseButton.gameObject.SetActive(false);
        itemButton.interactable = true;

        itemButtonImage.color = itemSelectedColor;
    }

    public void OnItemPurchased(int itemIndex, UnityAction<int> action)
    {
        itemPurchaseButton.onClick.RemoveAllListeners();
        itemPurchaseButton.onClick.AddListener(() => action?.Invoke(itemIndex));
    }
    public void OnItemSelect(int itemIndex, UnityAction<int> action)
    {
        itemButton.interactable = true;
        itemButton.onClick.RemoveAllListeners();
        itemButton.onClick.AddListener(() => action?.Invoke(itemIndex));
    }

    public void SelectItem()
    {
        itemOutline.enabled = true;
        itemButtonImage.color = itemSelectedColor;
        itemButton.interactable = false;
    }

    public void DeselectItem()
    {
        itemOutline.enabled = false;
        itemButtonImage.color = itemNotSelectedColor;
        itemButton.interactable = true;
    }
}
