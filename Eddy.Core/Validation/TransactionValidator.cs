using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Eddy.Core.Attributes;

namespace Eddy.Core.Validation;

public class TransactionValidator<T>
{
    private readonly T _instance;
    private readonly string _segmentName;
    public ValidationResult Results = new();

    public TransactionValidator(T instance)
    {
        _instance = instance;
        _segmentName = _instance.GetType().GetCustomAttribute<Segment>().Name;
    }


    public void CollectionSize(Expression<Func<T, object>> expression, int min, int max)
    {
        {
            // Check if the expression body is a MemberExpression or UnaryExpression
            // and then get the member from it (to handle both field and property access)
            var member = expression.Body as MemberExpression ?? (expression.Body as UnaryExpression)?.Operand as MemberExpression;

            if (member == null)
                throw new ArgumentException("Expression is not a member access", nameof(expression));

            // Check if the member is indeed a List<T>
            if (!typeof(List<>).IsAssignableFrom(member.Member.DeclaringType))
                throw new ArgumentException("Expression does not target a List<T> property", nameof(expression));

            // Compile the expression into a function
            var func = expression.Compile();

            // You'd need an instance of T to call the func and get the List<T> value
            // Assuming you have an instance `instanceOfT` of type T
            T instanceOfT = default; // Placeholder, you need to provide an instance

            var list = func(instanceOfT) as IList;

            if (list == null)
                throw new InvalidOperationException("The member is not a List");

            // Check if the count is within the specified range
            if (list.Count < min || list.Count > max)
            {
                // The count is not within the specified range
                Results.Errors.Add(new Error(ErrorCodes.OutOfRange, "TODO"));
            }
        }
    }

    public void Required(Expression<Func<T, object>> expression)
    {
        // Compile the expression into a function
        var func = expression.Compile();
        T instanceOfT = default; 
        // Execute the function with the instance to get the property value
        var value = func(instanceOfT);
        // Check if the value is not null

        if (value == null)
        {
         Results.Errors.Add(new Error(ErrorCodes.Required, "TODO"));
        }
    }
}