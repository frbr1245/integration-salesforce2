using System;
using System.Collections.Generic;
using Integration.Salesforce.Library.Models;

namespace Integration.Salesforce.Testing.Library.ModelTests
{
  public class ModelData
  {
    public Batch Batch()
    {
      Batch batch = new Batch();
      batch.Name = "batch1";
      batch.SkillType = "Java";
      batch.StartDate = DateTime.Parse("2018-05-01");
      batch.EndDate = DateTime.Parse("2018-06-01");
      batch.Trainer = Trainer();
      batch.Location = Location();

      return batch;
    }
    
     public Person Trainer()
    {
      Person trainer = new Person();
      trainer.FirstName = "Fred";
      trainer.LastName = "Belotte";
      trainer.Phone = "1231231234";
      trainer.Role = "Trainer";
      trainer.Address = Location();
      trainer.EMail = EMail();

      return trainer;
    }

    public Address Location()
    {
      Address location = new Address();
      location.StreetAddress = "123 S 1st st";
      location.City = "Tampa";
      location.State = "FL";
      location.Zip = 33617;

      return location;
    }

    public EMail EMail()
    {
      EMail email = new EMail();
      email.cEMail = "fakeemail@fakeemail.com";

      return email;
    }

    public HousingComplex HousingComplex()
    {
      //done
      HousingComplex complex = new HousingComplex();
      complex.HousingComplexName = "complex1";
      complex.Location = Location();
      complex.HousingContact = HousingContact();
      complex.TransitOptions = "Car/Carpool";
      complex.HousingUnits = HousingUnits();

      return complex;
    }

    //done
    public Person HousingContact()
    {
      Person contact = new Person();
      contact.FirstName = "Fred";
      contact.LastName = "Belotte";
      contact.Phone = "1231231234";
      contact.Role = "Trainer";
      contact.HasCar = true;
      contact.Address = Location();
      contact.EMail = EMail();
      contact.BatchName = "batch1";

      return contact;
    }

    public HousingUnit HousingUnit()
    {
      HousingUnit hUnit = new HousingUnit();
      hUnit.ComplexName = "complex1";
      hUnit.UnitNumber = 1001;
      hUnit.InUse = true;
      hUnit.LeaseStartDate = DateTime.Parse("01/05/2018");
      hUnit.LeaseEndDate = DateTime.Parse("01/06/2018");
      hUnit.UnitGender = "Male";
      hUnit.UnitAmenities = Amenities();
      hUnit.NumberOfBeds = NumberOfBeds();

      return hUnit;
    }

    //done
    public List<HousingUnit> HousingUnits()
    {
      List<HousingUnit> _hUnitList = new List<HousingUnit>();
      HousingUnit housingUnit = HousingUnit();
      housingUnit.UnitNumber = 1001;
      _hUnitList.Add(housingUnit);
      HousingUnit housingUnit2 = HousingUnit();
      housingUnit2.InUse = false;
      housingUnit2.UnitNumber = 1002;
      _hUnitList.Add(housingUnit2);
      HousingUnit HousingUnit3 = HousingUnit();
      HousingUnit3.UnitNumber = 1003;
      HousingUnit3.UnitGender = "Female";
      HousingUnit3.InUse = true;
      _hUnitList.Add(HousingUnit3);

      return _hUnitList;
    }

    public List<string> Amenities()
    {
      List<string> _amenities = new List<string>();
      _amenities.Add("amenity1");
      _amenities.Add("amenity2");
      _amenities.Add("amenity3");

      return _amenities;
    }

    public HousingUnitBed HousingUnitBed()
    {
      HousingUnitBed unitBed = new HousingUnitBed();
      unitBed.UnitNumber = 1002;
      unitBed.HousingBedName = "bed1";
      unitBed.OccupancyStatus = "Moved-In";

      return unitBed;
    }

    public List<HousingUnitBed> NumberOfBeds()
    {
      List<HousingUnitBed> _bedList = new List<HousingUnitBed>();
      HousingUnitBed bed1 = HousingUnitBed();
      _bedList.Add(bed1);
      HousingUnitBed bed2 = HousingUnitBed();
      bed2.HousingBedName = "bed2";
      _bedList.Add(bed2);
      HousingUnitBed bed3 = HousingUnitBed();
      bed2.HousingBedName = "bed3";
      _bedList.Add(bed3);
      HousingUnitBed bed4 = HousingUnitBed();
      bed2.HousingBedName = "bed4";
      _bedList.Add(bed4);
      HousingUnitBed bed5 = HousingUnitBed();
      bed2.HousingBedName = "bed5";
      _bedList.Add(bed5);
      HousingUnitBed bed6 = HousingUnitBed();
      bed2.HousingBedName = "bed6";
      _bedList.Add(bed6);

      return _bedList;
    }
  } 
}