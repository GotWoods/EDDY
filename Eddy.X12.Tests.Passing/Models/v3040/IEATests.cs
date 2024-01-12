using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class IEATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IEA*8*925711177";

		var expected = new IEA_InterchangeControlTrailer()
		{
			NumberOfIncludedFunctionalGroups = 8,
			InterchangeControlNumber = "925711177",
		};

		var actual = Map.MapObject<IEA_InterchangeControlTrailer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredNumberOfIncludedFunctionalGroups(int numberOfIncludedFunctionalGroups, bool isValidExpected)
	{
		var subject = new IEA_InterchangeControlTrailer();
		//Required fields
		subject.InterchangeControlNumber = "925711177";
		//Test Parameters
		if (numberOfIncludedFunctionalGroups > 0) 
			subject.NumberOfIncludedFunctionalGroups = numberOfIncludedFunctionalGroups;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("925711177", true)]
	public void Validation_RequiredInterchangeControlNumber(string interchangeControlNumber, bool isValidExpected)
	{
		var subject = new IEA_InterchangeControlTrailer();
		//Required fields
		subject.NumberOfIncludedFunctionalGroups = 8;
		//Test Parameters
		if (interchangeControlNumber != "") 
			subject.InterchangeControlNumber = interchangeControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

    [Theory]
    [InlineData("A23456789", false)]
    [InlineData("925711177", true)]
    public void Validation_RequiredInterchangeControlNumberToBeNumeric(string interchangeControlNumber, bool isValidExpected)
    {
        var subject = new IEA_InterchangeControlTrailer();
        //Required fields
        subject.NumberOfIncludedFunctionalGroups = 8;
        //Test Parameters
        if (interchangeControlNumber != "")
            subject.InterchangeControlNumber = interchangeControlNumber;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ConvertibleToInteger);
    }

}
