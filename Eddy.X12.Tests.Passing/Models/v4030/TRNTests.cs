using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class TRNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TRN*J*p*BTg1hJOirI*X";

		var expected = new TRN_Trace()
		{
			TraceTypeCode = "J",
			ReferenceIdentification = "p",
			OriginatingCompanyIdentifier = "BTg1hJOirI",
			ReferenceIdentification2 = "X",
		};

		var actual = Map.MapObject<TRN_Trace>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredTraceTypeCode(string traceTypeCode, bool isValidExpected)
	{
		var subject = new TRN_Trace();
		subject.ReferenceIdentification = "p";
		subject.TraceTypeCode = traceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TRN_Trace();
		subject.TraceTypeCode = "J";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
