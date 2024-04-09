using UnityEngine;
using UnityEngine.Events;

public class MainBuildingDestroyed : MonoBehaviour
{
    public UnityEvent<string> onDead;

    private void OnDestroy()
    {
        onDead?.Invoke(gameObject.tag);
    }
}