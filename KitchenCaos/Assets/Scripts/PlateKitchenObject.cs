using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectsSO> validKitchenObjectsSOList;
    private List<KitchenObjectsSO> kitchenObjectSOList;
    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectsSO>();
    }
    public bool TryAddIngredient(KitchenObjectsSO kitchenObjectsSO)
    {
        if (!validKitchenObjectsSOList.Contains(kitchenObjectsSO))
        {
            return false;
        }
        
        if (kitchenObjectSOList.Contains(kitchenObjectsSO)) {
            return false;
        }
        else {
            kitchenObjectSOList.Add(kitchenObjectsSO);
            return true;
        }
    }
}
