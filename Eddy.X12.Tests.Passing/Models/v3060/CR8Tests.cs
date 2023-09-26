using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CR8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR8*J*Q*oUFKz9*iyYNDb*4*5*s*o*L";

		var expected = new CR8_PacemakerCertification()
		{
			ImplantTypeCode = "J",
			ImplantStatusCode = "Q",
			Date = "oUFKz9",
			Date2 = "iyYNDb",
			ReferenceIdentification = "4",
			ReferenceIdentification2 = "5",
			ReferenceIdentification3 = "s",
			YesNoConditionOrResponseCode = "o",
			YesNoConditionOrResponseCode2 = "L",
		};

		var actual = Map.MapObject<CR8_PacemakerCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredImplantTypeCode(string implantTypeCode, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantStatusCode = "Q";
		subject.Date = "oUFKz9";
		subject.Date2 = "iyYNDb";
		subject.ReferenceIdentification = "4";
		subject.ReferenceIdentification2 = "5";
		subject.ReferenceIdentification3 = "s";
		subject.YesNoConditionOrResponseCode = "o";
		subject.YesNoConditionOrResponseCode2 = "L";
		//Test Parameters
		subject.ImplantTypeCode = implantTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredImplantStatusCode(string implantStatusCode, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "J";
		subject.Date = "oUFKz9";
		subject.Date2 = "iyYNDb";
		subject.ReferenceIdentification = "4";
		subject.ReferenceIdentification2 = "5";
		subject.ReferenceIdentification3 = "s";
		subject.YesNoConditionOrResponseCode = "o";
		subject.YesNoConditionOrResponseCode2 = "L";
		//Test Parameters
		subject.ImplantStatusCode = implantStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oUFKz9", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "J";
		subject.ImplantStatusCode = "Q";
		subject.Date2 = "iyYNDb";
		subject.ReferenceIdentification = "4";
		subject.ReferenceIdentification2 = "5";
		subject.ReferenceIdentification3 = "s";
		subject.YesNoConditionOrResponseCode = "o";
		subject.YesNoConditionOrResponseCode2 = "L";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iyYNDb", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "J";
		subject.ImplantStatusCode = "Q";
		subject.Date = "oUFKz9";
		subject.ReferenceIdentification = "4";
		subject.ReferenceIdentification2 = "5";
		subject.ReferenceIdentification3 = "s";
		subject.YesNoConditionOrResponseCode = "o";
		subject.YesNoConditionOrResponseCode2 = "L";
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
		subject.ImplantTypeCode = "J";
		subject.ImplantStatusCode = "Q";
		subject.Date = "oUFKz9";
		subject.Date2 = "iyYNDb";
		subject.ReferenceIdentification2 = "5";
		subject.ReferenceIdentification3 = "s";
		subject.YesNoConditionOrResponseCode = "o";
		subject.YesNoConditionOrResponseCode2 = "L";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "J";
		subject.ImplantStatusCode = "Q";
		subject.Date = "oUFKz9";
		subject.Date2 = "iyYNDb";
		subject.ReferenceIdentification = "4";
		subject.ReferenceIdentification3 = "s";
		subject.YesNoConditionOrResponseCode = "o";
		subject.YesNoConditionOrResponseCode2 = "L";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredReferenceIdentification3(string referenceIdentification3, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "J";
		subject.ImplantStatusCode = "Q";
		subject.Date = "oUFKz9";
		subject.Date2 = "iyYNDb";
		subject.ReferenceIdentification = "4";
		subject.ReferenceIdentification2 = "5";
		subject.YesNoConditionOrResponseCode = "o";
		subject.YesNoConditionOrResponseCode2 = "L";
		//Test Parameters
		subject.ReferenceIdentification3 = referenceIdentification3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "J";
		subject.ImplantStatusCode = "Q";
		subject.Date = "oUFKz9";
		subject.Date2 = "iyYNDb";
		subject.ReferenceIdentification = "4";
		subject.ReferenceIdentification2 = "5";
		subject.ReferenceIdentification3 = "s";
		subject.YesNoConditionOrResponseCode2 = "L";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode2(string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "J";
		subject.ImplantStatusCode = "Q";
		subject.Date = "oUFKz9";
		subject.Date2 = "iyYNDb";
		subject.ReferenceIdentification = "4";
		subject.ReferenceIdentification2 = "5";
		subject.ReferenceIdentification3 = "s";
		subject.YesNoConditionOrResponseCode = "o";
		//Test Parameters
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
