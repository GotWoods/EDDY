using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BIXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BIX*Uw*KQ*6xtcQT*P*u*A1*YL*T*C*v*an";

		var expected = new BIX_BeginningSegmentForAutomotiveInspection()
		{
			TransactionSetPurposeCode = "Uw",
			StandardCarrierAlphaCode = "KQ",
			Date = "6xtcQT",
			InspectionLocationTypeCode = "P",
			RampIdentification = "u",
			CityName = "A1",
			StateOrProvinceCode = "YL",
			InspectorIdentityCode = "T",
			DamageCodeQualifier = "C",
			IdentificationCodeQualifier = "v",
			IdentificationCode = "an",
		};

		var actual = Map.MapObject<BIX_BeginningSegmentForAutomotiveInspection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Uw", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BIX_BeginningSegmentForAutomotiveInspection();
		//Required fields
		subject.StandardCarrierAlphaCode = "KQ";
		subject.Date = "6xtcQT";
		subject.InspectionLocationTypeCode = "P";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KQ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BIX_BeginningSegmentForAutomotiveInspection();
		//Required fields
		subject.TransactionSetPurposeCode = "Uw";
		subject.Date = "6xtcQT";
		subject.InspectionLocationTypeCode = "P";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6xtcQT", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BIX_BeginningSegmentForAutomotiveInspection();
		//Required fields
		subject.TransactionSetPurposeCode = "Uw";
		subject.StandardCarrierAlphaCode = "KQ";
		subject.InspectionLocationTypeCode = "P";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredInspectionLocationTypeCode(string inspectionLocationTypeCode, bool isValidExpected)
	{
		var subject = new BIX_BeginningSegmentForAutomotiveInspection();
		//Required fields
		subject.TransactionSetPurposeCode = "Uw";
		subject.StandardCarrierAlphaCode = "KQ";
		subject.Date = "6xtcQT";
		//Test Parameters
		subject.InspectionLocationTypeCode = inspectionLocationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
