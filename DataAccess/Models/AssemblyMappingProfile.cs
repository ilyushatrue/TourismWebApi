using AutoMapper;
using System.Reflection;

namespace DataAccess.Models;
public class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile(Assembly assembly) =>
        ApplyMappingsFromAssembly(assembly);
    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(type => type.GetInterfaces()
            .Any(type => type.IsGenericType) &&
                type.GetGenericTypeDefinition() == typeof(IMapWith<>))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var method = type.GetMethod("Mapping");
            if (method == null) return;
            method.Invoke(instance, new object[] { this });
        }
    }
}
