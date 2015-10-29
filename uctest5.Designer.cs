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
	partial class uctest5 : System.Windows.Forms.UserControl
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
			this.lblResult = new System.Windows.Forms.Label();
			this.txtRes = new System.Windows.Forms.TextBox();
			this.txtAverages = new System.Windows.Forms.TextBox();
			this.txtAverages.LostFocus += new System.EventHandler(this.txtDataPoints_LostFocus);
			this.lblDataPts = new System.Windows.Forms.Label();
			this.cmdStress = new System.Windows.Forms.Button();
			this.cmdStress.Click += new System.EventHandler(this.cmdStress_Click);
			this.SuspendLayout();
			//
			//lblResult
			//
			this.lblResult.Anchor = (System.Windows.Forms.AnchorStyles) (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.lblResult.AutoSize = true;
			this.lblResult.Location = new System.Drawing.Point(44, 90);
			this.lblResult.Name = "lblResult";
			this.lblResult.Size = new System.Drawing.Size(93, 13);
			this.lblResult.TabIndex = 8;
			this.lblResult.Text = "Result Resistance";
			//
			//txtRes
			//
			this.txtRes.Anchor = (System.Windows.Forms.AnchorStyles) (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.txtRes.Location = new System.Drawing.Point(143, 87);
			this.txtRes.Name = "txtRes";
			this.txtRes.Size = new System.Drawing.Size(34, 20);
			this.txtRes.TabIndex = 7;
			//
			//txtAverages
			//
			this.txtAverages.Location = new System.Drawing.Point(77, 12);
			this.txtAverages.Name = "txtAverages";
			this.txtAverages.Size = new System.Drawing.Size(100, 20);
			this.txtAverages.TabIndex = 6;
			//
			//lblDataPts
			//
			this.lblDataPts.AutoSize = true;
			this.lblDataPts.Location = new System.Drawing.Point(9, 15);
			this.lblDataPts.Name = "lblDataPts";
			this.lblDataPts.Size = new System.Drawing.Size(52, 13);
			this.lblDataPts.TabIndex = 5;
			this.lblDataPts.Text = "Averages";
			//
			//cmdStress
			//
			this.cmdStress.Location = new System.Drawing.Point(238, 28);
			this.cmdStress.Name = "cmdStress";
			this.cmdStress.Size = new System.Drawing.Size(209, 50);
			this.cmdStress.TabIndex = 9;
			this.cmdStress.Text = "Stress Options";
			this.cmdStress.UseVisualStyleBackColor = true;
			//
			//uctest5
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cmdStress);
			this.Controls.Add(this.lblResult);
			this.Controls.Add(this.txtRes);
			this.Controls.Add(this.txtAverages);
			this.Controls.Add(this.lblDataPts);
			this.Name = "uctest5";
			this.Size = new System.Drawing.Size(489, 125);
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.Label lblResult;
		internal System.Windows.Forms.TextBox txtRes;
		internal System.Windows.Forms.TextBox txtAverages;
		internal System.Windows.Forms.Label lblDataPts;
		internal System.Windows.Forms.Button cmdStress;
		
	}
	
}
