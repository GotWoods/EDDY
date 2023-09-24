using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TRNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TRN*V*Ph*m*6h*f*m*A*bx*A";

		var expected = new TRN_Trace()
		{
			TraceTypeCode = "V",
			EntityIdentifierCode = "Ph",
			IdentificationCodeQualifier = "m",
			IdentificationCode = "6h",
			ReferenceNumber = "f",
			ApplicationBatchIdentifier = "m",
			ApplicationItemIdentifier = "A",
			ReferenceNumberQualifier = "bx",
			ReferenceNumber2 = "A",
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
		subject.EntityIdentifierCode = "Ph";
		subject.IdentificationCodeQualifier = "m";
		subject.IdentificationCode = "6h";
		subject.TraceTypeCode = traceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ph", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new TRN_Trace();
		subject.TraceTypeCode = "V";
		subject.IdentificationCodeQualifier = "m";
		subject.IdentificationCode = "6h";
		subject.EntityIdentifierCode = entityIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new TRN_Trace();
		subject.TraceTypeCode = "V";
		subject.EntityIdentifierCode = "Ph";
		subject.IdentificationCode = "6h";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6h", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new TRN_Trace();
		subject.TraceTypeCode = "V";
		subject.EntityIdentifierCode = "Ph";
		subject.IdentificationCodeQualifier = "m";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
