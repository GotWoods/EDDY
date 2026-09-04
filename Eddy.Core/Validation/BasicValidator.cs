using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Eddy.Core.Attributes;
using Eddy.Core.Codes;
using Eddy.Core.Metadata;
using static System.String;

namespace Eddy.Core.Validation;

public class BasicValidator<T>
{
    private readonly T _instance;
    private readonly string _segmentName;
    public ValidationResult Results = new();

    public BasicValidator(T instance)
    {
        _instance = instance;
        _segmentName = _instance.GetType().GetCustomAttribute<Segment>()?.Name ?? _instance.GetType().Name;
        Results.SegmentCode = _segmentName;
    }

    /// <summary>Records which property (and element position) an error is about, so callers can locate it.</summary>
    private static Error Tag(Error error, WrappedExpression<T> wrapped)
    {
        error.PropertyName = wrapped.GetPropertyName();
        error.ElementPosition = wrapped.GetPosition();
        return error;
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
            Results.Errors.Add(Tag(new Error(ErrorCodes.AorBRequired, propertyNameA, propertyNameB), a));
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
            Results.Errors.Add(Tag(new Error(ErrorCodes.DateIsNotValidFormat, a.GetFormattedPropertyName()), a));
            return;
        }

        //It is CCYYMMDD in the spec but this is a C# translation of that
        //TODO: this may be extracted as different date formats may be used. Also when models get a GetDate/GetTime/GetDateAndTime this will be duplicated
        if (!DateTime.TryParseExact(valueA, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None,out DateTime _))
        {
            Results.Errors.Add(Tag(new Error(ErrorCodes.DateIsNotValidFormat, a.GetFormattedPropertyName()), a));
            return;
        }

        // if (valueA.Length == 5) //HHMMS is invalid
        // {
        //     Results.Errors.Add(Tag(new Error(ErrorCodes.DateIsNotValidFormat, a.GetFormattedPropertyName()), a));
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
            Results.Errors.Add(Tag(new Error(ErrorCodes.TimeIsNotValidFormat, a.GetFormattedPropertyName()), a));
            return;
        }

        if (valueA.Length == 5) //HHMMS is invalid (but having one more S makes it valid, D can be be 0-2
        {
            Results.Errors.Add(Tag(new Error(ErrorCodes.TimeIsNotValidFormat, a.GetFormattedPropertyName()), a));
            return;
        }

        //It is HHMMDDSS in the spec but this is a C# translation of that
        //
        //TODO: this may be extracted as different date formats may be used. Also when models get a GetDate/GetTime/GetDateAndTime this will be duplicated
        if (!DateTime.TryParseExact(valueA.Substring(0,4), "HHmm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime _))
        {
            Results.Errors.Add(Tag(new Error(ErrorCodes.TimeIsNotValidFormat, a.GetFormattedPropertyName()), a));
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
            Results.Errors.Add(Tag(new Error(ErrorCodes.TimeIsNotValidFormat, a.GetFormattedPropertyName()), a));
            return;
        }

        if (decimalSeconds > 99) //really not possible as we only parse two digits and we know it is numeric
        {
            Results.Errors.Add(Tag(new Error(ErrorCodes.TimeIsNotValidFormat, a.GetFormattedPropertyName()), a));
            return;
        }


    }

    public void ConvertibleToInteger(Expression<Func<T, object>> expression)
    {
        var wrap = expression.Wrap(_instance, _segmentName);
        if (!int.TryParse(wrap.GetPropertyValue(), NumberStyles.None, CultureInfo.InvariantCulture, out _))
            Results.Errors.Add(Tag(new Error(ErrorCodes.ConvertibleToInteger, wrap.GetFormattedPropertyName()), wrap));
    }

    public void Required(Expression<Func<T, object>> expression)
    {
        var wrap = expression.Wrap(_instance, _segmentName);
        if (wrap.GetPropertyValue() == "") 
            Results.Errors.Add(Tag(new Error(ErrorCodes.Required, wrap.GetFormattedPropertyName()), wrap));
    }

    public void Length(Expression<Func<T, object>> expression, int min, int max)
    {
        var wrap = expression.Wrap(_instance, _segmentName);
        var propertyValue = wrap.GetPropertyValue();

        if (propertyValue == "") //Required() will catch this if it is required
            return;

        if (propertyValue.Length < min || propertyValue.Length > max)
        {
            Results.Errors.Add(Tag(new Error(ErrorCodes.OutOfRange, wrap.GetFormattedPropertyName(), min.ToString(), max.ToString(), propertyValue.Length.ToString()), wrap));
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
            Results.Errors.Add(Tag(new Error(ErrorCodes.ExactLength, wrap.GetFormattedPropertyName(), length.ToString(), value.Length.ToString()), wrap));
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
            Results.Errors.Add(Tag(new Error(ErrorCodes.ARequiresB, a.GetFormattedPropertyName(), b.GetFormattedPropertyName()), a));
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
            Results.Errors.Add(Tag(new Error(ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired, a.GetFormattedPropertyName(), finalString), a));
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


    /// <summary>Flags a value that is not one of the known codes for <paramref name="dataElementNumber"/>,
    /// as a <see cref="ValidationSettings.CodeListSeverity"/>-severity error. The standard is inferred from
    /// T's namespace (see <see cref="DerivedSegmentMetadata.InferStandardAndVersion"/>); pass it explicitly
    /// with the other overload when T is not a generated model type. Silent when the value is empty, when
    /// the standard cannot be determined, or when <see cref="CodeList.Catalog"/> has no code list loaded
    /// for this data element (in any version, when <paramref name="version"/> is null).</summary>
    public void KnownCode(Expression<Func<T, object>> expression, string dataElementNumber, string version = null)
    {
        string standard, inferredVersion;
        DerivedSegmentMetadata.InferStandardAndVersion(typeof(T), out standard, out inferredVersion);
        KnownCode(expression, standard, dataElementNumber, version ?? inferredVersion);
    }

    /// <summary>Overload for callers that know the standard explicitly rather than relying on it being
    /// inferable from T's namespace (e.g. a hand-written segment used only in tests).</summary>
    public void KnownCode(Expression<Func<T, object>> expression, string standard, string dataElementNumber, string version)
    {
        var wrap = expression.Wrap(_instance, _segmentName);
        var value = wrap.GetPropertyValue();
        if (IsNullOrEmpty(value) || standard == null || dataElementNumber == null)
            return;

        var catalog = CodeList.Catalog ?? MetadataCatalog.Default;
        var codes = version != null
            ? catalog.GetCodes(standard, version, dataElementNumber)
            : catalog.GetCodesAnyVersion(standard, dataElementNumber);

        if (codes == null) // no code list loaded for this element - silent
            return;

        if (codes.ContainsKey(value))
            return;

        Results.Errors.Add(Tag(new Error(ErrorCodes.UnknownCodeValue, wrap.GetFormattedPropertyName(), value, dataElementNumber)
        {
            Severity = ValidationSettings.CodeListSeverity,
        }, wrap));
    }

    public void OnlyOneOf(Expression<Func<T, object>> expressionA, Expression<Func<T, object>> expressionB)
    {
        var a = expressionA.Wrap(_instance, _segmentName);
        var b = expressionB.Wrap(_instance, _segmentName);

        var valueA = a.GetPropertyValue();
        var valueB = b.GetPropertyValue();

        if (!IsNullOrEmpty(valueA) && !IsNullOrEmpty(valueB))
        {
            Results.Errors.Add(Tag(new Error(ErrorCodes.OnlyOneOf, a.GetFormattedPropertyName(), b.GetFormattedPropertyName()), a));
        }
    }

  
  
}