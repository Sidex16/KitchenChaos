using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField]
    private StoveCounter stoveCounter;
    [SerializeField]
    private GameObject stoveOnGameObject;
    [SerializeField]
    private GameObject particlesGameObject;

    private void Start()
    {
        stoveCounter.OnFrying += StoveCounter_OnFrying;
    }

    private void StoveCounter_OnFrying(object sender, StoveCounter.OnFryingEventArgs e)
    {
        bool showVisual = e.state == StoveCounter.State.Fried || e.state == StoveCounter.State.Frying;
        stoveOnGameObject.SetActive(showVisual);
        particlesGameObject.SetActive(showVisual);
    }
}

    
