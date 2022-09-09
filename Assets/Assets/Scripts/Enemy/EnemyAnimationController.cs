using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] float animScaler;
    void Start()
    {
        ScaleAnimation();
    }

    public void ScaleAnimation()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 scaleTo = new Vector3(transform.localScale.x, transform.localScale.y + animScaler, transform.localScale.z);
        transform.DOScale(scaleTo, 0.7f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);


    }
}
