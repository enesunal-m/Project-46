using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update

    public float divider;
    void Start()
    {
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length / divider);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
