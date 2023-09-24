using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TRNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TRN*V*Q*kTPGmn7G7I*x";

		var expected = new TRN_Trace()
		{
			TraceTypeCode = "V",
			ReferenceIdentification = "Q",
			OriginatingCompanyIdentifier = "kTPGmn7G7I",
			ReferenceIdentification2 = "x",
		};

		var actual = Map.MapObject<TRN_Trace>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredTraceTypeCode(string traceTypeCode, bool isValidExpected)
	{
		var subject = new TRN_Trace();
		subject.ReferenceIdentification = "Q";
		subject.TraceTypeCode = traceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TRN_Trace();
		subject.TraceTypeCode = "V";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
