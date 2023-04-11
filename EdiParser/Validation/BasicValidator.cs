using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using EdiParser.Attributes;
using static System.String;

namespace EdiParser.Validation;

public class BasicValidator<T>
{
    private readonly T _instance;
    private readonly string _segmentName;
    public ValidationResult Results = new();

    public BasicValidator(T instance)
    {
        _instance = instance;
        _segmentName = _instance.GetType().GetCustomAttribute<Segment>().Name;
    }

    public void RequiredAorB(Expression<Func<T, object>> expressionA, Expression<Func<T, object>> expressionB)
    {
        var a = expressionA.Wrap(_instance, _segmentName);
        var b = expressionB.Wrap(_instance, _segmentName);

        var valueA = a.GetPropertyValue();
        var valueB = b.GetPropertyValue();

        if (valueA == "" && valueB == "")
        {
            var propertyNameA = a.GetFormattedPropertyName();
            var propertyNameB = b.GetFormattedPropertyName();
            Results.Errors.Add(new Error(ErrorCodes.AorBRequired, propertyNameA, propertyNameB));
        }

    }

    public void VerifyDateFormat(Expression<Func<T, object>> expressionA)
    {
        var a = expressionA.Wrap(_instance, _segmentName);
        var valueA = a.GetPropertyValue();

        if (valueA == "")
            return;


        //has to be numeric at a minimum
        if (!int.TryParse(valueA, out _))
        {
            Results.Errors.Add(new Error(ErrorCodes.DateIsNotValidFormat, a.GetFormattedPropertyName()));
            return;
        }

        //It is CCYYMMDD in the spec but this is a C# translation of that
        //TODO: this may be extracted as different date formats may be used. Also when models get a GetDate/GetTime/GetDateAndTime this will be duplicated
        if (!DateTime.TryParseExact(valueA, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None,out DateTime _))
        {
            Results.Errors.Add(new Error(ErrorCodes.DateIsNotValidFormat, a.GetFormattedPropertyName()));
            return;
        }

        // if (valueA.Length == 5) //HHMMS is invalid
        // {
        //     Results.Errors.Add(new Error(ErrorCodes.DateIsNotValidFormat, a.GetFormattedPropertyName()));
        //     return;
        // }

        // var seconds = "00";
        // if (valueA.Length >= 6) //HHMMSS or more info
        //     seconds = valueA.Substring(4)

    }

