using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class TRNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TRN*F*N*WyRSUwVwTx*w";

		var expected = new TRN_Trace()
		{
			TraceTypeCode = "F",
			ReferenceIdentification = "N",
			OriginatingCompanyIdentifier = "WyRSUwVwTx",
			ReferenceIdentification2 = "w",
		};

		var actual = Map.MapObject<TRN_Trace>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredTraceTypeCode(string traceTypeCode, bool isValidExpected)
	{
		var subject = new TRN_Trace();
		subject.ReferenceIdentification = "N";
		subject.TraceTypeCode = traceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TRN_Trace();
		subject.TraceTypeCode = "F";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
