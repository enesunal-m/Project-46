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

    private void Update()
    {
        AttackEnemy();
    }

    void AttackEnemy()
    {
        if (GameManager.Instance.isAnyCardSelected && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, ~IgnoreMe);

            CardManager.Instance.selectedEnemies.Add(hit.transform.gameObject.GetComponent<Enemy>());

            CardManager.Instance.UseSelectedCard();
            if (hit.collider != null && hit.transform.gameObject.tag == "Enemy")
            {
                Debug.Log("AB ENEMY ABBBB");
            }
        }
    }
}
