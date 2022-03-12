using UnityEngine;

public abstract class CoreComponent : MonoBehaviour
{
    protected CoreContainer CoreContainer { get; private set; }

    protected virtual void Awake()
    {
        CoreContainer = transform.parent.GetComponent<CoreContainer>();

        if (CoreContainer == null)
        {
            Debug.LogError("There is no Core on the parent");
        }
    }
}
