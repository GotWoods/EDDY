using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class CR8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR8*R*a*2WIkJbwX*buVcT4wb*4*4*Y*i*g";

		var expected = new CR8_PacemakerCertification()
		{
			ImplantTypeCode = "R",
			ImplantStatusCode = "a",
			Date = "2WIkJbwX",
			Date2 = "buVcT4wb",
			ReferenceIdentification = "4",
			ReferenceIdentification2 = "4",
			ReferenceIdentification3 = "Y",
			YesNoConditionOrResponseCode = "i",
			YesNoConditionOrResponseCode2 = "g",
		};

		var actual = Map.MapObject<CR8_PacemakerCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredImplantTypeCode(string implantTypeCode, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantStatusCode = "a";
		subject.Date = "2WIkJbwX";
		subject.Date2 = "buVcT4wb";
		subject.ReferenceIdentification = "4";
		subject.ReferenceIdentification2 = "4";
		subject.ReferenceIdentification3 = "Y";
		subject.YesNoConditionOrResponseCode = "i";
		subject.YesNoConditionOrResponseCode2 = "g";
		//Test Parameters
		subject.ImplantTypeCode = implantTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredImplantStatusCode(string implantStatusCode, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "R";
		subject.Date = "2WIkJbwX";
		subject.Date2 = "buVcT4wb";
		subject.ReferenceIdentification = "4";
		subject.ReferenceIdentification2 = "4";
		subject.ReferenceIdentification3 = "Y";
		subject.YesNoConditionOrResponseCode = "i";
		subject.YesNoConditionOrResponseCode2 = "g";
		//Test Parameters
		subject.ImplantStatusCode = implantStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2WIkJbwX", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "R";
		subject.ImplantStatusCode = "a";
		subject.Date2 = "buVcT4wb";
		subject.ReferenceIdentification = "4";
		subject.ReferenceIdentification2 = "4";
		subject.ReferenceIdentification3 = "Y";
		subject.YesNoConditionOrResponseCode = "i";
		subject.YesNoConditionOrResponseCode2 = "g";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("buVcT4wb", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "R";
		subject.ImplantStatusCode = "a";
		subject.Date = "2WIkJbwX";
		subject.ReferenceIdentification = "4";
		subject.ReferenceIdentification2 = "4";
		subject.ReferenceIdentification3 = "Y";
		subject.YesNoConditionOrResponseCode = "i";
		subject.YesNoConditionOrResponseCode2 = "g";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "R";
		subject.ImplantStatusCode = "a";
		subject.Date = "2WIkJbwX";
		subject.Date2 = "buVcT4wb";
		subject.ReferenceIdentification2 = "4";
		subject.ReferenceIdentification3 = "Y";
		subject.YesNoConditionOrResponseCode = "i";
		subject.YesNoConditionOrResponseCode2 = "g";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "R";
		subject.ImplantStatusCode = "a";
		subject.Date = "2WIkJbwX";
		subject.Date2 = "buVcT4wb";
		subject.ReferenceIdentification = "4";
		subject.ReferenceIdentification3 = "Y";
		subject.YesNoConditionOrResponseCode = "i";
		subject.YesNoConditionOrResponseCode2 = "g";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredReferenceIdentification3(string referenceIdentification3, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "R";
		subject.ImplantStatusCode = "a";
		subject.Date = "2WIkJbwX";
		subject.Date2 = "buVcT4wb";
		subject.ReferenceIdentification = "4";
		subject.ReferenceIdentification2 = "4";
		subject.YesNoConditionOrResponseCode = "i";
		subject.YesNoConditionOrResponseCode2 = "g";
		//Test Parameters
		subject.ReferenceIdentification3 = referenceIdentification3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "R";
		subject.ImplantStatusCode = "a";
		subject.Date = "2WIkJbwX";
		subject.Date2 = "buVcT4wb";
		subject.ReferenceIdentification = "4";
		subject.ReferenceIdentification2 = "4";
		subject.ReferenceIdentification3 = "Y";
		subject.YesNoConditionOrResponseCode2 = "g";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode2(string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "R";
		subject.ImplantStatusCode = "a";
		subject.Date = "2WIkJbwX";
		subject.Date2 = "buVcT4wb";
		subject.ReferenceIdentification = "4";
		subject.ReferenceIdentification2 = "4";
		subject.ReferenceIdentification3 = "Y";
		subject.YesNoConditionOrResponseCode = "i";
		//Test Parameters
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
