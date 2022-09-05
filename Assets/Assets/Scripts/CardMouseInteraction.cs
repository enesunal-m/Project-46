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
    GameObject hand;
    private GameObject castingPlace;
    public GameObject[] line;
    public static bool isCardSelected;
    private LineController lineController;
    private void Start()
    {
        this.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        hand = this.transform.parent.gameObject;
        cardDisplay = this.GetComponent<CardDisplay>();
        castingPlace = GameObject.FindGameObjectWithTag("CastingPlace");
        lineController = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LineController>();
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.gameObject != selectedGameObject)
        {
            this.GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1);
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 80, this.transform.position.z);
            this.GetComponent<Canvas>().sortingOrder += 100;
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (this.gameObject != selectedGameObject)
        {
            this.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 80, this.transform.position.z);
            this.GetComponent<Canvas>().sortingOrder -= 100;
        }
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isCardSelected)
        {
            return;
        }
        selectedGameObject = eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject;
        Debug.Log("Abi Index: " + cardDisplay.index);

        

        //Cast Card
        castCard();

    }
    private void Update()
    {
        if (isCardSelected)
        {
            if (Input.GetMouseButtonDown(1))
            {
                line = GameObject.FindGameObjectsWithTag("Line");
                foreach (var item in line)
                {
                    Destroy(item.gameObject);
                }
                selectedGameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                selectedGameObject.transform.parent = hand.transform;
                selectedGameObject.transform.position = hand.transform.position;
                selectedGameObject = null;
                isCardSelected = false;
            }
        }
    }

    void castCard()
    {
        lineController.drawLine = true;
        selectedGameObject.transform.parent = castingPlace.transform;
        selectedGameObject.transform.position = castingPlace.transform.position;
        isCardSelected = true;
    }
}
