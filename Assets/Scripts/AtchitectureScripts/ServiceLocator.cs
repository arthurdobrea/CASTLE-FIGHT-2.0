using System;
using System.Collections.Generic;

public class ServiceLocator
{
    private Dictionary<Type, IService> services = new Dictionary<Type, IService>();

    public static ServiceLocator Instance { get; private set; }

    public static void Init()
    {
        Instance = new ServiceLocator();
    }

    private ServiceLocator()
    {
        
    }

    public void Register<T>(T service) where T : IService
    {
        var type = service.GetType();

        if (services.ContainsKey(type))
        {
            throw new Exception($"Service of type {type} is already registered");
        }

        services.Add(type, service);
    }

    public void Unregister<T>() where T : IService
    {
        var type = typeof(T);

        if (!services.ContainsKey(type))
        {
            throw new Exception($"Service of type {type} is not registered");
        }

        services.Remove(type);
    }

    public T Get<T>() where T : IService
    {
        var type = typeof(T);

        if (!services.ContainsKey(type))
        {
            throw new Exception($"Service of type {type} is not existing");
        }

        return (T)services[type];
    }
}