using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlatesCounter : BaseCounter {
    
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField] private KitchenObjectsSO plateKitchenObjectSO;

    private float spawnPlateTimer;
    private float spawnTimerMax = 4f;
    private int plateSwpanedAmount;
    private int plateSpwanedAmountMax = 4;

    private void Update() {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnTimerMax) {
            spawnPlateTimer = 0f;

            if(plateSwpanedAmount < plateSpwanedAmountMax) {
                plateSwpanedAmount++;
                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player)
    {
        if(!player.HasKitchenObject())
        {
            if (plateSwpanedAmount > 0)
            {
                plateSwpanedAmount--;
                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);
                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
