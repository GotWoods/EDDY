using Eddy.Core.Validation;

namespace Eddy.x12.Tests;

public class x12DocumentValidationMultiSegmentTests
{
    private readonly string[] data;

    // Static constructor to ensure EdiSectionParserFactory.LoadSegmentProviders() 
    // is called once for the entire test run
    static x12DocumentValidationMultiSegmentTests()
    {
        EdiSectionParserFactory.LoadSegmentProviders();
    }

    // Constructor to initialize data
    public x12DocumentValidationMultiSegmentTests()
    {
        data = new[]
        {
            "ISA*01*0000000000*01*0000000000*ZZ*ABCDEFGHIJKLMNO*ZZ*123456789012345*101127*1719*U*00401*000003438*0*P*>~",
            "GS*SM*4405197800*999999999*20111219*1747*2100*X*004010~",
            //section 0001
            "ST*204*0001~",
            "B2**XXXX**9999955559**PP~",
            "B2A*04~",
            "S5*1*CL*27800*L*2444*CA*1016*E~",
            "SE*5*0001~",
            //section 0002
            "ST*204*0002~",
            "B2**XXXX**9999955559**PP~",
            "B2A*04~",
            "S5*1*CL*27800*L*2444*CA*1016*E~",
            "SE*5*0002~",
            "GE*2*2100~"
        };
    }

    [Fact]
    public void MultipleSections()
    {
        var subject = x12Document.Parse(string.Join(Environment.NewLine, data));
        Assert.Equal(2, subject.Sections.Count);
        Assert.True(subject.IsValid);
        
        // Assert.Single(subject.ValidationErrors);
        // Assert.Equal(12, subject.ValidationErrors[0].LineNumber);
        // Assert.Equal(ErrorCodes.TransactionSetControlNumberMismatch, subject.ValidationErrors[0].Errors[0].ErrorCode);
    }

    [Fact]
    public void InvalidSectionCount()
    {
        data[12] = "GE*1*2100~"; //set count to 1

        var subject = x12Document.Parse(string.Join(Environment.NewLine, data));
        
        Assert.False(subject.IsValid);
        Assert.Single(subject.ValidationErrors);
        Assert.Equal(ErrorCodes.FunctionalGroupSectionCountMismatch, subject.ValidationErrors[0].Errors[0].ErrorCode);
    }

    [Fact]
    public void MisMatchedControlNumberSectionCount()
    {
        data[12] = "GE*2*9999~"; //set count to 1

        var subject = x12Document.Parse(string.Join(Environment.NewLine, data));

        Assert.False(subject.IsValid);
        Assert.Single(subject.ValidationErrors);
        Assert.Equal(ErrorCodes.FunctionalGroupControlNumberMismatch, subject.ValidationErrors[0].Errors[0].ErrorCode);
    }
}