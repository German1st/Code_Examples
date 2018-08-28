using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class FixtureBusinessLayer
    {
        public IEnumerable<Fixture> Fixtures
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["NYSQL02"].ConnectionString;
                List<Fixture> fixtures = new List<Fixture>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetFixtureList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Fixture f = new Fixture();

                        f.ID = Convert.ToInt32(rdr["ID"]);
                        f.FixtureNumber = rdr["FixtureNumber"].ToString();
                        f.VesselName = rdr["VesselName"].ToString();
                        f.IMO = rdr["IMO"].ToString();
                        f.Class = rdr["Class"].ToString();
                        f.Quantity = rdr["Quantity"].ToString();
                        f.UOM = rdr["UOM"].ToString();
                        f.CPDate = Convert.ToDateTime(rdr["CPDate"].ToString());
                        f.Department = rdr["Department"].ToString();
                        f.Entity = rdr["Entity"].ToString();
                        f.Desk = rdr["Desk"].ToString();
                        f.Cargo = rdr["Cargo"].ToString();
                        f.Class = rdr["Class"].ToString();
                        f.Notes = rdr["Notes"].ToString();
                        f.Office = rdr["Office"].ToString();

                        f.Owner = rdr["Owner"].ToString();
                        f.OwnerCustID = rdr["OwnerCustID"].ToString();
                        f.OwnerGroup = rdr["OwnerGroup"].ToString();
                        if (!(f.OwnerAddress == ""))
                        {
                            f.OwnerAddress = rdr["OwnerAddress"].ToString();
                        }
                        else
                        {
                            f.OwnerAddress = " ";
                        }
                        f.OwnerUniqueIDInDB = Int32.Parse(rdr["OwnerUniqueIDInDB"].ToString());
                        f.OwnerAddressUpdated = rdr["OwnerAddressUpdated"].ToString();

                        f.Charterer = rdr["Charterer"].ToString();
                        f.ChartererCustID = rdr["ChartererCustID"].ToString();
                        f.ChartererGroup = rdr["ChartererGroup"].ToString();
                        if (!(f.ChartererAddress == "")) 
                        { 
                            f.ChartererAddress = rdr["ChartererAddress"].ToString();
                        }
                        else
                        {
                            f.ChartererAddress = " ";
                        }
                        f.ChartererUniqueIDInDB = Int32.Parse(rdr["ChartererUniqueIDInDB"].ToString());
                        f.ChartererAddressUpdated = rdr["ChartererAddressUpdated"].ToString();

                        f.VoyageType = rdr["VoyageType"].ToString();
                        f.LoadPort = rdr["LoadPort"].ToString();
                        f.DischargePort = rdr["DischargePort"].ToString();
                        f.ThirdPartyBroker = rdr["ThirdPartyBroker"].ToString();
                        f.ThirdPartyBrokerID = rdr["ThirdPartyBrokerID"].ToString();

                        f.ThirdPartyPercentage = float.Parse(rdr["ThirdPartyPercentage"].ToString());

                        f.Rate1 = rdr["Rate1"].ToString();
                        f.Rate2 = rdr["Rate2"].ToString();

                        f.CreatedBy = rdr["CreatedBy"].ToString();
                        f.CreateDate = rdr["CreateDate"].ToString();
                        f.UpdateDate = rdr["UpdateDate"].ToString();
                        f.UpdatedBy = rdr["UpdatedBy"].ToString();
                        f.Status = rdr["Status"].ToString();
                        f.StartDate = rdr["StartDate"].ToString();
                        f.EndDate = rdr["EndDate"].ToString();
                        fixtures.Add(f);
                    }

                    return fixtures;
                }
            }
        }

        public void UpdateFixture(Fixture f)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NYSQL02"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateFixture", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramID = new SqlParameter();
                paramID.ParameterName = "@ID";
                paramID.Value = f.ID;
                cmd.Parameters.Add(paramID);

                SqlParameter paramDepartment = new SqlParameter();
                paramDepartment.ParameterName = "@Department";
                paramDepartment.Value = f.Department;
                cmd.Parameters.Add(paramDepartment);

                SqlParameter paramEntity = new SqlParameter();
                paramEntity.ParameterName = "@Entity";
                paramEntity.Value = f.Entity;
                cmd.Parameters.Add(paramEntity);

                SqlParameter paramFixtureNumber = new SqlParameter();
                paramFixtureNumber.ParameterName = "@FixtureNumber";
                paramFixtureNumber.Value = f.FixtureNumber;
                cmd.Parameters.Add(paramFixtureNumber);

                SqlParameter paramCPDate = new SqlParameter();
                paramCPDate.ParameterName = "@CPDate";
                paramCPDate.Value = f.CPDate;
                cmd.Parameters.Add(paramCPDate);

                SqlParameter paramVessel = new SqlParameter();
                paramVessel.ParameterName = "@VesselName";
                paramVessel.Value = f.VesselName;
                cmd.Parameters.Add(paramVessel);

                SqlParameter paramIMO = new SqlParameter();
                paramIMO.ParameterName = "@IMO";
                paramIMO.Value = f.IMO;
                cmd.Parameters.Add(paramIMO);

                SqlParameter paramClass = new SqlParameter();
                paramClass.ParameterName = "@Class";
                paramClass.Value = f.Class;
                cmd.Parameters.Add(paramClass);

                SqlParameter paramCharterer = new SqlParameter();
                paramCharterer.ParameterName = "@Charterer";
                paramCharterer.Value = f.Charterer;
                cmd.Parameters.Add(paramCharterer);

                SqlParameter paramChartererCustID = new SqlParameter();
                paramChartererCustID.ParameterName = "@ChartererCustID";
                paramChartererCustID.Value = f.ChartererCustID;
                cmd.Parameters.Add(paramChartererCustID);

                SqlParameter paramChartererGroup = new SqlParameter();
                paramChartererGroup.ParameterName = "@ChartererGroup";
                paramChartererGroup.Value = f.ChartererGroup;
                cmd.Parameters.Add(paramChartererGroup);

                SqlParameter paramChartererAddress = new SqlParameter();
                paramChartererAddress.ParameterName = "@ChartererAddress";
                paramChartererAddress.Value = f.ChartererAddress;
                cmd.Parameters.Add(paramChartererAddress);

                SqlParameter paramChartererUniqueIDInDB = new SqlParameter();
                paramChartererUniqueIDInDB.ParameterName = "@ChartererUniqueIDInDB";
                paramChartererUniqueIDInDB.Value = f.ChartererUniqueIDInDB;
                cmd.Parameters.Add(paramChartererUniqueIDInDB);

                SqlParameter paramChartererAddressUpdated = new SqlParameter();
                paramChartererAddressUpdated.ParameterName = "@ChartererAddressUpdated";
                paramChartererAddressUpdated.Value = f.ChartererAddressUpdated;
                cmd.Parameters.Add(paramChartererAddressUpdated);

                SqlParameter paramOwner = new SqlParameter();
                paramOwner.ParameterName = "@Owner";
                paramOwner.Value = f.Owner;
                cmd.Parameters.Add(paramOwner);

                SqlParameter paramOwnerCustID = new SqlParameter();
                paramOwnerCustID.ParameterName = "@OwnerCustID";
                paramOwnerCustID.Value = f.OwnerCustID;
                cmd.Parameters.Add(paramOwnerCustID);

                SqlParameter paramownerGroup = new SqlParameter();
                paramownerGroup.ParameterName = "@OwnerGroup";
                paramownerGroup.Value = f.OwnerGroup;
                cmd.Parameters.Add(paramownerGroup);

                SqlParameter paramOwnerAddress = new SqlParameter();
                paramOwnerAddress.ParameterName = "@OwnerAddress";
                paramOwnerAddress.Value = f.OwnerAddress;
                cmd.Parameters.Add(paramOwnerAddress);

                SqlParameter paramOwnerUniqueIDInDB = new SqlParameter();
                paramOwnerUniqueIDInDB.ParameterName = "@OwnerUniqueIDInDB";
                paramOwnerUniqueIDInDB.Value = f.OwnerUniqueIDInDB;
                cmd.Parameters.Add(paramOwnerUniqueIDInDB);

                SqlParameter paramOwnerAddressUpdated = new SqlParameter();
                paramOwnerAddressUpdated.ParameterName = "@OwnerAddressUpdated";
                paramOwnerAddressUpdated.Value = f.OwnerAddressUpdated;
                cmd.Parameters.Add(paramOwnerAddressUpdated);

                SqlParameter paramThirdPartyBroker = new SqlParameter();
                paramThirdPartyBroker.ParameterName = "@ThirdPartyBroker";
                paramThirdPartyBroker.Value = f.ThirdPartyBroker;
                cmd.Parameters.Add(paramThirdPartyBroker);

                SqlParameter paramThirdPartyBrokerID = new SqlParameter();
                paramThirdPartyBrokerID.ParameterName = "@ThirdPartyBrokerID";
                paramThirdPartyBrokerID.Value = f.ThirdPartyBrokerID;
                cmd.Parameters.Add(paramThirdPartyBrokerID);

                SqlParameter paramThirdPartyBrokerPercentage= new SqlParameter();
                paramThirdPartyBrokerPercentage.ParameterName = "@ThirdPartyBrokerPercentage";
                paramThirdPartyBrokerPercentage.Value = f.ThirdPartyPercentage;
                cmd.Parameters.Add(paramThirdPartyBrokerPercentage);

                SqlParameter paramCargo = new SqlParameter();
                paramCargo.ParameterName = "@Cargo";
                paramCargo.Value = f.Cargo;
                cmd.Parameters.Add(paramCargo);

                SqlParameter paramQuantity = new SqlParameter();
                paramQuantity.ParameterName = "@Quantity";
                paramQuantity.Value = f.Quantity;
                cmd.Parameters.Add(paramQuantity);

                SqlParameter paramUOM = new SqlParameter();
                paramUOM.ParameterName = "@UOM";
                paramUOM.Value = f.UOM;
                cmd.Parameters.Add(paramUOM);

                SqlParameter paramNotes = new SqlParameter();
                paramNotes.ParameterName = "@Notes";
                paramNotes.Value = f.Notes;
                cmd.Parameters.Add(paramNotes);

                SqlParameter paramDesk = new SqlParameter();
                paramDesk.ParameterName = "@Desk";
                paramDesk.Value = f.Desk;
                cmd.Parameters.Add(paramDesk);

                SqlParameter paramOffice = new SqlParameter();
                paramOffice.ParameterName = "@Office";
                paramOffice.Value = f.Office;
                cmd.Parameters.Add(paramOffice);

                SqlParameter paramCreatedBy = new SqlParameter();
                paramCreatedBy.ParameterName = "@CreatedBy";
                paramCreatedBy.Value = f.CreatedBy;
                cmd.Parameters.Add(paramCreatedBy);

                SqlParameter paramCreatedDate = new SqlParameter();
                paramCreatedDate.ParameterName = "@CreateDate";
                paramCreatedDate.Value = DateTime.Now.ToShortDateString();
                cmd.Parameters.Add(paramCreatedDate);

                SqlParameter paramUpdatedBy = new SqlParameter();
                paramUpdatedBy.ParameterName = "@UpdatedBy";
                paramUpdatedBy.Value = f.UpdatedBy;
                cmd.Parameters.Add(paramUpdatedBy);

                SqlParameter paramUpdateDate = new SqlParameter();
                paramUpdateDate.ParameterName = "@UpdateDate";
                paramUpdateDate.Value = DateTime.Now.ToShortDateString();
                cmd.Parameters.Add(paramUpdateDate);

                SqlParameter paramVoyageType = new SqlParameter();
                paramVoyageType.ParameterName = "@VoyageType";
                paramVoyageType.Value = f.VoyageType;
                cmd.Parameters.Add(paramVoyageType);

                SqlParameter paramLoadPort = new SqlParameter();
                paramLoadPort.ParameterName = "@LoadPort";
                paramLoadPort.Value = f.LoadPort;
                cmd.Parameters.Add(paramLoadPort);

                SqlParameter paramDischargePort = new SqlParameter();
                paramDischargePort.ParameterName = "@DischargePort";
                paramDischargePort.Value = f.DischargePort;
                cmd.Parameters.Add(paramDischargePort);

                SqlParameter paramRate1= new SqlParameter();
                paramRate1.ParameterName = "@Rate1";
                paramRate1.Value = f.Rate1;
                cmd.Parameters.Add(paramRate1);

                SqlParameter paramRate2 = new SqlParameter();
                paramRate2.ParameterName = "@Rate2";
                paramRate2.Value = f.Rate2;
                cmd.Parameters.Add(paramRate2);

                SqlParameter paramStatus = new SqlParameter();
                paramStatus.ParameterName = "@Status";
                paramStatus.Value = f.Status;
                cmd.Parameters.Add(paramStatus);

                SqlParameter paramStartDate = new SqlParameter();
                paramStartDate.ParameterName = "@StartDate";
                paramStartDate.Value = f.StartDate;
                cmd.Parameters.Add(paramStartDate);

                SqlParameter paramEndDate = new SqlParameter();
                paramEndDate.ParameterName = "@EndDate";
                paramEndDate.Value = f.EndDate;
                cmd.Parameters.Add(paramEndDate);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void update(Fixture f)
        { 
}
        public void AddFixture(Fixture f)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NYSQL02"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddFixture", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramDepartment = new SqlParameter();
                paramDepartment.ParameterName = "@Department";
                paramDepartment.Value = f.Department;
                cmd.Parameters.Add(paramDepartment);

                SqlParameter paramEntity = new SqlParameter();
                paramEntity.ParameterName = "@Entity";
                paramEntity.Value = f.Entity;
                cmd.Parameters.Add(paramEntity);

                SqlParameter paramFixtureNumber = new SqlParameter();
                paramFixtureNumber.ParameterName = "@FixtureNumber";
                paramFixtureNumber.Value = f.FixtureNumber;
                cmd.Parameters.Add(paramFixtureNumber);

                SqlParameter paramCPDate = new SqlParameter();
                paramCPDate.ParameterName = "@CPDate";
                paramCPDate.Value = f.CPDate;
                cmd.Parameters.Add(paramCPDate);

                SqlParameter paramVessel = new SqlParameter();
                paramVessel.ParameterName = "@VesselName";
                paramVessel.Value = f.VesselName;
                cmd.Parameters.Add(paramVessel);

                SqlParameter paramIMO = new SqlParameter();
                paramIMO.ParameterName = "@IMO";
                paramIMO.Value = f.IMO;
                cmd.Parameters.Add(paramIMO);

                SqlParameter paramClass = new SqlParameter();
                paramClass.ParameterName = "@Class";
                paramClass.Value = f.Class;
                cmd.Parameters.Add(paramClass);

                SqlParameter paramCharterer = new SqlParameter();
                paramCharterer.ParameterName = "@Charterer";
                paramCharterer.Value = f.Charterer;
                cmd.Parameters.Add(paramCharterer);

                SqlParameter paramChartererCustID = new SqlParameter();
                paramChartererCustID.ParameterName = "@ChartererCustID";
                paramChartererCustID.Value = f.ChartererCustID;
                cmd.Parameters.Add(paramChartererCustID);

                SqlParameter paramChartererGroup = new SqlParameter();
                paramChartererGroup.ParameterName = "@ChartererGroup";
                paramChartererGroup.Value = f.ChartererGroup;
                cmd.Parameters.Add(paramChartererGroup);

                SqlParameter paramChartererAddress = new SqlParameter();
                paramChartererAddress.ParameterName = "@ChartererAddress";
                paramChartererAddress.Value = f.ChartererAddress;
                cmd.Parameters.Add(paramChartererAddress);


                SqlParameter paramChartererUniqueIDInDB = new SqlParameter();
                paramChartererUniqueIDInDB.ParameterName = "@ChartererUniqueIDInDB";
                paramChartererUniqueIDInDB.Value = f.ChartererUniqueIDInDB;
                cmd.Parameters.Add(paramChartererUniqueIDInDB);

                SqlParameter paramChartererAddressUpdated = new SqlParameter();
                paramChartererAddressUpdated.ParameterName = "@ChartererAddressUpdated";
                paramChartererAddressUpdated.Value = f.ChartererAddressUpdated;
                cmd.Parameters.Add(paramChartererAddressUpdated);

                SqlParameter paramOwner = new SqlParameter();
                paramOwner.ParameterName = "@Owner";
                paramOwner.Value = f.Owner;
                cmd.Parameters.Add(paramOwner);

                SqlParameter paramOwnerCustID = new SqlParameter();
                paramOwnerCustID.ParameterName = "@OwnerCustID";
                paramOwnerCustID.Value = f.OwnerCustID;
                cmd.Parameters.Add(paramOwnerCustID);

                SqlParameter paramownerGroup = new SqlParameter();
                paramownerGroup.ParameterName = "@OwnerGroup";
                paramownerGroup.Value = f.OwnerGroup;
                cmd.Parameters.Add(paramownerGroup);

                SqlParameter paramOwnerAddress = new SqlParameter();
                paramOwnerAddress.ParameterName = "@OwnerAddress";
                paramOwnerAddress.Value = f.OwnerAddress;
                cmd.Parameters.Add(paramOwnerAddress);

                SqlParameter paramOwnerUniqueIDInDB = new SqlParameter();
                paramOwnerUniqueIDInDB.ParameterName = "@OwnerUniqueIDInDB";
                paramOwnerUniqueIDInDB.Value = f.OwnerUniqueIDInDB;
                cmd.Parameters.Add(paramOwnerUniqueIDInDB);

                SqlParameter paramOwnerAddressUpdated = new SqlParameter();
                paramOwnerAddressUpdated.ParameterName = "@OwnerAddressUpdated";
                paramOwnerAddressUpdated.Value = f.OwnerAddressUpdated;
                cmd.Parameters.Add(paramOwnerAddressUpdated);

                SqlParameter paramThirdPartyBroker = new SqlParameter();
                paramThirdPartyBroker.ParameterName = "@ThirdPartyBroker";
                paramThirdPartyBroker.Value = f.ThirdPartyBroker;
                cmd.Parameters.Add(paramThirdPartyBroker);

                SqlParameter paramThirdPartyBrokerID = new SqlParameter();
                paramThirdPartyBrokerID.ParameterName = "@ThirdPartyBrokerID";
                paramThirdPartyBrokerID.Value = f.ThirdPartyBrokerID;
                cmd.Parameters.Add(paramThirdPartyBrokerID);


                SqlParameter paramThirdPartyBrokerPercentage = new SqlParameter();
                paramThirdPartyBrokerPercentage.ParameterName = "@ThirdPartyBrokerPercentage";
                paramThirdPartyBrokerPercentage.Value = f.ThirdPartyPercentage;
                cmd.Parameters.Add(paramThirdPartyBrokerPercentage);

                SqlParameter paramCargo = new SqlParameter();
                paramCargo.ParameterName = "@Cargo";
                paramCargo.Value = f.Cargo;
                cmd.Parameters.Add(paramCargo);

                SqlParameter paramQuantity = new SqlParameter();
                paramQuantity.ParameterName = "@Quantity";
                paramQuantity.Value = f.Quantity;
                cmd.Parameters.Add(paramQuantity);

                SqlParameter paramUOM = new SqlParameter();
                paramUOM.ParameterName = "@UOM";
                paramUOM.Value = f.UOM;
                cmd.Parameters.Add(paramUOM);

                SqlParameter paramNotes = new SqlParameter();
                paramNotes.ParameterName = "@Notes";
                paramNotes.Value = f.Notes;
                cmd.Parameters.Add(paramNotes);

                SqlParameter paramDesk = new SqlParameter();
                paramDesk.ParameterName = "@Desk";
                paramDesk.Value = f.Desk;
                cmd.Parameters.Add(paramDesk);

                SqlParameter paramOffice = new SqlParameter();
                paramOffice.ParameterName = "@Office";
                paramOffice.Value = f.Office;
                cmd.Parameters.Add(paramOffice);

                SqlParameter paramCreatedBy = new SqlParameter();
                paramCreatedBy.ParameterName = "@CreatedBy";
                paramCreatedBy.Value = f.CreatedBy;
                cmd.Parameters.Add(paramCreatedBy);

                SqlParameter paramCreatedDate = new SqlParameter();
                paramCreatedDate.ParameterName = "@CreateDate";
                paramCreatedDate.Value = DateTime.Now;
                cmd.Parameters.Add(paramCreatedDate);

                SqlParameter paramUpdatedBy = new SqlParameter();
                paramUpdatedBy.ParameterName = "@UpdatedBy";
                paramUpdatedBy.Value =f.UpdatedBy;
                cmd.Parameters.Add(paramUpdatedBy);

                SqlParameter paramUpdateDate = new SqlParameter();
                paramUpdateDate.ParameterName = "@UpdateDate";
                paramUpdateDate.Value = DateTime.Now;
                cmd.Parameters.Add(paramUpdateDate);

                SqlParameter paramVoyageType = new SqlParameter();
                paramVoyageType.ParameterName = "@VoyageType";
                paramVoyageType.Value = f.VoyageType;
                cmd.Parameters.Add(paramVoyageType);

                SqlParameter paramLoadPort = new SqlParameter();
                paramLoadPort.ParameterName = "@LoadPort";
                paramLoadPort.Value = f.LoadPort;
                cmd.Parameters.Add(paramLoadPort);

                SqlParameter paramDischargePort = new SqlParameter();
                paramDischargePort.ParameterName = "@DischargePort";
                paramDischargePort.Value = f.DischargePort;
                cmd.Parameters.Add(paramDischargePort);

                SqlParameter paramRate1 = new SqlParameter();
                paramRate1.ParameterName = "@Rate1";
                paramRate1.Value = f.Rate1;
                cmd.Parameters.Add(paramRate1);

                SqlParameter paramRate2 = new SqlParameter();
                paramRate2.ParameterName = "@Rate2";
                paramRate2.Value = f.Rate2;
                cmd.Parameters.Add(paramRate2);

                SqlParameter paramStatus = new SqlParameter();
                paramStatus.ParameterName = "@Status";
                paramStatus.Value = f.Status;
                cmd.Parameters.Add(paramStatus);

                SqlParameter paramStartDate = new SqlParameter();
                paramStartDate.ParameterName = "@StartDate";
                paramStartDate.Value = f.StartDate;
                cmd.Parameters.Add(paramStartDate);

                SqlParameter paramEndDate = new SqlParameter();
                paramEndDate.ParameterName = "@EndDate";
                paramEndDate.Value = f.EndDate;
                cmd.Parameters.Add(paramEndDate);


                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}