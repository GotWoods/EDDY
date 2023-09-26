using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class CR8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR8*C*I*UYVmkWlf*UxAXXJON*e*k*h*n*i";

		var expected = new CR8_PacemakerCertification()
		{
			ImplantTypeCode = "C",
			ImplantStatusCode = "I",
			Date = "UYVmkWlf",
			Date2 = "UxAXXJON",
			ReferenceIdentification = "e",
			ReferenceIdentification2 = "k",
			ReferenceIdentification3 = "h",
			YesNoConditionOrResponseCode = "n",
			YesNoConditionOrResponseCode2 = "i",
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
		subject.ImplantStatusCode = "I";
		subject.Date = "UYVmkWlf";
		subject.Date2 = "UxAXXJON";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentification2 = "k";
		subject.ReferenceIdentification3 = "h";
		subject.YesNoConditionOrResponseCode = "n";
		subject.YesNoConditionOrResponseCode2 = "i";
		//Test Parameters
		subject.ImplantTypeCode = implantTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredImplantStatusCode(string implantStatusCode, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "C";
		subject.Date = "UYVmkWlf";
		subject.Date2 = "UxAXXJON";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentification2 = "k";
		subject.ReferenceIdentification3 = "h";
		subject.YesNoConditionOrResponseCode = "n";
		subject.YesNoConditionOrResponseCode2 = "i";
		//Test Parameters
		subject.ImplantStatusCode = implantStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UYVmkWlf", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "C";
		subject.ImplantStatusCode = "I";
		subject.Date2 = "UxAXXJON";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentification2 = "k";
		subject.ReferenceIdentification3 = "h";
		subject.YesNoConditionOrResponseCode = "n";
		subject.YesNoConditionOrResponseCode2 = "i";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UxAXXJON", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "C";
		subject.ImplantStatusCode = "I";
		subject.Date = "UYVmkWlf";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentification2 = "k";
		subject.ReferenceIdentification3 = "h";
		subject.YesNoConditionOrResponseCode = "n";
		subject.YesNoConditionOrResponseCode2 = "i";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "C";
		subject.ImplantStatusCode = "I";
		subject.Date = "UYVmkWlf";
		subject.Date2 = "UxAXXJON";
		subject.ReferenceIdentification2 = "k";
		subject.ReferenceIdentification3 = "h";
		subject.YesNoConditionOrResponseCode = "n";
		subject.YesNoConditionOrResponseCode2 = "i";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "C";
		subject.ImplantStatusCode = "I";
		subject.Date = "UYVmkWlf";
		subject.Date2 = "UxAXXJON";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentification3 = "h";
		subject.YesNoConditionOrResponseCode = "n";
		subject.YesNoConditionOrResponseCode2 = "i";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredReferenceIdentification3(string referenceIdentification3, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "C";
		subject.ImplantStatusCode = "I";
		subject.Date = "UYVmkWlf";
		subject.Date2 = "UxAXXJON";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentification2 = "k";
		subject.YesNoConditionOrResponseCode = "n";
		subject.YesNoConditionOrResponseCode2 = "i";
		//Test Parameters
		subject.ReferenceIdentification3 = referenceIdentification3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "C";
		subject.ImplantStatusCode = "I";
		subject.Date = "UYVmkWlf";
		subject.Date2 = "UxAXXJON";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentification2 = "k";
		subject.ReferenceIdentification3 = "h";
		subject.YesNoConditionOrResponseCode2 = "i";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode2(string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "C";
		subject.ImplantStatusCode = "I";
		subject.Date = "UYVmkWlf";
		subject.Date2 = "UxAXXJON";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentification2 = "k";
		subject.ReferenceIdentification3 = "h";
		subject.YesNoConditionOrResponseCode = "n";
		//Test Parameters
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
