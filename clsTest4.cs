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
	public class clsTest4 : Quasi97.clsQSTTestNET
	{
		
		public const string ThisTestID = "NETSample 4 [Custom]";
		private short mvarDataPoints = (short) 10;
		
		public clsTest4()
		{
			object temp_objPTR = this;
			System.Type temp_pType = mvarDataPoints.GetType();
			this.colParameters.Add(new Quasi97.clsTestParam("Data Points", "DataPoints", ref temp_objPTR, ref temp_pType, true, true, 10, null));
			this.colResultNames.Add(new Quasi97.ResultName("Resistance (Ohm)"));
		}
		
public short DataPoints
		{
			get
			{
				return mvarDataPoints;
			}
			set
			{
				if (value < 10 | value > 10000)
				{
					throw (new System.ArgumentOutOfRangeException("DataPoints", value, "Out of range 10..10000 [" + System.Convert.ToString(value) + "]"));
				}
				else
				{
					mvarDataPoints = value;
				}
			}
		}
		
		public override void RunTest()
		{
			Quasi97.ResultNet Rslt = default(Quasi97.ResultNet);
			System.Diagnostics.Stopwatch sWatch = new System.Diagnostics.Stopwatch();
			float[,,] pdBuffer = null;
			double[] fieldbuf = new double[mvarDataPoints - 1 + 1];
			short Chan = modMain.QST.QSTHardware.MRChannel;
			double[] vBuff = null;
			
			try
			{
				sWatch.Restart();
				if (modMain.QST.OptionsParameters.AutoClearResults)
				{
					ClearResults(false); //the menu is going to refresh anyway when we add new results
				}
				
				Rslt = new Quasi97.ResultNet();
				colResults.Insert(0, Rslt);
				Rslt.Data.Columns.Clear();
				Rslt.Data.Columns.Add("Sample #", typeof(short));
				Rslt.Data.Columns.Add("Resistance (Ohm)", typeof(Single));
				Rslt.Data.Columns.Add("Random", typeof(Single));
				
				//measuring
				//set 156KHz sampling rate
				modMain.QST.PatGenBoardParameters.DelayCounter = (byte) 0;
				modMain.QST.PatGenBoardParameters.SampleCounter = (byte) 0;
				//set dc level
				modMain.QST.QSTHardware.GenerateLevel(ref fieldbuf, mvarDataPoints, 0, (short) 0);
				//select low gain
				modMain.QST.QSTHardware.TCSplitSelectInput(false);
				pdBuffer = new float[2, (fieldbuf.Length - 1) + 1, 2]; //number of cycles, number of data points, 2 channels
				modMain.QST.QSTHardware.TCSplitCaptureWaveform(ref pdBuffer, (short) 1, (short) 1);
				modMain.QST.QSTHardware.TCSplitScaleWaveform2(ref pdBuffer, 0,false);
				modMain.QST.QSTHardware.ExtractPulseByChannel(ref vBuff, (short) 0, ref pdBuffer, modMain.QST.QSTHardware.MRChannel);
				
				//storing in the data
				for (var i = 0; i <= (vBuff.Length - 1); i++)
				{
					Rslt.Data.Rows.Add(1 + i, vBuff[(int) i], 100 * VBMath.Rnd(1));
				}
				base.RaiseNewDataAvailable(colResults.Count, 1, -1, -1);
				base.RaiseNewDataAvailable(colResults.Count, 2, -1, -1);
				
				//report results
				Rslt.AddParameters(this.colParameters);
				Rslt.AddResult2("Resistance (Ohm)", 0, 1, true); //let next statement calculate statistics
				Rslt.CalcStats2(true, 1);
				
				//grade results
				Quasi97.clsQSTTestNET temp_test = this;
				modMain.QST.GradingParameters.GradeTestNet(ref temp_test, (short) 0);
				
				//add information about run
				Quasi97.clsQSTTestNET temp_test2 = this;
				Rslt.AddInfo(ref temp_test2, sWatch.ElapsedMilliseconds, ref modMain.QST.QuasiParameters.CurInfo);
				
				//notify the form that new results are available
				base.RaiseNewInfoAvailable();
				base.RaiseNewResultsAvailable(new int[] {0});
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ThisTestID + " RunTest " + ex.Message);
			}
		}
		
		public override void GetSeriesColor(int Ridx, int dataColIDX, ref System.Drawing.Color cl, ref int LineType)
		{
			if (dataColIDX == 1)
			{
				cl = System.Drawing.Color.Blue;
			}
			else if (dataColIDX == 2)
			{
				cl = System.Drawing.Color.Red;
			}
		}
		
		public override void SetDBase(ref string NewDBase, ref object voidParam)
		{
			
		}
		
		public override void StoreParameters()
		{
			
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
			List<short> l = new List<short>();
			l.Add(1);
			return l;
		}
		
		public override void ClearResults(bool doRefreshPlot = false)
		{
			colResults.Clear();
			base.RaiseResultsCleared(doRefreshPlot);
		}
		
public override short ContainsGraph
		{
			get
			{
				return -1;
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
		
		public override void RemoveRecord()
		{
			
		}
		
		public override void RestoreParameters()
		{
			
		}
	}
	
}
