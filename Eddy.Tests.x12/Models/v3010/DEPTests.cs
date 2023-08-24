using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class DEPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DEP*1*whGXhu*rXfZ*y*f7*We3*NA*o";

		var expected = new DEP_Deposit()
		{
			ReferenceNumber = "1",
			Date = "whGXhu",
			Time = "rXfZ",
			ReferenceNumber2 = "y",
			DFIIDNumberQualifier = "f7",
			DFIIdentificationNumber = "We3",
			AccountNumberQualifierCode = "NA",
			AccountNumber = "o",
		};

		var actual = Map.MapObject<DEP_Deposit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.Date = "whGXhu";
		subject.DFIIDNumberQualifier = "f7";
		subject.DFIIdentificationNumber = "We3";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("whGXhu", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceNumber = "1";
		subject.DFIIDNumberQualifier = "f7";
		subject.DFIIdentificationNumber = "We3";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f7", true)]
	public void Validation_RequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceNumber = "1";
		subject.Date = "whGXhu";
		subject.DFIIdentificationNumber = "We3";
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("We3", true)]
	public void Validation_RequiredDFIIdentificationNumber(string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceNumber = "1";
		subject.Date = "whGXhu";
		subject.DFIIDNumberQualifier = "f7";
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
