namespace TicTacToe.IoC;

public class SimpleContainer
{
    Dictionary<Type, Type> _map = new Dictionary<Type, Type>();
    Dictionary<Type, object> _singletons = new Dictionary<Type, object>();

    public ContainerBuilder For<TSource>()
    {
        return For(typeof(TSource));
    }

    public ContainerBuilder For(Type sourceType)
    {
        return new ContainerBuilder(this, sourceType);
    }

    public ContainerBuilder ForSingleton<TSource>(TSource instance)
    {
        _singletons[typeof(TSource)] = instance;
        return For<TSource>();
    }

    public TSource Resolve<TSource>()
    {
        return (TSource)Resolve(typeof(TSource));
    }

    public object Resolve(Type sourceType)
    {
        if (_singletons.ContainsKey(sourceType))
        {
            return _singletons[sourceType];
        }
        else if (_map.ContainsKey(sourceType))
        {
            var destinationType = _map[sourceType];
            return CreateInstance(destinationType);
        }
        else if (sourceType.IsGenericType && _map.ContainsKey(sourceType.GetGenericTypeDefinition()))
        {
            var destination = _map[sourceType.GetGenericTypeDefinition()];
            var closedDestination = destination.MakeGenericType(sourceType.GenericTypeArguments);

            return CreateInstance(closedDestination);
        }
        else if (!sourceType.IsAbstract)
        {
            return CreateInstance(sourceType);
        }
        else
        {
            throw new InvalidOperationException("Could not resolve " + sourceType.FullName);
        }
    }

    private object CreateInstance(Type destinationType)
    {
        var paramters = destinationType.GetConstructors()
                            .OrderByDescending(c => c.GetParameters().Count())
                            .First()
                            .GetParameters()
                            .Select(p => Resolve(p.ParameterType))
                            .ToArray();

        return Activator.CreateInstance(destinationType, paramters);
    }

    public class ContainerBuilder
    {
        SimpleContainer _container;
        Type _sourceType;

        public ContainerBuilder(SimpleContainer container, Type sourceType)
        {
            _container = container;
            _sourceType = sourceType;
        }

        public ContainerBuilder Use<TDestination>()
        {
            return Use(typeof(TDestination));
        }

        public ContainerBuilder Use(Type destinationType)
        {
            _container._map.Add(_sourceType, destinationType);
            return this;
        }
    }
}
