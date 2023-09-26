using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PC*QP*c*dE*d*v";

		var expected = new PC_ProcedureCodes()
		{
			ProductServiceIDQualifier = "QP",
			MedicalCodeValue = "c",
			DateTimePeriodFormatQualifier = "dE",
			DateTimePeriod = "d",
			Description = "v",
		};

		var actual = Map.MapObject<PC_ProcedureCodes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QP", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new PC_ProcedureCodes();
		//Required fields
		subject.MedicalCodeValue = "c";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "dE";
			subject.DateTimePeriod = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredMedicalCodeValue(string medicalCodeValue, bool isValidExpected)
	{
		var subject = new PC_ProcedureCodes();
		//Required fields
		subject.ProductServiceIDQualifier = "QP";
		//Test Parameters
		subject.MedicalCodeValue = medicalCodeValue;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "dE";
			subject.DateTimePeriod = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("dE", "d", true)]
	[InlineData("dE", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PC_ProcedureCodes();
		//Required fields
		subject.ProductServiceIDQualifier = "QP";
		subject.MedicalCodeValue = "c";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
