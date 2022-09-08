using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiarmeterEffects : MonoBehaviour
{
    LiarMeterConroller liarmeterController;
    public static LiarmeterEffects Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        liarmeterController = GameManager.Instance.transform.GetComponent<LiarMeterConroller>();
    }
    public void LiarmeterEffect60(string id)
    {
        // Gives 1 Demonic Attack card when liarmeter reaches 60.
        GameManager.Instance.transform.GetComponent<CardSpawner>().SpawnCardWithId(id);
    }
    public void LiarmeterEffect70()
    {
        GameManager.Instance.transform.GetComponent<CardSpawner>().cardAmountPenalty += 1;
    }
    public void LiarmeterEffect85()
    {
        GameManager.Instance.transform.GetComponent<CardSpawner>().cardAmountPenalty += 1;
    }
}
