using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class TRNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TRN*m*U*tDil7v9bDb*V";

		var expected = new TRN_Trace()
		{
			TraceTypeCode = "m",
			ReferenceIdentification = "U",
			OriginatingCompanyIdentifier = "tDil7v9bDb",
			ReferenceIdentification2 = "V",
		};

		var actual = Map.MapObject<TRN_Trace>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredTraceTypeCode(string traceTypeCode, bool isValidExpected)
	{
		var subject = new TRN_Trace();
		subject.ReferenceIdentification = "U";
		subject.TraceTypeCode = traceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TRN_Trace();
		subject.TraceTypeCode = "m";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
