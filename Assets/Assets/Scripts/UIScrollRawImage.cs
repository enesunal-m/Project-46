using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollRawImage : MonoBehaviour
{
    [SerializeField] float verticalSpeed;
    [SerializeField] float horizontalSpeed;
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
        currentUv.x-=Time.deltaTime*horizontalSpeed;
      
        if (currentUv.y <= -1f || currentUv.y >= 1f)        
            currentUv.y = 0f;
        
        if (currentUv. x<= -1f || currentUv.x >= 1f)        
            currentUv.x = 0f;
        
        rawImage.uvRect = currentUv;
    }
}
