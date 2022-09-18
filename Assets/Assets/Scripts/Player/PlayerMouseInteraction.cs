using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PlayerMouseInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject selectedGameObject;

    public LayerMask IgnoreMe;
    private bool isSelfSelected = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.gameObject != selectedGameObject)
        {
            Debug.Log(gameObject.tag);
            isSelfSelected = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (this.gameObject != selectedGameObject)
        {
            isSelfSelected = false;
        }
    }

    void Update()
    {
        castCardOnPlayer();
    }

    private void castCardOnPlayer()
    {
        if (GameManager.Instance.isAnyCardSelected && Input.GetMouseButtonDown(0) && !GameManager.Instance.isSelectedCardUsed)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, ~IgnoreMe);


            if (hit.collider != null && hit.transform.gameObject.tag == "Player")
            {
                CardManager.Instance.UseSelectedCard(CardTarget.Player);
                GameManager.Instance.isSelectedCardUsed = true;
                Debug.Log("Card Used On Player");
            }
        }
    }
}
