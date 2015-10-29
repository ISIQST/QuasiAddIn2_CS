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
	public partial class uctest5 : Quasi97.iQSTUserControl
	{
		public uctest5()
		{
			InitializeComponent();
		}
		
		private clsTest5 OwnerTest;
		private string _OwnerTestKey = "";
public string OwnerTestKey
		{
			get
			{
				return _OwnerTestKey;
			}
			set
			{
				_OwnerTestKey = value;
			}
		}
		public System.Windows.Forms.MethodInvoker Activate {get; set;}
		public System.Drawing.Image GetChart(int SizeXmm, int SizeYmm)
		{
			return null;
		}
		
public string LongLabel
		{
			get
			{
				return OwnerTest.TestIDandSetup;
			}
		}
		
public string ShortLabel
		{
			get
			{
				return OwnerTest.TestIDandSetup;
			}
		}
		
public System.Windows.Forms.UserControl MenuPTR
		{
			get
			{
				return this;
			}
		}
		
		public void PickResult(short rsidx)
		{
			
		}
		
		public void RunTimeInit(ref Quasi97.clsQSTTestNET lOwnerTest)
		{
			OwnerTest = (clsTest5)lOwnerTest;
			OwnerTest.NewResultsAvailable += OwnerTest_NewResultsAvailable;
			OwnerTest.RestoreParams += OwnerTest_RestoreParams;
			OwnerTest.ResultsCleared += OwnerTest_ResultsCleared;
			OwnerTestKey = lOwnerTest.Key;
			
			txtAverages.Text = OwnerTest.Average.ToString ();
			cmdStress.ForeColor = OwnerTest.Stress.HasEnabledStressItems() ? System.Drawing.Color.Blue : System.Drawing.Color.Black;
		}
		
		public void txtDataPoints_LostFocus(object sender, System.EventArgs e)
		{
			OwnerTest.Average = (short) (Conversion.Val(txtAverages.Text));
		}
		
		private void OwnerTest_NewResultsAvailable(int[] rsList)
		{
			try
			{
				txtRes.Text = System.Convert.ToString(OwnerTest.colResults[rsList[0]].GetResult("Resistance (Ohm)"));
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		private void OwnerTest_RestoreParams()
		{
			txtAverages.Text = OwnerTest.Average.ToString ();
		}
		
		private void OwnerTest_ResultsCleared(bool DoRefreshMenu)
		{
			txtRes.Text = "";
		}
		
		public void cmdStress_Click(System.Object sender, System.EventArgs e)
		{
			OwnerTest.Stress.ShowForm();
			cmdStress.ForeColor = OwnerTest.Stress.HasEnabledStressItems() ? System.Drawing.Color.Blue : System.Drawing.Color.Black;
		}
	}
	
}
