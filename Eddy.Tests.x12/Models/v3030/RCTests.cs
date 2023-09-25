using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class RCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RC*dJ*1*N*ex*k*J*j*F*F";

		var expected = new RC_RootCause()
		{
			ProductServiceIDQualifier = "dJ",
			ProductServiceID = "1",
			Name = "N",
			AgencyQualifierCode = "ex",
			SourceSubqualifier = "k",
			CasualPartConditionCode = "J",
			Description = "j",
			FreeFormMessageText = "F",
			YesNoConditionOrResponseCode = "F",
		};

		var actual = Map.MapObject<RC_RootCause>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("dJ", "1", true)]
	[InlineData("dJ", "", false)]
	[InlineData("", "1", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.CasualPartConditionCode = "J";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ex", "J", true)]
	[InlineData("ex", "", false)]
	[InlineData("", "J", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string casualPartConditionCode, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.CasualPartConditionCode = casualPartConditionCode;
		//At Least one
		subject.Description = "j";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "dJ";
			subject.ProductServiceID = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("k", "ex", true)]
	[InlineData("k", "", false)]
	[InlineData("", "ex", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.CasualPartConditionCode = "J";
		//At Least one
		subject.CasualPartConditionCode = "J";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "dJ";
			subject.ProductServiceID = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("J", "j", true)]
	[InlineData("J", "", true)]
	[InlineData("", "j", true)]
	public void Validation_AtLeastOneCasualPartConditionCode(string casualPartConditionCode, string description, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		//Required fields
		//Test Parameters
		subject.CasualPartConditionCode = casualPartConditionCode;
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "dJ";
			subject.ProductServiceID = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
