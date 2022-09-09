using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopMouseInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
 

    public void OnPointerClick(PointerEventData eventData)
    {

        //if (eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.money<=MoneyManager.totalMoney)
        //{
        //eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.SetActive(false);

        //} para değerleri belli olunca tamamlanacak

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1);
        transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 15, this.transform.position.z);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 15, this.transform.position.z);
    }
}
