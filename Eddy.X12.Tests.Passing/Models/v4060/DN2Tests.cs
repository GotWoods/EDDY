using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class DN2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DN2*X*K*1*X9*8*K";

		var expected = new DN2_ToothSummary()
		{
			ReferenceIdentification = "X",
			ToothStatusCode = "K",
			Quantity = 1,
			DateTimePeriodFormatQualifier = "X9",
			DateTimePeriod = "8",
			CodeListQualifierCode = "K",
		};

		var actual = Map.MapObject<DN2_ToothSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new DN2_ToothSummary();
		//Required fields
		subject.CodeListQualifierCode = "K";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "X9";
			subject.DateTimePeriod = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X9", "8", true)]
	[InlineData("X9", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DN2_ToothSummary();
		//Required fields
		subject.ReferenceIdentification = "X";
		subject.CodeListQualifierCode = "K";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new DN2_ToothSummary();
		//Required fields
		subject.ReferenceIdentification = "X";
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "X9";
			subject.DateTimePeriod = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
