using System;
using System.Collections.Generic;
using Integration.Salesforce.Library.Models;
using Xunit;

namespace Integration.Salesforce.Testing.Library.ModelTests
{
  public class HousingToStringTests
  {
    ModelData md = new ModelData();

    [Fact]
    public void HousingComplex_ReturnsValidString_True()
    {
      // assemble
      HousingComplex complex = md.HousingComplex();
      Address location = md.Location();
      Person contact = md.HousingContact();
      List<HousingUnit> _housingUnitList = md.HousingUnits();
      // act
      var response = complex.ToString();
      var unitListString = $"UNITS{{";
      var teststring = $"COMPLEX{{ComplexName:{complex.HousingComplexName};TransitOptions:{complex.TransitOptions};}}";
      teststring += contact.ToString();
      teststring += location.ToString();
      foreach(var unit in _housingUnitList)
      {
        unitListString += unit.ToString();
      }
      unitListString += "}}";
      // assemble
      Assert.NotNull(response);
      Assert.Equal(teststring, response, true);
    }
  }
}