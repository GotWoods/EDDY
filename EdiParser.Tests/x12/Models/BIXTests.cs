using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BIXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BIX*9C*n7*EjaklDo7*X*s*GE*36*C*a*H*P2";

		var expected = new BIX_BeginningSegmentForAutomotiveInspection()
		{
			TransactionSetPurposeCode = "9C",
			StandardCarrierAlphaCode = "n7",
			Date = "EjaklDo7",
			InspectionLocationTypeCode = "X",
			RampIdentification = "s",
			CityName = "GE",
			StateOrProvinceCode = "36",
			InspectorIdentityCode = "C",
			DamageCodeQualifier = "a",
			IdentificationCodeQualifier = "H",
			IdentificationCode = "P2",
		};

		var actual = Map.MapObject<BIX_BeginningSegmentForAutomotiveInspection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9C", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BIX_BeginningSegmentForAutomotiveInspection();
		subject.StandardCarrierAlphaCode = "n7";
		subject.Date = "EjaklDo7";
		subject.InspectionLocationTypeCode = "X";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n7", true)]
	public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BIX_BeginningSegmentForAutomotiveInspection();
		subject.TransactionSetPurposeCode = "9C";
		subject.Date = "EjaklDo7";
		subject.InspectionLocationTypeCode = "X";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("EjaklDo7", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BIX_BeginningSegmentForAutomotiveInspection();
		subject.TransactionSetPurposeCode = "9C";
		subject.StandardCarrierAlphaCode = "n7";
		subject.InspectionLocationTypeCode = "X";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validatation_RequiredInspectionLocationTypeCode(string inspectionLocationTypeCode, bool isValidExpected)
	{
		var subject = new BIX_BeginningSegmentForAutomotiveInspection();
		subject.TransactionSetPurposeCode = "9C";
		subject.StandardCarrierAlphaCode = "n7";
		subject.Date = "EjaklDo7";
		subject.InspectionLocationTypeCode = inspectionLocationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
