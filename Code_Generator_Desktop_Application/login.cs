using Code_Generator_DApp.General_Classes;
using System;
using System.Windows.Forms;
using Microsoft.Win32;
namespace Code_Generator_DApp
{
    public partial class login : Form
    {
        string _keyPath = @"HKEY_CURRENT_USER\SOFTWARE\Code_Generator";
        public login()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _ErrorLogin(string message)
        {
            MessageBox.Show("Error Message : " +  message);
        }
        public bool WriteToRegistry(string userID, string password)
        {
            try
            {

                Registry.SetValue(_keyPath, "userID", userID, RegistryValueKind.String);
                Registry.SetValue(_keyPath, "password", password, RegistryValueKind.String);
                return true;
            }
            catch(Exception ex)
            { 
                _ErrorLogin(ex.Message);
                return false; 
            }
            
        }
        private bool _DeleteDataFromWRegisty()
        {
            try
            {
                using (RegistryKey BaseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey key = BaseKey.OpenSubKey(@"SOFTWARE\Code_Generator",true))
                    {
                        key.DeleteValue("userID");
                        key.DeleteValue("password");
                        return true;
                    }
                }
            }
            catch(UnauthorizedAccessException ex)
            { return false; }
            catch(Exception) { return false; }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txbUserID.Text) && !string.IsNullOrWhiteSpace(txbPassword.Text))
            {
                string userID = txbUserID.Text;
                string password = txbPassword.Text;

                if(cbRememberMe.Checked)
                {
                    if (WriteToRegistry(userID, password))
                    {
                        frmShowAllDatabase frm = new frmShowAllDatabase();
                        this.Hide();
                        frm.ShowDialog();
                        this.Close();
                    }
                    else
                        MessageBox.Show("Failed");
                }
                else
                {
                    if (_DeleteDataFromWRegisty())
                        MessageBox.Show("The Data on Registry was deleted successfully");
                    else
                        MessageBox.Show("Failed");
                }

                clsCurrentUser.ConnectionInfo.userID = userID;
                clsCurrentUser.ConnectionInfo.password = password;
            }
        }
        private void LoadDataFromRegistry()
        {
            string userID = Registry.GetValue(_keyPath, "userID",null) as string;
            string password = Registry.GetValue(_keyPath, "password",null) as string;
            
            if(userID != null && password != null)
            {
                clsCurrentUser.ConnectionInfo.userID = userID;
                clsCurrentUser.ConnectionInfo.password = password;

                txbUserID.Text = userID;
                txbPassword.Text = password;
                cbRememberMe.Checked = true;
            }
        }
        private void login_Load(object sender, EventArgs e)
        {
            LoadDataFromRegistry();
        }
    }
}