    public void VerifyTimeFormat(Expression<Func<T, object>> expressionA)
    {
        var a = expressionA.Wrap(_instance, _segmentName);
        var valueA = a.GetPropertyValue();

        if (valueA == "")
            return;


        //has to be numeric at a minimum
        if (!int.TryParse(valueA, out _))
        {
            Results.Errors.Add(new Error(ErrorCodes.TimeIsNotValidFormat, a.GetFormattedPropertyName()));
            return;
        }

        if (valueA.Length == 5) //HHMMS is invalid (but having one more S makes it valid, D can be be 0-2
        {
            Results.Errors.Add(new Error(ErrorCodes.TimeIsNotValidFormat, a.GetFormattedPropertyName()));
            return;
        }

        //It is HHMMDDSS in the spec but this is a C# translation of that
        //
        //TODO: this may be extracted as different date formats may be used. Also when models get a GetDate/GetTime/GetDateAndTime this will be duplicated
        if (!DateTime.TryParseExact(valueA.Substring(0,4), "HHmm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime _))
        {
            Results.Errors.Add(new Error(ErrorCodes.TimeIsNotValidFormat, a.GetFormattedPropertyName()));
            return;
        }

        var seconds = 0;
        var decimalSeconds = 0;
        if (valueA.Length >= 6) //HHMMSS or more info
            seconds = int.Parse(valueA.Substring(4,2));
        if (valueA.Length >= 7) //decimal seconds
            decimalSeconds = int.Parse(valueA.Substring(6));

        //seconds goes from 0-59
        if (seconds > 59)
        {
            Results.Errors.Add(new Error(ErrorCodes.TimeIsNotValidFormat, a.GetFormattedPropertyName()));
            return;
        }

        if (decimalSeconds > 99) //really not possible as we only parse two digits and we know it is numeric
        {
            Results.Errors.Add(new Error(ErrorCodes.TimeIsNotValidFormat, a.GetFormattedPropertyName()));
            return;
        }


    }

    public void Required(Expression<Func<T, object>> expression)
    {
        var wrap = expression.Wrap(_instance, _segmentName);
        if (wrap.GetPropertyValue() == "") 
            Results.Errors.Add(new Error(ErrorCodes.Required, wrap.GetFormattedPropertyName()));
    }

    public void Length(Expression<Func<T, object>> expression, int min, int max)
    {
        var wrap = expression.Wrap(_instance, _segmentName);
        var propertyValue = wrap.GetPropertyValue();

        if (propertyValue == "") //Required() will catch this if it is required
            return;

        if (propertyValue.Length < min || propertyValue.Length > max)
        {
            Results.Errors.Add(new Error(ErrorCodes.OutOfRange, wrap.GetFormattedPropertyName(), min.ToString(), max.ToString(), propertyValue.Length.ToString()));
        }
    }

    public void Length(Expression<Func<T, object>> expression, int length)
    {
        var wrap = expression.Wrap(_instance, _segmentName);
        var value = wrap.GetPropertyValue();
        if (IsNullOrEmpty(value))
            return;
        if (value.Length != length)
        {
            Results.Errors.Add(new Error(ErrorCodes.ExactLength, wrap.GetFormattedPropertyName(), length.ToString(), value.Length.ToString()));
        }
    }

    public void ARequiresB(Expression<Func<T, object>> expressionA, Expression<Func<T, object>> expressionB)
    {
        var a = expressionA.Wrap(_instance, _segmentName);
        var b = expressionB.Wrap(_instance, _segmentName);

        var valueA = a.GetPropertyValue();
        var valueB = b.GetPropertyValue();

        if (IsNullOrEmpty(valueA) && IsNullOrEmpty(valueB)) //both are empty so this rule does not apply
            return;

        if (!IsNullOrEmpty(valueA) && IsNullOrEmpty(valueB))
        {
            Results.Errors.Add(new Error(ErrorCodes.ARequiresB, a.GetFormattedPropertyName(), b.GetFormattedPropertyName()));
        }
    }

    public void IfOneIsFilledThenAtLeastOne(Expression<Func<T, object>> expressionA, params Expression<Func<T, object>>[] requirements)
    {
        var a = expressionA.Wrap(_instance, _segmentName);
        var valueA = a.GetPropertyValue();
        if (IsNullOrEmpty(valueA)) //primary condition is not filled in
            return;

        var isOneFieldSpecified = false;
        foreach (var requirement in requirements)
        {
            var wrapped = requirement.Wrap(_instance, _segmentName);
            var value = wrapped.GetPropertyValue();
            if (value != "")
                isOneFieldSpecified = true;
        }

        if (!isOneFieldSpecified)
        {
            var propertyNames = new List<string>();
            foreach (var requirement in requirements)
            {
                var wrapped = requirement.Wrap(_instance, _segmentName);
                propertyNames.Add(wrapped.GetFormattedPropertyName());
            }

            //TODO: how to make the "or" work with localization?
            var finalString = String.Join(", ", propertyNames.ToArray(), 0, propertyNames.Count - 1) + ", or " + propertyNames.LastOrDefault();
            Results.Errors.Add(new Error(ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired, a.GetFormattedPropertyName(), finalString));
        }

    }

    public void IfOneIsFilled_AllAreRequired(params Expression<Func<T, object>>[] requirements)
    {
        //var map = new List<KeyValuePair<object, WrappedExpression<T>>>(); 
        var isOneFieldSpecified = false;
        var areAllFieldsFilled = true;
        foreach (var requirement in requirements)
        {
            var wrapped = requirement.Wrap(_instance, _segmentName);
            var value = wrapped.GetPropertyValue();
            if (value == "")
                areAllFieldsFilled = false;

            if (value != "") 
                isOneFieldSpecified = true;
            

            //map.Add(new KeyValuePair<object, WrappedExpression<T>>(value, wrapped));
        }

        if (!isOneFieldSpecified) //all fields are empty, so this is a success
            return;

        if (areAllFieldsFilled) //all fields had a value so this is a success
            return;

        //if we get to here then one field was specified, but not all of them
        var propertyNames = new List<string>();
        foreach (var requirement in requirements)
        {
            var wrapped = requirement.Wrap(_instance, _segmentName);
            propertyNames.Add(wrapped.GetFormattedPropertyName());
        }
        
        //TODO: how to make the "or" work with localization?
        var finalString = String.Join(", ", propertyNames.ToArray(), 0, propertyNames.Count - 1) + ", or " + propertyNames.LastOrDefault();

        Results.Errors.Add(new Error(ErrorCodes.IfOneIsFilledAllAreRequired, finalString));
    }

    public void AtLeastOneIsRequired(params Expression<Func<T, object>>[] requirements)
    {
        foreach (var requirement in requirements)
        {
            var wrapped = requirement.Wrap(_instance, _segmentName);
            var value = wrapped.GetPropertyValue();
            if (value != "")
                return; //one field has a value so stop here
        }
        
        var propertyNames = new List<string>();
        foreach (var requirement in requirements)
        {
            var wrapped = requirement.Wrap(_instance, _segmentName);
            propertyNames.Add(wrapped.GetFormattedPropertyName());
        }

        //TODO: how to make the "or" work with localization?
        var finalString = String.Join(", ", propertyNames.ToArray(), 0, propertyNames.Count - 1) + ", or " + propertyNames.LastOrDefault();

        Results.Errors.Add(new Error(ErrorCodes.AtLeastOneIsRequired, finalString));
    }


    public void OnlyOneOf(Expression<Func<T, object>> expressionA, Expression<Func<T, object>> expressionB)
    {
        var a = expressionA.Wrap(_instance, _segmentName);
        var b = expressionB.Wrap(_instance, _segmentName);

        var valueA = a.GetPropertyValue();
        var valueB = b.GetPropertyValue();

        if (!IsNullOrEmpty(valueA) && !IsNullOrEmpty(valueB))
        {
            Results.Errors.Add(new Error(ErrorCodes.OnlyOneOf, a.GetFormattedPropertyName(), b.GetFormattedPropertyName()));
        }
    }
  
}