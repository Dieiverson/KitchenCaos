using System;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject stoveOnGameObject;
    [SerializeField] private GameObject particleGameObject;
    [SerializeField] private GameObject BurningParticleGameObject;
    [SerializeField] private StoveCounter stoveCounter;

    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangeEventArgs e)
    {
        bool showVisual = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;
        particleGameObject.SetActive(showVisual);
        stoveOnGameObject.SetActive(e.state != StoveCounter.State.Idle);
        BurningParticleGameObject.SetActive(e.state == StoveCounter.State.Burned);
    }
}
