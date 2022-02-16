using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using CsvHelper;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace PasswordManagerGUI
{
    [SuppressMessage("ReSharper", "ForCanBeConvertedToForeach")]
    public partial class Form1 : Form
    {
        private readonly List<string> _items = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        //copy login
        private void copyLButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(loginTextBox.Text);
        }

        //copy password
        private void copyPButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(passwordTextBox.Text);
        }

        //generate
        private void genButton_Click(object sender, EventArgs e)
        {
            //pass pw length to GenPass
            if (int.TryParse(lengthTextBox.Text, out var x))
                passwordTextBox.Text = Program.GenPass(x);
        }

        //delete
        private void delButton_Click(object sender, EventArgs e)
        {
            Program.FileDelete(nameTextBox.Text);

            //refresh list
            listBox1.Items.Clear();
            _items.Clear();
            var fileList = Program.ListFiles();
            for (var i = 0; i < fileList.Length; i++)
            {
                listBox1.Items.Add(fileList[i]);
                _items.Add(fileList[i]);
            }
        }

        //clear
        private void clearButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "";
            loginTextBox.Text = "";
            passwordTextBox.Text = "";
        }

        //save
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrEmpty(passwordTextBox.Text) &&
                !string.IsNullOrEmpty(loginTextBox.Text))
            {
                if (!nameTextBox.Text.Contains(","))
                {
                    if (!loginTextBox.Text.Contains(","))
                    {
                        if (!passwordTextBox.Text.Contains(","))
                        {
                            var output = Program.Encryptor(nameTextBox.Text,
                                loginTextBox.Text + "," + passwordTextBox.Text);
                            //roundabout way of not updating password box if user chose no with overwrite dialog
                            if (!string.IsNullOrEmpty(output))
                                passwordTextBox.Text = output;
                        }
                        else
                        {
                            MessageBox.Show(@"Password cannot contain commas.", @"Error!", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Login cannot contain commas.", @"Error!", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show(@"Name cannot contain commas.", @"Error!", MessageBoxButtons.OK);
                }
            }

            //refresh list
            listBox1.Items.Clear();
            _items.Clear();
            var fileList = Program.ListFiles();
            for (var i = 0; i < fileList.Length; i++)
            {
                listBox1.Items.Add(fileList[i]);
                _items.Add(fileList[i]);
            }
        }

        //manual refresh
        // ReSharper disable once IdentifierTypo
        private void refrButton_Click(object sender, EventArgs e)
        {
            //refresh list
            listBox1.Items.Clear();
            _items.Clear();
            var fileList = Program.ListFiles();
            for (var i = 0; i < fileList.Length; i++)
            {
                listBox1.Items.Add(fileList[i]);
                _items.Add(fileList[i]);
            }
        }

        //import csv
        private void importButton_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = ".";
                openFileDialog.Filter = @"CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                try
                {
                    using (var reader = new StreamReader(openFileDialog.FileName))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Read();
                        csv.ReadHeader();

                        //run once for user input
                        csv.Read();
                        var output = Program.Encryptor(csv.GetField("Name"),
                            csv.GetField("Login") + "," + csv.GetField("Password"), true);

                        if (output == "a")
                            //overwrite all
                            while (csv.Read())
                                Program.Encryptor(csv.GetField("Name"),
                                    csv.GetField("Login") + "," + csv.GetField("Password"), true, 2);
                        else
                            //check for cancel
                            while (csv.Read() && output != "c")
                                output = Program.Encryptor(csv.GetField("Name"),
                                    csv.GetField("Login") + "," + csv.GetField("Password"), true, 1);
                    }

                    //refresh list
                    listBox1.Items.Clear();
                    _items.Clear();
                    var fileList = Program.ListFiles();
                    for (var i = 0; i < fileList.Length; i++)
                    {
                        listBox1.Items.Add(fileList[i]);
                        _items.Add(fileList[i]);
                    }
                }
                catch
                {
                    MessageBox.Show(@"CSV file may be formatted incorrectly", @"Failed to Import",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //export csv
        private void exportButton_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog1 = new FolderBrowserDialog();

            // Show the FolderBrowserDialog.
            var result = folderBrowserDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            var fullPath = folderBrowserDialog1.SelectedPath + "\\" + "PMExport " + DateTime.Today.Month + "-" +
                           DateTime.Today.Day + "-" + DateTime.Today.Year + ".csv";
            if (!File.Exists(fullPath))
            {
                try
                {
                    var fileList = Program.ListFiles();

                    using (var fileStream = new FileStream(fullPath, FileMode.OpenOrCreate))
                    {
                        using (var outWriter = new StreamWriter(fileStream))
                        {
                            outWriter.WriteLine("Name,Login,Password");
                            for (var i = 0; i < fileList.Length; i++)
                                outWriter.WriteLine(fileList[i] + "," + Program.Decryptor(fileList[i]));
                        }
                    }
                }
                catch
                {
                    MessageBox.Show(@"Could not write file", @"Failed to Export",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (MessageBox.Show(@"Overwrite?", @"File Already Exists", MessageBoxButtons.YesNo) !=
                    DialogResult.Yes) return;
                File.Delete(fullPath);
                try
                {
                    var fileList = Program.ListFiles();

                    using (var fileStream = new FileStream(fullPath, FileMode.OpenOrCreate))
                    {
                        using (var outWriter = new StreamWriter(fileStream))
                        {
                            outWriter.WriteLine("Name,Login,Password");
                            for (var i = 0; i < fileList.Length; i++)
                                outWriter.WriteLine(fileList[i] + "," + Program.Decryptor(fileList[i]));
                        }
                    }
                }
                catch
                {
                    MessageBox.Show(@"Could not write file", @"Failed to Export",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //list of password files/names
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            nameTextBox.Text = listBox1.SelectedItem.ToString();
            try
            {
                var result = Program.Decryptor(listBox1.SelectedItem.ToString()).Split(',');

                //login
                loginTextBox.Text = result[0];
                //password
                passwordTextBox.Text = result[1];
            }
            catch
            {
                passwordTextBox.Text = @"Failed to delimit.";
            }
        }

        //allow only numbers and backspace for pw length
        private void lengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8);
        }

        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            searchTextBox.SelectAll();
        }

        private void searchTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            searchTextBox.SelectAll();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            for (var i = 0; i < _items.Count; i++)
            {
                var str = _items[i];
                if (str.StartsWith(searchTextBox.Text, StringComparison.CurrentCultureIgnoreCase))
                    listBox1.Items.Add(str);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //check for salt, collect master pw, generate key
            Program.Initialize();

            //limit pw gen length
            lengthTextBox.MaxLength = 3;

            //default pw gen length
            lengthTextBox.Text = @"24";

            //display version info
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            versionLabel.Text = string.Format(versionLabel.Text, version.Major, version.Minor, version.Build,
                version.Revision);

            //populate pw files/names
            var fileList = Program.ListFiles();
            for (var i = 0; i < fileList.Length; i++)
            {
                listBox1.Items.Add(fileList[i]);
                _items.Add(fileList[i]);
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            const string helpString = "[Generate]" +
                                      "\n  -Generates random password of set length with characters:" +
                                      "\n   a-z A-Z 0-9 !@#$%^&*" +
                                      "\n\n[Copy Login/Password]" +
                                      "\n  -Copies current login or password to the clipboard" +
                                      "\n\n[Clear]" +
                                      "\n  -Clears name, login, and password fields" +
                                      "\n\n[Save]" +
                                      "\n  -Encrypts and saves current login/password with name as the filename" +
                                      "\n\n[Delete]" +
                                      "\n  -Deletes currently selected entry (and associated file)" +
                                      "\n\n[Import/Export]" +
                                      "\n  -Imports/Exports a CSV file formatted as \"Name,Login,Password\"";
            MessageBox.Show(helpString, @"Help");
        }
    }
}