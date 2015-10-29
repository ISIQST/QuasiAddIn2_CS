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
	public partial class ucTest4 : Quasi97.iQSTUserControl
	{
		public ucTest4()
		{
			InitializeComponent();
		}
		
		private clsTest4 OwnerTest;
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
		
		public System.Drawing.Image GetChart(int SizeXmm, int SizeYmm)
		{
			System.Drawing.Image returnValue = default(System.Drawing.Image);
			//        Return Nothing
			System.IO.MemoryStream imstream = new System.IO.MemoryStream();
			Chart1.SaveImage(imstream, System.Drawing.Imaging.ImageFormat.Png);
			returnValue = System.Drawing.Image.FromStream(imstream);
			imstream.Close();
			return returnValue;
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
			OwnerTest = (clsTest4)lOwnerTest;
			OwnerTest.NewResultsAvailable += OwnerTest_NewResultsAvailable;
			OwnerTest.RestoreParams += OwnerTest_RestoreParams;
			OwnerTest.ResultsCleared += OwnerTest_ResultsCleared;
			OwnerTestKey = lOwnerTest.Key;
			
			txtDataPoints.Text = OwnerTest.DataPoints.ToString ();
		}
		
		public void txtDataPoints_LostFocus(object sender, System.EventArgs e)
		{
			OwnerTest.DataPoints = (short) (Conversion.Val(txtDataPoints.Text));
		}
		
		public void OwnerTest_NewResultsAvailable(int[] rsList)
		{
			try
			{
				txtRes.Text = System.Convert.ToString(OwnerTest.colResults[rsList[0]].GetResult("Resistance (Ohm)"));
				Chart1.DataSource = OwnerTest.colResults[rsList[0]].Data;
				Chart1.DataBind();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void OwnerTest_RestoreParams()
		{
			txtDataPoints.Text = OwnerTest.DataPoints.ToString();
		}
		
		public void OwnerTest_ResultsCleared(bool DoRefreshMenu)
		{
			txtRes.Text = "";
		}
		
		public System.Windows.Forms.MethodInvoker Activate {get; set;}
		
	}
	
}
