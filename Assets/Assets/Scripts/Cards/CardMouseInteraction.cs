using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.EventSystems;

public class CardMouseInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    CardDisplay cardDisplay;
    GameObject hand;
    public LayerMask IgnoreMe;
    private GameObject castingPlace;
    public GameObject[] line;
    public bool isCardSelected = false;
    private LineController lineController;
    private GameObject highlightedCard;
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
        if (this.gameObject != CardManager.Instance.selectedCard)
        {
            highlightedCard = this.gameObject;
            this.GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1);
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 80, this.transform.position.z);
            this.GetComponent<Canvas>().sortingOrder += 100;
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (this.gameObject != CardManager.Instance.selectedCard)
        {
            highlightedCard = null;
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
        if (PlayerController.Instance.playerMana > 0 || highlightedCard.GetComponent<CardDisplay>().cost == 0)
        {
            CardManager.Instance.selectedCard = eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject;
            Debug.Log("Abi Index: " + cardDisplay.index);
            Debug.Log(CardManager.Instance.selectedCard);
            Debug.Log(eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject);
            castCard();
        }
        else if (PlayerController.Instance.playerMana <= 0)
        {
            PlayerController.Instance.playerMana = 0;
        }
        

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
                CardManager.Instance.selectedCard.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                CardManager.Instance.selectedCard.transform.parent = hand.transform;
                CardManager.Instance.selectedCard.transform.position = hand.transform.position;
                CardManager.Instance.selectedCard = null;
                isCardSelected = false;
                GameManager.Instance.isAnyCardSelected = false;
            }
        }
    }

    void castCard()
    {
        lineController.drawLine = true;
        Debug.Log(CardManager.Instance.selectedCard);
        CardManager.Instance.selectedCard.transform.parent = castingPlace.transform;
        CardManager.Instance.selectedCard.transform.position = castingPlace.transform.position;
        isCardSelected = true;
        GameManager.Instance.isAnyCardSelected = true;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, ~IgnoreMe);

            if (hit.collider != null && hit.transform.gameObject.tag == "Enemy")
            {
                Debug.Log("AB ENEMY ABBBB");
            }
        }
    }
}
