using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Eddy.Core.Validation;

public class TransactionValidator<T>
{
    private readonly T _instance;
    public ValidationResult Results = new();

    public TransactionValidator(T instance)
    {
        _instance = instance;
    }


    public void CollectionSize(Expression<Func<T, object>> expression, int min, int max)
    {
        // Check if the expression body is a MemberExpression or UnaryExpression
        // and then get the member from it (to handle both field and property access)
        var member = expression.Body as MemberExpression ?? (expression.Body as UnaryExpression)?.Operand as MemberExpression;

        if (member == null)
            throw new ArgumentException("Expression is not a member access", nameof(expression));

        // Get the type of the member (property or field)
        Type memberType;
        if (member.Member.MemberType == System.Reflection.MemberTypes.Property)
        {
            memberType = ((PropertyInfo)member.Member).PropertyType;
        }
        else if (member.Member.MemberType == System.Reflection.MemberTypes.Field)
        {
            memberType = ((FieldInfo)member.Member).FieldType;
        }
        else
        {
            throw new ArgumentException("Expression does not target a field or property", nameof(expression));
        }

        // Check if the memberType is a List<T> or derived from a List<T>
        if (!(memberType.IsGenericType && memberType.GetGenericTypeDefinition() == typeof(List<>)))
        {
            throw new ArgumentException("Expression does not target a List<T> property", nameof(expression));
        }

        // Compile the expression into a function
        var func = expression.Compile();

        var list = func(_instance) as IList;
        if (list == null)
            throw new InvalidOperationException("The member is not a List");

        // Check if the count is within the specified range
        if (list.Count < min || list.Count > max)
            // The count is not within the specified range
            Results.Errors.Add(new Error(ErrorCodes.CollectionSize, member.Member.Name, min.ToString(), max.ToString(), list.Count.ToString()));
    }

    public void Required(Expression<Func<T, object>> expression)
    {
        // Compile the expression into a function
        var func = expression.Compile();
        var value = func(_instance);
        if (value == null) Results.Errors.Add(new Error(ErrorCodes.Required, "TODO"));
    }
}