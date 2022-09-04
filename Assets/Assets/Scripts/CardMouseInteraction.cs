using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CardMouseInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    GameObject selectedGameObject;
    CardDisplay cardDisplay;
    private GameObject castingPlace;
    public GameObject line;
    public static bool isCardSelected;
    private void Start()
    {
        this.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        cardDisplay = this.GetComponent<CardDisplay>();
        castingPlace = GameObject.FindGameObjectWithTag("CastingPlace");
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
        if (isCardSelected)
        {
            return;
        }
        selectedGameObject = eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject;
        Debug.Log("Abi Index: " + cardDisplay.index);

        selectedGameObject.transform.parent = castingPlace.transform;
        selectedGameObject.transform.position = castingPlace.transform.position;

        //Cast Card
        castCard();

    }

    void castCard()
    {
        isCardSelected = true;
    }
}
