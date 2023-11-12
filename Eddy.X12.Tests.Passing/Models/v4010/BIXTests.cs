using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BIXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BIX*k3*4B*yw8wD58E*9*8*sK*9Y*z*W*T*YL";

		var expected = new BIX_BeginningSegmentForAutomotiveInspection()
		{
			TransactionSetPurposeCode = "k3",
			StandardCarrierAlphaCode = "4B",
			Date = "yw8wD58E",
			InspectionLocationTypeCode = "9",
			RampIdentification = "8",
			CityName = "sK",
			StateOrProvinceCode = "9Y",
			InspectorIdentityCode = "z",
			DamageCodeQualifier = "W",
			IdentificationCodeQualifier = "T",
			IdentificationCode = "YL",
		};

		var actual = Map.MapObject<BIX_BeginningSegmentForAutomotiveInspection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k3", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BIX_BeginningSegmentForAutomotiveInspection();
		//Required fields
		subject.StandardCarrierAlphaCode = "4B";
		subject.Date = "yw8wD58E";
		subject.InspectionLocationTypeCode = "9";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4B", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BIX_BeginningSegmentForAutomotiveInspection();
		//Required fields
		subject.TransactionSetPurposeCode = "k3";
		subject.Date = "yw8wD58E";
		subject.InspectionLocationTypeCode = "9";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yw8wD58E", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BIX_BeginningSegmentForAutomotiveInspection();
		//Required fields
		subject.TransactionSetPurposeCode = "k3";
		subject.StandardCarrierAlphaCode = "4B";
		subject.InspectionLocationTypeCode = "9";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredInspectionLocationTypeCode(string inspectionLocationTypeCode, bool isValidExpected)
	{
		var subject = new BIX_BeginningSegmentForAutomotiveInspection();
		//Required fields
		subject.TransactionSetPurposeCode = "k3";
		subject.StandardCarrierAlphaCode = "4B";
		subject.Date = "yw8wD58E";
		//Test Parameters
		subject.InspectionLocationTypeCode = inspectionLocationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
