namespace Eddy.Notepad.ViewModels;

/// <summary>Where a node sits in the EDI envelope hierarchy.</summary>
public enum NodeKind
{
    Interchange,      // ISA ... IEA
    FunctionalGroup,  // GS ... GE
    TransactionSet,   // ST ... SE
    Segment           // any segment inside a transaction set
}
