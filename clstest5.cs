// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
// End of VB project level imports

using System.Windows.Forms;

namespace QuasiAddIn2
{
	public class clsTest5 : Quasi97.clsQSTTestNET
	{
		
		public const string ThisTestID = "NETSample 5 [Stress]";
		private NativeRes objNativeRes = new NativeRes();
		private short mvarAverages = (short) 1;
		private System.Data.OleDb.OleDbConnection DBPtr;
		public Quasi97.clsStress Stress; // VBConversions Note: Initial value cannot be assigned here since it is non-static.  Assignment has been moved to the class constructors.
		
		public override void SetDBase(ref string NewDBase, ref object voidParam)
		{
			//all setups should have one item, if user wants to add one item by default.
			//will only remember the name
			try
			{
				System.Data.OleDb.OleDbConnectionStringBuilder cnBuilder = new System.Data.OleDb.OleDbConnectionStringBuilder();
				if (NewDBase == "")
				{
					DBPtr = null;
					object temp_AllSetups = null;
					Stress.SetDBase(NewDBase, ref temp_AllSetups);
				}
				else
				{
					DBPtr = new System.Data.OleDb.OleDbConnection();
					cnBuilder.Provider = "Microsoft.Jet.OLEDB.4.0";
					cnBuilder.DataSource = NewDBase;
					DBPtr.ConnectionString = cnBuilder.ConnectionString;
					
					//stress related initialization
					Stress.OwnerSetupNumber = Setup;
					Stress.OwnerTestID = TestID ;
					object temp_AllSetups2 = null;
					Stress.SetDBase(NewDBase, ref temp_AllSetups2);
				}
				UpdateTableDefs(DBPtr);
				
			}
			catch (Exception ex)
			{
				MessageBox.Show("SetDBase " + ex.Message);
			}
		}
		
		private class NativeRes
		{
			public string bv = "Bias Voltage";
			public string res = "Resistance (Ohm)";
		}
		
public short Average
		{
			get
			{
				return mvarAverages;
			}
			set
			{
				if (value < 1 | value > 100)
				{
					throw (new System.ArgumentOutOfRangeException("Average", value, "Out of range 1..100 [" + System.Convert.ToString(value) + "]"));
				}
				else
				{
					mvarAverages = value;
				}
			}
		}
		
		public override void RunTest()
		{
			Quasi97.ResultNet Rslt = default(Quasi97.ResultNet);
			double MeasuredVal = 0;
			float ib = 0;
			
			try
			{
				if (modMain.QST.OptionsParameters.AutoClearResults)
				{
					ClearResults(false); //the menu is going to refresh anyway when we add new results
				}
				Stress.RunStress2(Quasi97.clsStress.StressMode.strStoreParams);
				
				Stress.RunStress2(Quasi97.clsStress.StressMode.strRunStress);
				//measuring
				for (var i = 1; i <= mvarAverages; i++)
				{
					MeasuredVal += modMain.QST.ChannelManager.DCChannel.MeasureR(modMain.QST.QSTHardware.MRChannel, (short) 10, 0);
					ib += modMain.QST.QSTHardware.GetReadBias(modMain.QST.QSTHardware.MRChannel);
				}
				ib /= mvarAverages;
				MeasuredVal /= mvarAverages;
				
				Stress.RunStress2(Quasi97.clsStress.StressMode.strrestoreparams);
				
				//report results
				Rslt = new Quasi97.ResultNet();
				Rslt.AddParameters(this.colParameters);
				colResults.Insert(0, Rslt);
				Rslt.AddResult2(objNativeRes.res, MeasuredVal.ToString("F2"), 1, true);
				Rslt.AddResult2(objNativeRes.bv, (ib * MeasuredVal).ToString("F2"), 1, true);
				Rslt.CalcStats2(false, 1);
				
				//grade results
				Quasi97.clsQSTTestNET temp_test = this;
				modMain.QST.GradingParameters.GradeTestNet(ref temp_test, (short) 0);
				
				//add information about run
				Quasi97.clsQSTTestNET temp_test2 = this;
				Rslt.AddInfo(ref temp_test2, 0, ref modMain.QST.QuasiParameters.CurInfo);
				
				//notify the form that new results are available
				base.RaiseNewInfoAvailable();
				base.RaiseNewResultsAvailable(new int[] {0});
				
			}
			catch (Exception ex)
			{
				MessageBox.Show("clsTest5:RunTest " + ex.Message);
			}
		}
		
		public void UpdateTableDefs(System.Data.OleDb.OleDbConnection db)
		{
			if (db == null)
			{
				return ;
			}
			
			try
			{
				System.Data.OleDb.OleDbCommand SQLCom = new System.Data.OleDb.OleDbCommand("CREATE TABLE QuasiAddIn2_NETSample5 (Setup Integer, Averages Integer)", db);
				SQLCom.ExecuteNonQuery();
			}
			catch (Exception)
			{
				//table already exists
				//MsgBox("UpdateTableDefs " & ex.Message)
			}
		}
		
public override string TestID
		{
			get
			{
				return ThisTestID;
			}
		}
		
