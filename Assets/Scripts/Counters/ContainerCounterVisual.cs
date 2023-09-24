using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    private const string OPEN_CLOSE = "OpenClose";

    [SerializeField]
    private ContainerCounter containterCounter;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    private void Start()
    {
        containterCounter.OnPlayerGrabObject += ContainerCounter_OnPlayerGrabObject;

    }

    private void ContainerCounter_OnPlayerGrabObject(object sender, System.EventArgs e)
    {
        animator.SetTrigger(OPEN_CLOSE);
    }
}
