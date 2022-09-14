using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class EnemyMouseInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject selectedGameObject;

    public LayerMask IgnoreMe;
    private bool isSelfSelected = false;

    public GameObject[] line;
    private void Start()
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.gameObject != selectedGameObject)
        {
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

    private void Update()
    {
        AttackEnemy();
    }

    void AttackEnemy()
    {
        if (GameManager.Instance.isAnyCardSelected && Input.GetMouseButtonDown(0) && !GameManager.Instance.isSelectedCardUsed)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, ~IgnoreMe);

            if (hit.collider != null && hit.transform.gameObject.tag == "Enemy")
            {
                CardManager.Instance.selectedEnemies.Add(hit.transform.gameObject.GetComponent<Enemy>());
                CardManager.Instance.UseSelectedCard(CardTarget.SingleEnemy);
                GameManager.Instance.isSelectedCardUsed = true;
                Debug.Log("AB ENEMY ABBBB");
            }
        }
    }
}
