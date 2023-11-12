using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class FX5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FX5*r*Cr2*XC*O*em*E*H";

		var expected = new FX5_ServicesInformation()
		{
			YesNoConditionOrResponseCode = "r",
			MaintenanceTypeCode = "Cr2",
			ProductServiceIDQualifier = "XC",
			ProductServiceID = "O",
			ProductServiceIDQualifier2 = "em",
			ProductServiceID2 = "E",
			Description = "H",
		};

		var actual = Map.MapObject<FX5_ServicesInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new FX5_ServicesInformation();
		//Required fields
		subject.MaintenanceTypeCode = "Cr2";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//At Least one
		subject.ProductServiceIDQualifier = "XC";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "XC";
			subject.ProductServiceID = "O";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "em";
			subject.ProductServiceID2 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Cr2", true)]
	public void Validation_RequiredMaintenanceTypeCode(string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new FX5_ServicesInformation();
		//Required fields
		subject.YesNoConditionOrResponseCode = "r";
		//Test Parameters
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		//At Least one
		subject.ProductServiceIDQualifier = "XC";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "XC";
			subject.ProductServiceID = "O";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "em";
			subject.ProductServiceID2 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("XC", "O", true)]
	[InlineData("XC", "", false)]
	[InlineData("", "O", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new FX5_ServicesInformation();
		//Required fields
		subject.YesNoConditionOrResponseCode = "r";
		subject.MaintenanceTypeCode = "Cr2";
        subject.Description = "AB";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "em";
			subject.ProductServiceID2 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("XC", "H", true)]
	[InlineData("XC", "", true)]
	[InlineData("", "H", true)]
	public void Validation_AtLeastOneProductServiceIDQualifier(string productServiceIDQualifier, string description, bool isValidExpected)
	{
		var subject = new FX5_ServicesInformation();
		//Required fields
		subject.YesNoConditionOrResponseCode = "r";
		subject.MaintenanceTypeCode = "Cr2";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "em";
			subject.ProductServiceID2 = "E";
		}

        if (subject.ProductServiceIDQualifier != "")
            subject.ProductServiceID = "E";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("em", "E", true)]
	[InlineData("em", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new FX5_ServicesInformation();
		//Required fields
		subject.YesNoConditionOrResponseCode = "r";
		subject.MaintenanceTypeCode = "Cr2";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//At Least one
		subject.ProductServiceIDQualifier = "XC";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "XC";
			subject.ProductServiceID = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
