using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonZoom : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = new Vector3(1.2652f, 1.2652f, 1.2652f);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 15, this.transform.position.z);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = new Vector3(1.4f, 1.4f, 1);
        transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 15, this.transform.position.z);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = new Vector3(1.2652f, 1.2652f, 1.2652f);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 15, this.transform.position.z);
    }


}
