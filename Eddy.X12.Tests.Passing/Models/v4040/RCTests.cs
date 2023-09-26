using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class RCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RC*RC*l*5*WU*O*G*7*H*R";

		var expected = new RC_RootCause()
		{
			ProductServiceIDQualifier = "RC",
			ProductServiceID = "l",
			Name = "5",
			AgencyQualifierCode = "WU",
			SourceSubqualifier = "O",
			CausalPartConditionCode = "G",
			Description = "7",
			FreeFormMessageText = "H",
			YesNoConditionOrResponseCode = "R",
		};

		var actual = Map.MapObject<RC_RootCause>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("RC", "l", true)]
	[InlineData("RC", "", false)]
	[InlineData("", "l", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.CausalPartConditionCode = "G";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("WU", "G", true)]
	[InlineData("WU", "", false)]
	[InlineData("", "G", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string causalPartConditionCode, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.CausalPartConditionCode = causalPartConditionCode;
		//At Least one
		subject.Description = "7";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "RC";
			subject.ProductServiceID = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O", "WU", true)]
	[InlineData("O", "", false)]
	[InlineData("", "WU", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.CausalPartConditionCode = "G";
		//At Least one
		subject.CausalPartConditionCode = "G";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "RC";
			subject.ProductServiceID = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("G", "7", true)]
	[InlineData("G", "", true)]
	[InlineData("", "7", true)]
	public void Validation_AtLeastOneCausalPartConditionCode(string causalPartConditionCode, string description, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		//Required fields
		//Test Parameters
		subject.CausalPartConditionCode = causalPartConditionCode;
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "RC";
			subject.ProductServiceID = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
