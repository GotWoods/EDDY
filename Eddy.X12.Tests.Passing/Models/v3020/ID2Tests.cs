using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class ID2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID2*k*L*hC*H*8*D*RT*f";

		var expected = new ID2_ItemImageDetail()
		{
			CashRegisterItemDescription = "k",
			CashRegisterItemDescription2 = "L",
			SpaceManagementReferenceCode = "hC",
			ReferenceNumber = "H",
			Name = "8",
			Name2 = "D",
			SpaceManagementReferenceCode2 = "RT",
			ReferenceNumber2 = "f",
		};

		var actual = Map.MapObject<ID2_ItemImageDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hC", "H", true)]
	[InlineData("hC", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredSpaceManagementReferenceCode(string spaceManagementReferenceCode, string referenceNumber, bool isValidExpected)
	{
		var subject = new ID2_ItemImageDetail();
		subject.SpaceManagementReferenceCode = spaceManagementReferenceCode;
		subject.ReferenceNumber = referenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.SpaceManagementReferenceCode2) || !string.IsNullOrEmpty(subject.SpaceManagementReferenceCode2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.SpaceManagementReferenceCode2 = "RT";
			subject.ReferenceNumber2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("RT", "f", true)]
	[InlineData("RT", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredSpaceManagementReferenceCode2(string spaceManagementReferenceCode2, string referenceNumber2, bool isValidExpected)
	{
		var subject = new ID2_ItemImageDetail();
		subject.SpaceManagementReferenceCode2 = spaceManagementReferenceCode2;
		subject.ReferenceNumber2 = referenceNumber2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.SpaceManagementReferenceCode) || !string.IsNullOrEmpty(subject.SpaceManagementReferenceCode) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.SpaceManagementReferenceCode = "hC";
			subject.ReferenceNumber = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
