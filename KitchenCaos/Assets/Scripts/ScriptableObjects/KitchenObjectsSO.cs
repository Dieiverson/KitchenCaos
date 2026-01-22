using UnityEngine;

//Atenção... não é MonoBehaivor e sim ScriptableObject

[CreateAssetMenu()]
public class KitchenObjectsSO : ScriptableObject
{
    public GameObject prefab;
    public Sprite sprite;
    public string objectName;
}
