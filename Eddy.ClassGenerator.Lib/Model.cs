using System;
using System.Collections.Generic;
using System.Text;

namespace Eddy.ClassGenerator.Lib;

public class Model
{


    public Model(string position, string name, string dataType, int min, int max)
    {
        Position = position;
        Name = name;
        DataType = dataType;
        Min = min;
        Max = max;
    }

    private string _testValue = string.Empty;
    public string TestValue
    {
        get
        {
            {
                if (_testValue != string.Empty) 
                    return _testValue;

                var result = "";
                if (IsDataTypeNumeric)
                {
                    var random = new Random();
                    for (var i = 0; i < Min; i++)
                        result = string.Concat(result, random.Next(1, 10).ToString());
                }
                else
                {
                    for (int i = 0; i < Min; i++)
                    {
                        result += RandomLetter();
                    }
                }
                _testValue = result;
                return _testValue;
            }
        }
    }

    private char RandomLetter()
    {
        string chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Random rand = new Random();
        int num = rand.Next(0, chars.Length);
        return chars[num];
    }

    public string Position { get; set; }
    public string Name { get; set; }
    public string DataType { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }
    public bool IsRequired { get; set; }
    public bool IsDataTypeNumeric => DataType is "int?" or "decimal?";
    public List<ValidationData> IfOneIsFilledAllAreRequiredValidations { get; set; } = new();
    public List<ValidationData> AtLeastOneValidations { get; set; } = new();
    public List<ValidationData> ARequiresBValidation { get; set; } = new();
    public List<ValidationData> OnlyOneOfValidations { get; set; } = new();
    public List<ValidationData> IfOneIsFilledThenAtLeastOne { get; set; } = new();
   


    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"\t[Position({Position})]");
        sb.Append($"\tpublic {DataType} {Name} ");
        sb.AppendLine("{ get; set; }");

        return sb.ToString();
    }

    protected bool Equals(Model other)
    {
        return Position == other.Position;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Model)obj);
    }

    public bool DeepEquals(Model compareTo)
    {
        if (this.Position != compareTo.Position)
            return false;
        if (this.Name != compareTo.Name) return false;
        if (this.DataType != compareTo.DataType) return false;
        if (this.Min != compareTo.Min) return false;
        if (this.Max!= compareTo.Max) return false;
        if (this.IsRequired != compareTo.IsRequired) return false;
        if (this.IsDataTypeNumeric != compareTo.IsDataTypeNumeric) return false;

        //TODO: check if validations vary
        return true;
    }

    public override int GetHashCode()
    {
        return Position.GetHashCode();
    }
}