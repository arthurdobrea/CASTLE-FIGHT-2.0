using Unity.VisualScripting;
using UnityEngine;

public class ServiceLocatorManager : MonoBehaviour
{
    [SerializeField] private Object[] services;

    private void Awake()
    {
        ServiceLocator.Init();
        RegisterServices();
    }

    private void RegisterServices()
    {
        Debug.Log($"{this.GetType().Name}: {services.Length} services found{(services.Length > 0 ? ". Trying to add them to the Service Locator" : "")}");
        int errors = 0;
        foreach (var service in services)
        {
            IService serviceComponent = service.GetComponent<IService>();
            if(serviceComponent != null)
            {
                ServiceLocator.Instance.Register(serviceComponent);
            }
            else
            {
                errors++;
                Debug.LogError($"{this.GetType().Name}: '{service}' does not implement the interface 'IService'");
            }
        }
        if(errors <= 0)
        {
            Debug.Log($"{this.GetType().Name}: All {services.Length} services have been successfully added to the Service Locator");
        }
        else
        {
            Debug.LogError($"{this.GetType().Name}: Only {services.Length - errors} out of {services.Length} services were added to the Service Locator");
        }
    }
}
