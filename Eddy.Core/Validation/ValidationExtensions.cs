using System;
using System.Linq.Expressions;

namespace Eddy.Core.Validation;

public static class ValidationExtensions {

    public static WrappedExpression<T> Wrap<T>(this Expression<Func<T, object>> expression, T instance, string segmentName)
    {
        var wrapped = new WrappedExpression<T>(expression, instance, segmentName);
        return wrapped;
    }

    
}