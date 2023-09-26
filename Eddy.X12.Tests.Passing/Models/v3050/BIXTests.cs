using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BIXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BIX*dh*Jt*UgEeJb*l*5*RF*w6*F*H*Q*Sf";

		var expected = new BIX_BeginningSegmentForAutomotiveInspection()
		{
			TransactionSetPurposeCode = "dh",
			StandardCarrierAlphaCode = "Jt",
			Date = "UgEeJb",
			InspectionLocationTypeCode = "l",
			RampIdentification = "5",
			CityName = "RF",
			StateOrProvinceCode = "w6",
			InspectorIdentityCode = "F",
			DamageCodeQualifier = "H",
			IdentificationCodeQualifier = "Q",
			IdentificationCode = "Sf",
		};

		var actual = Map.MapObject<BIX_BeginningSegmentForAutomotiveInspection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dh", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BIX_BeginningSegmentForAutomotiveInspection();
		//Required fields
		subject.StandardCarrierAlphaCode = "Jt";
		subject.Date = "UgEeJb";
		subject.InspectionLocationTypeCode = "l";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Jt", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BIX_BeginningSegmentForAutomotiveInspection();
		//Required fields
		subject.TransactionSetPurposeCode = "dh";
		subject.Date = "UgEeJb";
		subject.InspectionLocationTypeCode = "l";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UgEeJb", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BIX_BeginningSegmentForAutomotiveInspection();
		//Required fields
		subject.TransactionSetPurposeCode = "dh";
		subject.StandardCarrierAlphaCode = "Jt";
		subject.InspectionLocationTypeCode = "l";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredInspectionLocationTypeCode(string inspectionLocationTypeCode, bool isValidExpected)
	{
		var subject = new BIX_BeginningSegmentForAutomotiveInspection();
		//Required fields
		subject.TransactionSetPurposeCode = "dh";
		subject.StandardCarrierAlphaCode = "Jt";
		subject.Date = "UgEeJb";
		//Test Parameters
		subject.InspectionLocationTypeCode = inspectionLocationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
