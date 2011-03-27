﻿/*
 * Copyright (c) 2011 Geoffrey Prytherch
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this
 * software and associated documentation files (the "Software"), to deal in the Software
 * without restriction, including without limitation the rights to use, copy, modify, merge,
 * publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
 * to whom the Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or
 * substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 * PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
 * FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
 * OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
 * DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Windows.Forms;
using OpticianDB.Adaptor;
using System.Drawing;

namespace OpticianDB.Forms.Dialogs
{
	public partial class PhoneRecall : Form
	{
		DBBackEnd dbb;
		PatientRecalls rclrec;
		public PhoneRecall(int RecallID)
		{
			InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
			dbb = Program.oProg.dbb;

			rclrec = dbb.GetRecallByRclId(RecallID);
			name_Label.Text = rclrec.Patients.Name;
			telNum_Label.Text = rclrec.Patients.TelNum;
			reason_Label.Text = rclrec.Reason;
		}
		
		void Confirm_ButtonClick(object sender, EventArgs e)
		{
			using (NewAppointment na1 = new NewAppointment(rclrec.PatientID,cal_Calendar.SelectionStart))
			{
				na1.ShowDialog();
				if (na1.DialogResult == DialogResult.OK)
				{
					dbb.DeleteRecall(rclrec.PatientID);
					this.DialogResult = DialogResult.OK;
					this.Close(); //remove recall
				}
			}
		}
	}
}
