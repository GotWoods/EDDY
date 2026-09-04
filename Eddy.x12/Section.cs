using System.Collections.Generic;
using Eddy.x12.Models;

using ST_TransactionSetHeader = Eddy.x12.Models.ST_TransactionSetHeader;
using SE_TransactionSetTrailer = Eddy.x12.Models.SE_TransactionSetTrailer;

namespace Eddy.x12;

public class Section
{
    public string SectionType { get; set; }
    public List<EdiX12Segment> Segments { get; set; } = new();
    public string TransactionSetControlNumber { get; set; }

    /// <summary>The ST segment that opened this transaction set.</summary>
    public ST_TransactionSetHeader TransactionSetHeader { get; set; }

    /// <summary>The SE segment that closed this transaction set, or null if it was never found (missing trailer).</summary>
    public SE_TransactionSetTrailer TransactionSetTrailer { get; set; }
}
