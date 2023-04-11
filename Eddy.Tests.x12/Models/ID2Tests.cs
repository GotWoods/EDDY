using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ID2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID2*S*m*GP*v*S*K*xn*A";

		var expected = new ID2_ItemImageDetail()
		{
			CashRegisterItemDescription = "S",
			CashRegisterItemDescription2 = "m",
			SpaceManagementReferenceCode = "GP",
			ReferenceIdentification = "v",
			Name = "S",
			Name2 = "K",
			SpaceManagementReferenceCode2 = "xn",
			ReferenceIdentification2 = "A",
		};

		var actual = Map.MapObject<ID2_ItemImageDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("GP", "v", true)]
	[InlineData("", "v", false)]
	[InlineData("GP", "", false)]
	public void Validation_AllAreRequiredSpaceManagementReferenceCode(string spaceManagementReferenceCode, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ID2_ItemImageDetail();
		subject.SpaceManagementReferenceCode = spaceManagementReferenceCode;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("xn", "A", true)]
	[InlineData("", "A", false)]
	[InlineData("xn", "", false)]
	public void Validation_AllAreRequiredSpaceManagementReferenceCode2(string spaceManagementReferenceCode2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new ID2_ItemImageDetail();
		subject.SpaceManagementReferenceCode2 = spaceManagementReferenceCode2;
		subject.ReferenceIdentification2 = referenceIdentification2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
