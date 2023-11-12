using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CR8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR8*C*2*7LItaJp8*oBF42rVV*a*p*P*4*E";

		var expected = new CR8_PacemakerCertification()
		{
			ImplantTypeCode = "C",
			ImplantStatusCode = "2",
			Date = "7LItaJp8",
			Date2 = "oBF42rVV",
			ReferenceIdentification = "a",
			ReferenceIdentification2 = "p",
			ReferenceIdentification3 = "P",
			YesNoConditionOrResponseCode = "4",
			YesNoConditionOrResponseCode2 = "E",
		};

		var actual = Map.MapObject<CR8_PacemakerCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredImplantTypeCode(string implantTypeCode, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantStatusCode = "2";
		subject.Date = "7LItaJp8";
		subject.Date2 = "oBF42rVV";
		subject.ReferenceIdentification = "a";
		subject.ReferenceIdentification2 = "p";
		subject.ReferenceIdentification3 = "P";
		subject.YesNoConditionOrResponseCode = "4";
		subject.YesNoConditionOrResponseCode2 = "E";
		//Test Parameters
		subject.ImplantTypeCode = implantTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredImplantStatusCode(string implantStatusCode, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "C";
		subject.Date = "7LItaJp8";
		subject.Date2 = "oBF42rVV";
		subject.ReferenceIdentification = "a";
		subject.ReferenceIdentification2 = "p";
		subject.ReferenceIdentification3 = "P";
		subject.YesNoConditionOrResponseCode = "4";
		subject.YesNoConditionOrResponseCode2 = "E";
		//Test Parameters
		subject.ImplantStatusCode = implantStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7LItaJp8", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "C";
		subject.ImplantStatusCode = "2";
		subject.Date2 = "oBF42rVV";
		subject.ReferenceIdentification = "a";
		subject.ReferenceIdentification2 = "p";
		subject.ReferenceIdentification3 = "P";
		subject.YesNoConditionOrResponseCode = "4";
		subject.YesNoConditionOrResponseCode2 = "E";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oBF42rVV", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "C";
		subject.ImplantStatusCode = "2";
		subject.Date = "7LItaJp8";
		subject.ReferenceIdentification = "a";
		subject.ReferenceIdentification2 = "p";
		subject.ReferenceIdentification3 = "P";
		subject.YesNoConditionOrResponseCode = "4";
		subject.YesNoConditionOrResponseCode2 = "E";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "C";
		subject.ImplantStatusCode = "2";
		subject.Date = "7LItaJp8";
		subject.Date2 = "oBF42rVV";
		subject.ReferenceIdentification2 = "p";
		subject.ReferenceIdentification3 = "P";
		subject.YesNoConditionOrResponseCode = "4";
		subject.YesNoConditionOrResponseCode2 = "E";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "C";
		subject.ImplantStatusCode = "2";
		subject.Date = "7LItaJp8";
		subject.Date2 = "oBF42rVV";
		subject.ReferenceIdentification = "a";
		subject.ReferenceIdentification3 = "P";
		subject.YesNoConditionOrResponseCode = "4";
		subject.YesNoConditionOrResponseCode2 = "E";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredReferenceIdentification3(string referenceIdentification3, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "C";
		subject.ImplantStatusCode = "2";
		subject.Date = "7LItaJp8";
		subject.Date2 = "oBF42rVV";
		subject.ReferenceIdentification = "a";
		subject.ReferenceIdentification2 = "p";
		subject.YesNoConditionOrResponseCode = "4";
		subject.YesNoConditionOrResponseCode2 = "E";
		//Test Parameters
		subject.ReferenceIdentification3 = referenceIdentification3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "C";
		subject.ImplantStatusCode = "2";
		subject.Date = "7LItaJp8";
		subject.Date2 = "oBF42rVV";
		subject.ReferenceIdentification = "a";
		subject.ReferenceIdentification2 = "p";
		subject.ReferenceIdentification3 = "P";
		subject.YesNoConditionOrResponseCode2 = "E";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode2(string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "C";
		subject.ImplantStatusCode = "2";
		subject.Date = "7LItaJp8";
		subject.Date2 = "oBF42rVV";
		subject.ReferenceIdentification = "a";
		subject.ReferenceIdentification2 = "p";
		subject.ReferenceIdentification3 = "P";
		subject.YesNoConditionOrResponseCode = "4";
		//Test Parameters
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
