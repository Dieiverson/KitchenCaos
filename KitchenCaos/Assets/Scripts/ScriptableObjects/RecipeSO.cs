using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu()]
public class RecipeSO : ScriptableObject
{
    public List<KitchenObjectsSO> kitchenObjectSOList;
    public string recipeName;

}
