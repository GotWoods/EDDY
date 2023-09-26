using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class FU5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FU5*qJ*C*ny*y*qL*P*ey*o*y*w*Z*D9*t";

		var expected = new FU5_CoProductInformation()
		{
			CoProductTypeCode = "qJ",
			ProductName = "C",
			ProductServiceIDQualifier = "ny",
			ProductServiceID = "y",
			ProductServiceIDQualifier2 = "qL",
			ProductServiceID2 = "P",
			ProductServiceIDQualifier3 = "ey",
			ProductServiceID3 = "o",
			BrandName = "y",
			ProductLabel = "w",
			Description = "Z",
			EntityIdentifierCode = "D9",
			Name = "t",
		};

		var actual = Map.MapObject<FU5_CoProductInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qJ", true)]
	public void Validation_RequiredCoProductTypeCode(string coProductTypeCode, bool isValidExpected)
	{
		var subject = new FU5_CoProductInformation();
		//Required fields
		subject.ProductName = "C";
		//Test Parameters
		subject.CoProductTypeCode = coProductTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "ny";
			subject.ProductServiceID = "y";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "qL";
			subject.ProductServiceID2 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ey";
			subject.ProductServiceID3 = "o";
		}
		if(!string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.Name))
		{
			subject.EntityIdentifierCode = "D9";
			subject.Name = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredProductName(string productName, bool isValidExpected)
	{
		var subject = new FU5_CoProductInformation();
		//Required fields
		subject.CoProductTypeCode = "qJ";
		//Test Parameters
		subject.ProductName = productName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "ny";
			subject.ProductServiceID = "y";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "qL";
			subject.ProductServiceID2 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ey";
			subject.ProductServiceID3 = "o";
		}
		if(!string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.Name))
		{
			subject.EntityIdentifierCode = "D9";
			subject.Name = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ny", "y", true)]
	[InlineData("ny", "", false)]
	[InlineData("", "y", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new FU5_CoProductInformation();
		//Required fields
		subject.CoProductTypeCode = "qJ";
		subject.ProductName = "C";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "qL";
			subject.ProductServiceID2 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ey";
			subject.ProductServiceID3 = "o";
		}
		if(!string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.Name))
		{
			subject.EntityIdentifierCode = "D9";
			subject.Name = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qL", "P", true)]
	[InlineData("qL", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new FU5_CoProductInformation();
		//Required fields
		subject.CoProductTypeCode = "qJ";
		subject.ProductName = "C";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "ny";
			subject.ProductServiceID = "y";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ey";
			subject.ProductServiceID3 = "o";
		}
		if(!string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.Name))
		{
			subject.EntityIdentifierCode = "D9";
			subject.Name = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ey", "o", true)]
	[InlineData("ey", "", false)]
	[InlineData("", "o", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new FU5_CoProductInformation();
		//Required fields
		subject.CoProductTypeCode = "qJ";
		subject.ProductName = "C";
		//Test Parameters
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "ny";
			subject.ProductServiceID = "y";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "qL";
			subject.ProductServiceID2 = "P";
		}
		if(!string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.Name))
		{
			subject.EntityIdentifierCode = "D9";
			subject.Name = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D9", "t", true)]
	[InlineData("D9", "", false)]
	[InlineData("", "t", false)]
	public void Validation_AllAreRequiredEntityIdentifierCode(string entityIdentifierCode, string name, bool isValidExpected)
	{
		var subject = new FU5_CoProductInformation();
		//Required fields
		subject.CoProductTypeCode = "qJ";
		subject.ProductName = "C";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		subject.Name = name;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "ny";
			subject.ProductServiceID = "y";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "qL";
			subject.ProductServiceID2 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ey";
			subject.ProductServiceID3 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
