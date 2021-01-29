using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitchInitial : MonoBehaviour
{
    [HideInInspector]
    public bool reached;

    GameObject hand;
    GameObject rope, correctRope;

    void Awake()
    {
        hand = GameObject.FindGameObjectWithTag("Hand");
        rope = GameObject.FindGameObjectWithTag("Rope");
        correctRope = GameObject.FindGameObjectWithTag("RopeCorrect");
        rope.SetActive(false);
        correctRope.SetActive(false);
        reached = false;
    }

    void Update()
    {
        if (!reached && rope.activeInHierarchy)
        {
            transform.LookAt(hand.transform);
        }       
    }

    public void Activate()
    {
        rope.SetActive(true);
    }

    public void Deactivate()
    {
        rope.SetActive(false);
    }

    public void Reached()
    {
        reached = true;
        rope.SetActive(false);
        correctRope.SetActive(true);
    }
}
