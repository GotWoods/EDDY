#nullable enable
namespace Eddy.ClassGenerator.Lib;

public interface ITransactionSetModel
{
    int Position { get; set; }
    string Name { get; set; }
    public bool Required { get; set; }
    public int Max { get; set; }
}