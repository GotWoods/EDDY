using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Eddy.Core.Attributes;
using Eddy.x12.Models;

namespace Eddy.x12.Mapping.Cache;

public class RepresentationMap
{
    public List<Representation> Representations { get; set; } = new();

    public static RepresentationMap From(Type t)
    {
        var representations = new List<Representation>();
        var props = t.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(PositionAttribute)));

        foreach (var propertyInfo in props)
        {
            var rep = new Representation();
            rep.Position = propertyInfo.GetCustomAttribute<PositionAttribute>().Position;
            rep.PropertyInfo = propertyInfo;
            representations.Add(rep);
        }

        return new RepresentationMap() { Representations = representations.OrderBy(x => x.Position).ToList() };
    }

}