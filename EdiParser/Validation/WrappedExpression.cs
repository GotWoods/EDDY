using System;
using System.Linq.Expressions;
using System.Reflection;
using EdiParser.Attributes;

namespace EdiParser.Validation;

public class WrappedExpression<T>
{
    private readonly Expression<Func<T, object>> _expression;
    private readonly T _instance;
    private readonly string _segmentName;

    public WrappedExpression(Expression<Func<T, object>> expression, T instance, string segmentName)
    {
        _expression = expression;
        _instance = instance;
        _segmentName = segmentName;
    }

    
    public string GetPropertyValue()
    {
        var memberExpression = _expression.Body as MemberExpression;
        if (memberExpression == null)
        {
            var unaryExpression = _expression.Body as UnaryExpression;
            if (unaryExpression != null) memberExpression = unaryExpression.Operand as MemberExpression;
        }

        if (memberExpression != null)
        {
            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo != null)
            {
                var value = propertyInfo.GetValue(_instance, null);
                if (value == null || value == string.Empty)
                    return "";
                return value.ToString();
            }
        }

        return string.Empty;
    }

    public string GetFormattedPropertyName()
    {
        var memberExpression = _expression.Body as MemberExpression;
        if (memberExpression == null)
        {
            var unaryExpression = _expression.Body as UnaryExpression;
            if (unaryExpression != null) memberExpression = unaryExpression.Operand as MemberExpression;
        }

        if (memberExpression != null)
        {
            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo != null)
            {
                var position = propertyInfo.GetCustomAttribute<PositionAttribute>().Position;

                return $"{propertyInfo.Name} ({_segmentName}-{position})";
            }
        }
        return String.Empty;
    }
}