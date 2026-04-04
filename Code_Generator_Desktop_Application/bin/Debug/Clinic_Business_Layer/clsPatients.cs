using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using _Data_Layer;
namespace _Business_Layer 
{
	public class clsPatients
{
		public enum enMode { AddNew = 0, Update = 1 };
public enMode Mode = enMode.AddNew;

		public clsPatients()
{
	Mode = enMode.AddNew;
}
private clsPatients()
{
	Mode = enMode.Update;
}

		public static clsPatients Find()
{
	
	bool IsFound = clsPatientsData.GetPatientsInfoByID(, );
	if(IsFound)
	{
		return new clsPatients();
	}
	else
	{
		return null;
	}
}

		private bool _AddNewPatients()
{
this. = clsPatientsData.AddNewPatients();
return (this. != null);
}

		private bool _UpdatePatients()
{
return clsPatientsData.UpdatePatientsInfoByID();}

		public bool Save()
{
	switch (Mode)
	{
		case enMode.AddNew:
			if(_AddNewPatients())
		{
			Mode = enMode.Update;
			return true;
		}
		else
		{
			return false;
		}
		case enMode.Update:
			return _UpdatePatients();
	}
	return false;
}

		public static bool DeletePatients()
{
	return clsPatientsData.DeletePatientsByID();
}

		public static DataTable GetAllPatients()
{
	return clsPatientsData.GetAllPatients();
}

	}
}
