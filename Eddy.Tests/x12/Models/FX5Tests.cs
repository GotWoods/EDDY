using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FX5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FX5*M*ijC*ci*J*0M*Z*v";

		var expected = new FX5_ServicesInformation()
		{
			YesNoConditionOrResponseCode = "M",
			MaintenanceTypeCode = "ijC",
			ProductServiceIDQualifier = "ci",
			ProductServiceID = "J",
			ProductServiceIDQualifier2 = "0M",
			ProductServiceID2 = "Z",
			Description = "v",
		};

		var actual = Map.MapObject<FX5_ServicesInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new FX5_ServicesInformation();
		subject.MaintenanceTypeCode = "ijC";
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ijC", true)]
	public void Validation_RequiredMaintenanceTypeCode(string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new FX5_ServicesInformation();
		subject.YesNoConditionOrResponseCode = "M";
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("ci", "J", true)]
	[InlineData("", "J", false)]
	[InlineData("ci", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new FX5_ServicesInformation();
		subject.YesNoConditionOrResponseCode = "M";
		subject.MaintenanceTypeCode = "ijC";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("ci","v", true)]
	[InlineData("", "v", true)]
	[InlineData("ci", "", true)]
	public void Validation_AtLeastOneProductServiceIDQualifier(string productServiceIDQualifier, string description, bool isValidExpected)
	{
		var subject = new FX5_ServicesInformation();
		subject.YesNoConditionOrResponseCode = "M";
		subject.MaintenanceTypeCode = "ijC";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("0M", "Z", true)]
	[InlineData("", "Z", false)]
	[InlineData("0M", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new FX5_ServicesInformation();
		subject.YesNoConditionOrResponseCode = "M";
		subject.MaintenanceTypeCode = "ijC";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
