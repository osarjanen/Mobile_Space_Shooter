using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{

    //destroy all object leaving game area
    private void OnTriggerExit(Collider other)
    {
        DestroyObject(other.gameObject);
    }

}
