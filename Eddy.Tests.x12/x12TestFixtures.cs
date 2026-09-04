using System.Collections.Generic;
using System.Text;

namespace Eddy.x12.Tests;

/// <summary>Shared building blocks for hand-built x12 fixtures used across the parser tests.</summary>
internal static class x12TestFixtures
{
    /// <summary>A body of 13 segments that passes validation untouched (SE count is therefore 15).</summary>
    public static readonly string[] GoodBody =
    {
        "B2**XXXX**9999955559**PP~",
        "B2A*04~",
        "L11*NONPRIMARY*OK~",
        "NTE**FROZEN GOODS SET TO -10d F~",
        "N1*PF*XYZ CORP*9*9995555500000~",
        "N3*31875 SOLON RD~",
        "N4*SOLON*OH*44139~",
        "N7**NONE*********FF****5300~",
        "S5*1*CL*27800*L*2444*CA*1016*E~",
        "L11*9999001947*DO~",
        "L11*9999670098*CR~",
        "L11*9999001866*DO~",
        "L11*9999669887*CR~"
    };

    public static string Isa(string controlNumber, string newline = "~\n")
    {
        return $"ISA*01*0000000000*01*0000000000*ZZ*ABCDEFGHIJKLMNO*ZZ*123456789012345*101127*1719*U*00401*{controlNumber}*0*P*>{newline}";
    }

    public static string Gs(string groupControlNumber, string newline = "~\n")
    {
        return $"GS*SM*4405197800*999999999*20111219*1747*{groupControlNumber}*X*004010{newline}";
    }

    public static string St(string transactionSetControlNumber, string newline = "~\n")
    {
        return $"ST*204*{transactionSetControlNumber}{newline}";
    }

    public static string Se(int segmentCount, string transactionSetControlNumber, string newline = "~\n")
    {
        return $"SE*{segmentCount}*{transactionSetControlNumber}{newline}";
    }

    public static string Ge(int sectionCount, string groupControlNumber, string newline = "~\n")
    {
        return $"GE*{sectionCount}*{groupControlNumber}{newline}";
    }

    public static string Iea(int groupCount, string controlNumber, string newline = "~\n")
    {
        return $"IEA*{groupCount}*{controlNumber}{newline}";
    }

    /// <summary>One well-formed ST...SE section built from GoodBody.</summary>
    public static string Section(string transactionSetControlNumber, string newline = "~\n")
    {
        var sb = new StringBuilder();
        sb.Append(St(transactionSetControlNumber, newline));
        foreach (var line in GoodBody)
            sb.Append(line.Replace("~", newline));
        sb.Append(Se(GoodBody.Length + 2, transactionSetControlNumber, newline));
        return sb.ToString();
    }

    /// <summary>A single, well-formed interchange with one group and one section.</summary>
    public static string SingleValidInterchange(string isaControl = "000000001", string groupControl = "2100", string stControl = "0001", string newline = "~\n")
    {
        var sb = new StringBuilder();
        sb.Append(Isa(isaControl, newline));
        sb.Append(Gs(groupControl, newline));
        sb.Append(Section(stControl, newline));
        sb.Append(Ge(1, groupControl, newline));
        sb.Append(Iea(1, isaControl, newline));
        return sb.ToString();
    }
}
