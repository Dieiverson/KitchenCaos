using UnityEngine;

public class ClearCounter : MonoBehaviour
{

    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;

    private KitchenObject kitchenObject;
    public void Interact() {
        if(kitchenObject == null)
        {
            Transform kitcheObjectTransform = Instantiate(kitchenObjectsSO.prefab, counterTopPoint).transform;
            kitcheObjectTransform.localPosition = Vector3.zero;
            kitcheObjectTransform.GetComponent<KitchenObject>().SetClearCounter(this);
        } else
        {

        }
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
    //DEIXANDO ESSE COMENTÁRIO PRA QUANDO EU VOLTAR DEIXAR CLARO: EU NÃO FIZ A PARTE QUE TROCA OS PARENTS,
    //POIS O MESMO É UM TESTE. PORÉM SE NO FUTURO PRECISAR ESSe É O MINUTO DO VIDEO QUE VC DEVE ASSISTIR: 3:24:46 OU NO CAPITULO Kitchen Object Parent.
    //PS: Espero que tenha curtido a praia :)
}
