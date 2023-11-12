using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CR8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR8*W*N*fMzbaP*uEg25a*G*D*e*j*s";

		var expected = new CR8_PacemakerCertification()
		{
			ImplantTypeCode = "W",
			ImplantStatusCode = "N",
			Date = "fMzbaP",
			Date2 = "uEg25a",
			ReferenceNumber = "G",
			ReferenceNumber2 = "D",
			ReferenceNumber3 = "e",
			YesNoConditionOrResponseCode = "j",
			YesNoConditionOrResponseCode2 = "s",
		};

		var actual = Map.MapObject<CR8_PacemakerCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredImplantTypeCode(string implantTypeCode, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantStatusCode = "N";
		subject.Date = "fMzbaP";
		subject.Date2 = "uEg25a";
		subject.ReferenceNumber = "G";
		subject.ReferenceNumber2 = "D";
		subject.ReferenceNumber3 = "e";
		subject.YesNoConditionOrResponseCode = "j";
		subject.YesNoConditionOrResponseCode2 = "s";
		//Test Parameters
		subject.ImplantTypeCode = implantTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredImplantStatusCode(string implantStatusCode, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "W";
		subject.Date = "fMzbaP";
		subject.Date2 = "uEg25a";
		subject.ReferenceNumber = "G";
		subject.ReferenceNumber2 = "D";
		subject.ReferenceNumber3 = "e";
		subject.YesNoConditionOrResponseCode = "j";
		subject.YesNoConditionOrResponseCode2 = "s";
		//Test Parameters
		subject.ImplantStatusCode = implantStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fMzbaP", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "W";
		subject.ImplantStatusCode = "N";
		subject.Date2 = "uEg25a";
		subject.ReferenceNumber = "G";
		subject.ReferenceNumber2 = "D";
		subject.ReferenceNumber3 = "e";
		subject.YesNoConditionOrResponseCode = "j";
		subject.YesNoConditionOrResponseCode2 = "s";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uEg25a", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "W";
		subject.ImplantStatusCode = "N";
		subject.Date = "fMzbaP";
		subject.ReferenceNumber = "G";
		subject.ReferenceNumber2 = "D";
		subject.ReferenceNumber3 = "e";
		subject.YesNoConditionOrResponseCode = "j";
		subject.YesNoConditionOrResponseCode2 = "s";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "W";
		subject.ImplantStatusCode = "N";
		subject.Date = "fMzbaP";
		subject.Date2 = "uEg25a";
		subject.ReferenceNumber2 = "D";
		subject.ReferenceNumber3 = "e";
		subject.YesNoConditionOrResponseCode = "j";
		subject.YesNoConditionOrResponseCode2 = "s";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "W";
		subject.ImplantStatusCode = "N";
		subject.Date = "fMzbaP";
		subject.Date2 = "uEg25a";
		subject.ReferenceNumber = "G";
		subject.ReferenceNumber3 = "e";
		subject.YesNoConditionOrResponseCode = "j";
		subject.YesNoConditionOrResponseCode2 = "s";
		//Test Parameters
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredReferenceNumber3(string referenceNumber3, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "W";
		subject.ImplantStatusCode = "N";
		subject.Date = "fMzbaP";
		subject.Date2 = "uEg25a";
		subject.ReferenceNumber = "G";
		subject.ReferenceNumber2 = "D";
		subject.YesNoConditionOrResponseCode = "j";
		subject.YesNoConditionOrResponseCode2 = "s";
		//Test Parameters
		subject.ReferenceNumber3 = referenceNumber3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "W";
		subject.ImplantStatusCode = "N";
		subject.Date = "fMzbaP";
		subject.Date2 = "uEg25a";
		subject.ReferenceNumber = "G";
		subject.ReferenceNumber2 = "D";
		subject.ReferenceNumber3 = "e";
		subject.YesNoConditionOrResponseCode2 = "s";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode2(string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new CR8_PacemakerCertification();
		//Required fields
		subject.ImplantTypeCode = "W";
		subject.ImplantStatusCode = "N";
		subject.Date = "fMzbaP";
		subject.Date2 = "uEg25a";
		subject.ReferenceNumber = "G";
		subject.ReferenceNumber2 = "D";
		subject.ReferenceNumber3 = "e";
		subject.YesNoConditionOrResponseCode = "j";
		//Test Parameters
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
