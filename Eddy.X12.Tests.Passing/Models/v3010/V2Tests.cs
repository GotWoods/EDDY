using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class V2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V2*S295BC*22*ipVy7D*3yWmOI*dZ";

		var expected = new V2_VesselInformation()
		{
			StandardPointLocationCode = "S295BC",
			NetTonnage = 22,
			StandardPointLocationCode2 = "ipVy7D",
			RegistryDate = "3yWmOI",
			Master = "dZ",
		};

		var actual = Map.MapObject<V2_VesselInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S295BC", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		subject.NetTonnage = 22;
		subject.StandardPointLocationCode2 = "ipVy7D";
		subject.RegistryDate = "3yWmOI";
		subject.Master = "dZ";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(22, true)]
	public void Validation_RequiredNetTonnage(int netTonnage, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		subject.StandardPointLocationCode = "S295BC";
		subject.StandardPointLocationCode2 = "ipVy7D";
		subject.RegistryDate = "3yWmOI";
		subject.Master = "dZ";
		if (netTonnage > 0)
			subject.NetTonnage = netTonnage;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ipVy7D", true)]
	public void Validation_RequiredStandardPointLocationCode2(string standardPointLocationCode2, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		subject.StandardPointLocationCode = "S295BC";
		subject.NetTonnage = 22;
		subject.RegistryDate = "3yWmOI";
		subject.Master = "dZ";
		subject.StandardPointLocationCode2 = standardPointLocationCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3yWmOI", true)]
	public void Validation_RequiredRegistryDate(string registryDate, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		subject.StandardPointLocationCode = "S295BC";
		subject.NetTonnage = 22;
		subject.StandardPointLocationCode2 = "ipVy7D";
		subject.Master = "dZ";
		subject.RegistryDate = registryDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dZ", true)]
	public void Validation_RequiredMaster(string master, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		subject.StandardPointLocationCode = "S295BC";
		subject.NetTonnage = 22;
		subject.StandardPointLocationCode2 = "ipVy7D";
		subject.RegistryDate = "3yWmOI";
		subject.Master = master;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
