using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;
    
    private IKitchenObjectParent kitchenObjectParent;

    public KitchenObjectsSO GetKitchenObjectsSO()
    {
        return kitchenObjectsSO;
    }

    public void SetKitchenParentObject(IKitchenObjectParent kitchenObjectParent)
    {
        this.kitchenObjectParent = kitchenObjectParent;
    }

    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if(this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }

        this.kitchenObjectParent = kitchenObjectParent;
        kitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.getKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public void DestroySelf()
    {
        kitchenObjectParent.ClearKitchenObject();
        Destroy(gameObject);
    }

    public bool TryGetPlate(out PlateKitchenObject plateKitchenObject)
    {
        if (this is PlateKitchenObject)
        {
            plateKitchenObject = this as PlateKitchenObject;
            return true;
        }
        else
        {
            plateKitchenObject = null;
            return false;
        }
    }

    public static KitchenObject SpawnKitchenObject(KitchenObjectsSO kitchenObjectsSO, IKitchenObjectParent kitchenObjectParent)
    {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.prefab).transform;
        KitchenObject kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(kitchenObjectParent);

        return kitchenObject;
    }

}
