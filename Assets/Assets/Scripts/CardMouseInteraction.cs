using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CardMouseInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    GameObject selectedGameObject;
    private void Start()
    {
        this.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1);
        this.GetComponent<Canvas>().sortingOrder = 1;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        this.GetComponent<Canvas>().sortingOrder = 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        selectedGameObject = eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.transform.Find("Name").gameObject;
        Destroy(selectedGameObject);
    }
}