		public override System.Collections.Generic.List<short> CheckRecords(string NewDBase)
		{
			//this really should be a shared function, but since there is no way to ver
			//all setups should have one item, if user wants to add one item by default.
			//will only remember the name
			System.Data.OleDb.OleDbConnection db = default(System.Data.OleDb.OleDbConnection);
			System.Data.OleDb.OleDbConnectionStringBuilder cnBuilder = new System.Data.OleDb.OleDbConnectionStringBuilder();
			System.Data.OleDb.OleDbCommand dbCom = new System.Data.OleDb.OleDbCommand();
			System.Data.OleDb.OleDbDataReader records = default(System.Data.OleDb.OleDbDataReader);
			List<short> AllSetups = new List<short>();
			
			if (!(NewDBase == ""))
			{
				try
				{
					db = new System.Data.OleDb.OleDbConnection();
					cnBuilder.Provider = "Microsoft.Jet.OLEDB.4.0";
					cnBuilder.DataSource = NewDBase;
					db.ConnectionString = cnBuilder.ConnectionString;
					db.Open();
					
					dbCom.CommandText = "SELECT Setup FROM QuasiAddIn2_NetSample5 ORDER BY Setup";
					dbCom.Connection = db;
					try
					{
						records = dbCom.ExecuteReader();
					}
					catch (Exception)
					{
						UpdateTableDefs(db);
						records = dbCom.ExecuteReader();
					}
					
					while (records.Read())
					{
						AllSetups.Add(System.Convert.ToInt16(records["Setup"]));
					}
					
					if (db.State != ConnectionState.Closed)
					{
						db.Close();
					}
				}
				catch (Exception e)
				{
					MessageBox.Show("CheckRecords " + e.Message);
				}
			}
			
			return AllSetups;
		}
		
		public override void ClearResults(bool doRefreshPlot = false)
		{
			colResults.Clear();
			base.RaiseResultsCleared(doRefreshPlot);
		}
		
		public override void RemoveRecord()
		{
			if (DBPtr == null)
			{
				return;
			}
			System.Data.OleDb.OleDbCommand sqlcom = new System.Data.OleDb.OleDbCommand("DELETE * FROM QuasiAddIn2_NetSample5 WHERE Setup=" + System.Convert.ToString(Setup), DBPtr);
			try
			{
				DBPtr.Open();
				sqlcom.ExecuteNonQuery();
				
				Stress.DeleteStressFromDB();
				
			}
			catch (Exception e)
			{
				MessageBox.Show("RemoveRecord " + e.Message);
			}
			finally
			{
				DBPtr.Close();
			}
			DBPtr = null;
		}
		
		public override void RestoreParameters()
		{
			//testsetup was left for compatibility only; is not used otherwise
			System.Data.OleDb.OleDbDataReader rsParameters = default(System.Data.OleDb.OleDbDataReader);
			
			try
			{
				if (DBPtr == null)
				{
					return ;
				}
				DBPtr.Open();
				System.Data.OleDb.OleDbCommand sqlCOM = new System.Data.OleDb.OleDbCommand("SELECT * FROM QuasiAddIn2_NetSample5 WHERE Setup=" + System.Convert.ToString(Setup)) {Connection = DBPtr};
				
				sqlCOM.ExecuteScalar();
				rsParameters = sqlCOM.ExecuteReader();
				if (!rsParameters.Read())
				{
					//no records
					rsParameters.Close();
					System.Data.OleDb.OleDbCommand sqlWRCom = new System.Data.OleDb.OleDbCommand("INSERT INTO QuasiAddIn2_NetSample2 (Setup) VALUES (" + System.Convert.ToString(Setup) + ")", DBPtr);
					sqlWRCom.ExecuteNonQuery();
					sqlCOM.ExecuteNonQuery();
					rsParameters = sqlCOM.ExecuteReader();
					rsParameters.Read();
				}
				
				if (!(rsParameters == null))
				{
					mvarAverages = System.Convert.ToInt16(rsParameters["Averages"]);
				}
				
				Stress.RestoreParameters(TestID, Setup);
				base.RaiseRestoreParams();
				
			}
			catch (Exception ex)
			{
				MessageBox.Show("RestoreParameters " + ex.Message);
			}
			finally
			{
				if (DBPtr.State == ConnectionState.Open)
				{
					DBPtr.Close();
				}
			}
		}
		
		public override void StoreParameters()
		{
			if (DBPtr == null)
			{
				return ;
			}
			
			try
			{
				System.Data.OleDb.OleDbCommand SQLCom = new System.Data.OleDb.OleDbCommand("DELETE * FROM QuasiAddIn2_NETSample5 WHERE Setup=" + Setup.ToString(), DBPtr);
				DBPtr.Open();
				SQLCom.ExecuteNonQuery();
				SQLCom.CommandText = "INSERT INTO QuasiAddIn2_NETSample5 (Setup, Averages) VALUES (" + Setup.ToString() + "," + mvarAverages.ToString() + ")";
				
				SQLCom.ExecuteNonQuery();
				
				string temp_TestID = TestID;
				Stress.StoreParametersNew(ref temp_TestID, ref Setup);
				
			}
			catch (Exception ex)
			{
				MessageBox.Show("StoreParameters " + ex.Message);
				
			}
			finally
			{
				if (DBPtr.State != ConnectionState.Closed)
				{
					DBPtr.Close();
				}
				
			}
		}
		
public override short ContainsGraph
		{
			get
			{
				return 0;
			}
		}
		
public override bool ContainsResultPerCycle
		{
			get
			{
				return false;
			}
		}
		
public override bool DualChannelCapable
		{
			get
			{
				return false;
			}
		}
		
public override UInt32 FeatureVector
		{
			get
			{
				return 0;
			}
		}
		
		public clsTest5()
		{
			// VBConversions Note: Non-static class variable initialization is below.  Class variables cannot be initially assigned non-static values in C#.
			Stress = new Quasi97.clsStress() {ID = "Stress"};
			
			base.RegisterResults2(objNativeRes);
			base.colParameters.Add(new Quasi97.clsTestParam(this,"Average", "Average", Average.GetType(), true, null));
		}
	}
}
