using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEyeGenerator : MonoBehaviour
{
    public Transform[] transforms;
    public GameObject eyePrefab;
    bool doIt;
    void Start()
    {
        doIt = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (doIt)
        {
            StartCoroutine(eyeBlink());
        }
    }
    IEnumerator eyeBlink()
    {
        doIt = false;
        var random = Random.Range(4, 7);
        yield return new WaitForSeconds(random);
        var randomTransform = Random.Range(0, transforms.Length);
        Instantiate(eyePrefab, transforms[randomTransform]);
        doIt = true;
    }
}
