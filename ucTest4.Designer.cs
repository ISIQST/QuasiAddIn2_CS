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


namespace QuasiAddIn2
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class ucTest4 : System.Windows.Forms.UserControl
	{
		
		//UserControl overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
		
		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea ChartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend Legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series Series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series Series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.Chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.Disposed += new System.EventHandler(ucTest4_Disposed);
			this.lblDataPts = new System.Windows.Forms.Label();
			this.txtDataPoints = new System.Windows.Forms.TextBox();
			this.txtDataPoints.LostFocus += new System.EventHandler(this.txtDataPoints_LostFocus);
			this.txtRes = new System.Windows.Forms.TextBox();
			this.lblResult = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) this.Chart1).BeginInit();
			this.SuspendLayout();
			//
			//Chart1
			//
			this.Chart1.Anchor = (System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			ChartArea1.Name = "ChartArea1";
			this.Chart1.ChartAreas.Add(ChartArea1);
			Legend1.Name = "Legend1";
			this.Chart1.Legends.Add(Legend1);
			this.Chart1.Location = new System.Drawing.Point(0, 51);
			this.Chart1.Name = "Chart1";
			Series1.ChartArea = "ChartArea1";
			Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			Series1.Legend = "Legend1";
			Series1.Name = "Series1";
			Series1.XValueMember = "Sample #";
			Series1.YValueMembers = "Resistance (Ohm)";
			Series2.ChartArea = "ChartArea1";
			Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			Series2.Legend = "Legend1";
			Series2.Name = "Series2";
			Series2.XValueMember = "Sample #";
			Series2.YValueMembers = "Random";
			this.Chart1.Series.Add(Series1);
			this.Chart1.Series.Add(Series2);
			this.Chart1.Size = new System.Drawing.Size(348, 258);
			this.Chart1.TabIndex = 0;
			this.Chart1.Text = "Chart1";
			//
			//lblDataPts
			//
			this.lblDataPts.AutoSize = true;
			this.lblDataPts.Location = new System.Drawing.Point(16, 16);
			this.lblDataPts.Name = "lblDataPts";
			this.lblDataPts.Size = new System.Drawing.Size(62, 13);
			this.lblDataPts.TabIndex = 1;
			this.lblDataPts.Text = "Data Points";
			//
			//txtDataPoints
			//
			this.txtDataPoints.Location = new System.Drawing.Point(84, 13);
			this.txtDataPoints.Name = "txtDataPoints";
			this.txtDataPoints.Size = new System.Drawing.Size(100, 20);
			this.txtDataPoints.TabIndex = 2;
			//
			//txtRes
			//
			this.txtRes.Anchor = (System.Windows.Forms.AnchorStyles) (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.txtRes.Location = new System.Drawing.Point(453, 54);
			this.txtRes.Name = "txtRes";
			this.txtRes.Size = new System.Drawing.Size(34, 20);
			this.txtRes.TabIndex = 3;
			//
			//lblResult
			//
			this.lblResult.Anchor = (System.Windows.Forms.AnchorStyles) (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.lblResult.AutoSize = true;
			this.lblResult.Location = new System.Drawing.Point(354, 57);
			this.lblResult.Name = "lblResult";
			this.lblResult.Size = new System.Drawing.Size(93, 13);
			this.lblResult.TabIndex = 4;
			this.lblResult.Text = "Result Resistance";
			//
			//ucTest4
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblResult);
			this.Controls.Add(this.txtRes);
			this.Controls.Add(this.txtDataPoints);
			this.Controls.Add(this.lblDataPts);
			this.Controls.Add(this.Chart1);
			this.Name = "ucTest4";
			this.Size = new System.Drawing.Size(490, 309);
			((System.ComponentModel.ISupportInitialize) this.Chart1).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.DataVisualization.Charting.Chart Chart1;
		internal System.Windows.Forms.Label lblDataPts;
		internal System.Windows.Forms.TextBox txtDataPoints;
		internal System.Windows.Forms.TextBox txtRes;
		internal System.Windows.Forms.Label lblResult;
		
		private void ucTest4_Disposed(object sender, System.EventArgs e)
		{
			if (!(OwnerTest == null))
			{
				OwnerTest = null;
				OwnerTest.NewResultsAvailable += new Quasi97.clsQSTTestNET.NewResultsAvailableEventHandler(OwnerTest_NewResultsAvailable);
				OwnerTest.RestoreParams += new Quasi97.clsQSTTestNET.RestoreParamsEventHandler(OwnerTest_RestoreParams);
				OwnerTest.ResultsCleared += new Quasi97.clsQSTTestNET.ResultsClearedEventHandler(OwnerTest_ResultsCleared);
			}
		}
	}
	
}
