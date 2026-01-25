using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs
    {
        public KitchenObjectsSO kitchenObjectsSO;
    }

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
            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs
            {
                kitchenObjectsSO = kitchenObjectsSO
            });
            return true;
        }
    }

    public List<KitchenObjectsSO> GetKitchenObjectsSOList()
    {
        return kitchenObjectSOList;
    }
}
