using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class RCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RC*QL*l*q*vB*m*W*F*M*F";

		var expected = new RC_RootCause()
		{
			ProductServiceIDQualifier = "QL",
			ProductServiceID = "l",
			Name = "q",
			AgencyQualifierCode = "vB",
			SourceSubqualifier = "m",
			CasualPartConditionCode = "W",
			Description = "F",
			FreeFormMessageText = "M",
			YesNoConditionOrResponseCode = "F",
		};

		var actual = Map.MapObject<RC_RootCause>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("QL", "l", true)]
	[InlineData("QL", "", false)]
	[InlineData("", "l", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.CasualPartConditionCode = "W";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vB", "W", true)]
	[InlineData("vB", "", false)]
	[InlineData("", "W", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string casualPartConditionCode, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.CasualPartConditionCode = casualPartConditionCode;
		//At Least one
		subject.Description = "F";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "QL";
			subject.ProductServiceID = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m", "vB", true)]
	[InlineData("m", "", false)]
	[InlineData("", "vB", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.CasualPartConditionCode = "W";
		//At Least one
		subject.CasualPartConditionCode = "W";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "QL";
			subject.ProductServiceID = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("W", "F", true)]
	[InlineData("W", "", true)]
	[InlineData("", "F", true)]
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
			subject.ProductServiceIDQualifier = "QL";
			subject.ProductServiceID = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
