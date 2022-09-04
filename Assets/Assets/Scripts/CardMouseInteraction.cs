using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CardMouseInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Vector3 defaultPos;
    GameObject selectedGameObject;
    private void Start()
    {
        this.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        defaultPos = this.transform.position;
        this.transform.position = new Vector2(this.GetComponent<RectTransform>().position.x, this.GetComponent<RectTransform>().position.y + 150);
        //this.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1.5f);
        //this.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1.5f);
        //this.GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.position = defaultPos;
        //this.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
        //this.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        //this.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        selectedGameObject = eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.transform.Find("Name").gameObject;
        Destroy(selectedGameObject);
    }
}
