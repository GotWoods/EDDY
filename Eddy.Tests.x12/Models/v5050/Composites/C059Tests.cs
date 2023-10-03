using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v5050;
using Eddy.x12.Models.v5050.Composites;

namespace Eddy.x12.Tests.Models.v5050.Composites;

public class C059Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "xx*MA*gt";

		var expected = new C059_DrugUseReviewDUR()
		{
			ReasonForServiceCode = "xx",
			ProfessionalServiceCode = "MA",
			ResultOfServiceCode = "gt",
		};

		var actual = Map.MapObject<C059_DrugUseReviewDUR>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xx", true)]
	public void Validation_RequiredReasonForServiceCode(string reasonForServiceCode, bool isValidExpected)
	{
		var subject = new C059_DrugUseReviewDUR();
		//Required fields
		subject.ProfessionalServiceCode = "MA";
		subject.ResultOfServiceCode = "gt";
		//Test Parameters
		subject.ReasonForServiceCode = reasonForServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MA", true)]
	public void Validation_RequiredProfessionalServiceCode(string professionalServiceCode, bool isValidExpected)
	{
		var subject = new C059_DrugUseReviewDUR();
		//Required fields
		subject.ReasonForServiceCode = "xx";
		subject.ResultOfServiceCode = "gt";
		//Test Parameters
		subject.ProfessionalServiceCode = professionalServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gt", true)]
	public void Validation_RequiredResultOfServiceCode(string resultOfServiceCode, bool isValidExpected)
	{
		var subject = new C059_DrugUseReviewDUR();
		//Required fields
		subject.ReasonForServiceCode = "xx";
		subject.ProfessionalServiceCode = "MA";
		//Test Parameters
		subject.ResultOfServiceCode = resultOfServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
