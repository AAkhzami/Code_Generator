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
        public bool WriteToRegistry(string userID, string password, string location)
        {
            try
            {

                Registry.SetValue(_keyPath, "userID", userID, RegistryValueKind.String);
                Registry.SetValue(_keyPath, "password", password, RegistryValueKind.String);
                Registry.SetValue(_keyPath, "location", location, RegistryValueKind.String);
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
                string location = txbServerLocation.Text.Trim();
                if(cbRememberMe.Checked)
                {
                    if (WriteToRegistry(userID, password, location))
                    {
                        frmCodeGeneratorewindows frm = new frmCodeGeneratorewindows();
                        MessageBox.Show("Make sure that this information will be used to generate code, especially in connection information code with the database.",
                            "Inform", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                clsCurrentUser.connectionInfo.userName = userID;
                clsCurrentUser.connectionInfo.password = password;
            }
        }
        private void LoadDataFromRegistry()
        {
            string userID = Registry.GetValue(_keyPath, "userID",null) as string;
            string password = Registry.GetValue(_keyPath, "password",null) as string;
            string location = Registry.GetValue(_keyPath, "location",null) as string;

            if (userID != null && password != null && location != null)
            {
                clsCurrentUser.connectionInfo.userName = userID;
                clsCurrentUser.connectionInfo.password = password;
                clsCurrentUser.connectionInfo.location = location;

                txbUserID.Text = userID;
                txbPassword.Text = password;
                txbServerLocation.Text = location;

                cbRememberMe.Checked = true;
            }
        }
        private void login_Load(object sender, EventArgs e)
        {
            LoadDataFromRegistry();
        }
    }
}
