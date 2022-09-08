using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollRawImage : MonoBehaviour
{
    [SerializeField] float verticalSpeed;
    RawImage rawImage;
    // Start is called before the first frame update
    void Start()
    {
        rawImage= GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        Rect currentUv = rawImage.uvRect;
        currentUv.y-=Time.deltaTime*verticalSpeed;
      
        if (currentUv.y <= -1f || currentUv.y >= 1f)
        {
            currentUv.y = 0f;
        }
        rawImage.uvRect = currentUv;
    }
}
