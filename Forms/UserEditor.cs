﻿
using System;
using System.Windows.Forms;

namespace OpticianDB.Forms
{
	/// <summary>
	/// Description of UserEditor.
	/// </summary>
	public partial class UserEditor : Form
	{
		DBBackEnd dbb;
		string passwordempty = "........";
		public UserEditor()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			dbb = new DBBackEnd();

		}
		
		void UserEditorLoad(object sender, EventArgs e)
		{
			ReloadUsers();
		}
		void ReloadUsers()
		{
			listBox1.Items.Clear();
			var UserNameList = dbb.UserNameList;
			foreach(string UserName in UserNameList)
			{
				listBox1.Items.Add(UserName);
			}
		}

		// Cant change own username
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			usernameTextBox.Enabled = true;
			errorProvider1.Clear();
			//TODO: ask if save is needed
			if (listBox1.SelectedIndex == -1)
				return;
			//TODO: enable text fields
			string username = listBox1.SelectedItem.ToString();
			var user = dbb.GetUserInfo(username);
			if(StaticStorage.UserName == user.Username)
			{
				usernameTextBox.Enabled = false;
			}
			this.usernameTextBox.Text = user.Username;
			this.passwordTextBox.Text = passwordempty;
			this.fullNameTextBox.Text = user.Fullname;
		}
		
		void PasswordTextBoxEnter(object sender, EventArgs e)
		{
			if (passwordTextBox.Text == passwordempty)
				passwordTextBox.Text = string.Empty;
			//toolTip1.Show("If a blank password is entered the password will not be changed",passwordTextBox,5000);
		}
		
		void PasswordTextBoxLeave(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(passwordTextBox.Text))
				passwordTextBox.Text = passwordempty;
			
		}
		
		void CutToolStripButtonClick(object sender, EventArgs e)
		{
			//TODO
			throw new NotImplementedException();
		}
		
		void CopyToolStripButtonClick(object sender, EventArgs e)
		{
			//TODO
			throw new NotImplementedException();
		}
		
		void PasteToolStripButtonClick(object sender, EventArgs e)
		{
			//TODO
			throw new NotImplementedException();
		}
		
		void NewToolStripButtonClick(object sender, EventArgs e)
		{
			errorProvider1.Clear();
			wat();
		}
		
		void SaveToolStripButtonClick(object sender, EventArgs e)
		{
			bool newuser;
			if(listBox1.SelectedIndex == -1)
			{
				newuser = true;
			}
			else
			{
				newuser = false;
			}
			errorProvider1.Clear();
			bool errortriggered = false;
			if (usernameTextBox.Text == "")
			{
				errorProvider1.SetError(usernameTextBox,"No username set");
				errortriggered = true;
			}
			if (newuser && (passwordTextBox.Text == passwordempty || passwordTextBox.Text == ""))
			{
				errorProvider1.SetError(passwordTextBox,"No password set");
				errortriggered = true;
			}
			if (fullNameTextBox.Text  == "")
			{
				errorProvider1.SetError(fullNameTextBox,"No name set");
				errortriggered = true;
			}
			if (errortriggered)
				return;
			bool result;
			if (newuser)
			{
				result = dbb.CreateNewUser(usernameTextBox.Text, passwordTextBox.Text, fullNameTextBox.Text);
			} else
			{
				result = dbb.AmendUser(listBox1.SelectedItem.ToString(),usernameTextBox.Text,passwordTextBox.Text,fullNameTextBox.Text);
			}
			
			if(!result)
			{
				errorProvider1.SetError(usernameTextBox,"User exists");
				return;
			}
			ReloadUsers();

			wat();
		}

		void wat()
		{
			listBox1.ClearSelected();
			usernameTextBox.Text = "";
			passwordTextBox.Text = passwordempty;
			fullNameTextBox.Text = "";
			usernameTextBox.Focus();
			usernameTextBox.Enabled = true;
		}
	}
}