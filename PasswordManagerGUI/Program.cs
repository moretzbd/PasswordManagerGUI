using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Konscious.Security.Cryptography;
using static System.String;

namespace PasswordManagerGUI
{
    internal static class Program
    {
        private static byte[] _key;

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        internal static void Initialize()
        {
            //check for working directory, create if nonexistent
            if (!Directory.Exists(@".\Passwords"))
                Directory.CreateDirectory(@".\Passwords");

            //move to working directory
            Directory.SetCurrentDirectory(@".\Passwords");

            //get master password
            //exit if no password and cancel
            var master = "";
            while (IsNullOrEmpty(master))
                if (InputBox("Master Password", "Enter master password:", ref master) != DialogResult.OK)
                    Environment.Exit(0);

            //check for or generate salt per install
            if (!File.Exists("../DO_NOT_DELETE")) File.WriteAllText("../DO_NOT_DELETE", GenSalt());

            //generate key for AES
            _key = GenKey(master);

            //empty ram filled by GenKey
            GC.Collect();
        }

        internal static string[] ListFiles()
        {
            //list files in working directory
            var d = new DirectoryInfo(@".");
            var files = d.GetFiles("*.*");
            var fileNames = new string[files.Length];
            for (var i = 0; i < files.Length; i++) fileNames[i] = files[i].Name;

            return fileNames;
        }

        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        private static string GenSalt()
        {
            //characters allowed for salt generation
            var chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*".ToCharArray();
            //size of salt
            const int size = 128;

            //generate random bytes
            var data = new byte[4 * size];
            var random = new RNGCryptoServiceProvider();
            {
                random.GetBytes(data);
            }

            //turn random bytes into salt string using allowed characters
            var result = new StringBuilder(size);
            for (var i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }

        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        internal static string GenPass(int size)
        {
            //characters allowed for password generation
            var chars =
                "abcdefghijklmnopqrstuvwxyABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*".ToCharArray();

            //generate random bytes
            var data = new byte[4 * size];
            var random = new RNGCryptoServiceProvider();
            {
                random.GetBytes(data);
            }

            //turn random bytes into password string using allowed characters
            var result = new StringBuilder(size);
            for (var i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }

        private static byte[] GenKey(string master)
        {
            var salt = Encoding.UTF8.GetBytes(File.ReadAllText("../DO_NOT_DELETE"));

            //Argon2 implementation
            //ideally decide max threads/memory, then adjust iterations for acceptable time
            var argon2 = new Argon2i(Encoding.UTF8.GetBytes(master))
            {
                Salt = salt,
                DegreeOfParallelism = 8, // # threads
                Iterations = 6,
                MemorySize = 2048 * 1024 // 2 GiB
            };

            return argon2.GetBytes(16);
        } //end GenKey

        internal static void FileDelete(string filename)
        {
            if (File.Exists(filename))
            {
                if (MessageBox.Show(@"Delete " + filename + @"?", @"Confirmation", MessageBoxButtons.YesNo) ==
                    DialogResult.Yes)
                    File.Delete(filename);
            }
            else
            {
                MessageBox.Show(@"File does not exist.");
            }
        }

        internal static string Encryptor(string filename, string input, bool import = false, int all = 0)
        {
            if (!File.Exists(filename))
                try
                {
                    using (var fileStream = new FileStream(filename, FileMode.OpenOrCreate))
                    {
                        using (var aes = Aes.Create())
                        {
                            aes.Key = _key;

                            var iv = aes.IV;
                            fileStream.Write(iv, 0, iv.Length);

                            using (var cryptoStream = new CryptoStream(
                                fileStream,
                                aes.CreateEncryptor(),
                                CryptoStreamMode.Write))
                            {
                                using (var encryptWriter = new StreamWriter(cryptoStream))
                                {
                                    encryptWriter.Write(input);
                                }
                            }
                        }
                    }

                    return "File encrypted.";
                }
                catch (Exception)
                {
                    return "Encryption failed.";
                }

            //all == 0; not yet asked
            //all == 1; asked, user said no
            //all == 2; asked, user said yes

            //overwrite all if already declared
            if (all == 2)
            {
                File.Delete(filename);
                try
                {
                    using (var fileStream = new FileStream(filename, FileMode.OpenOrCreate))
                    {
                        using (var aes = Aes.Create())
                        {
                            aes.Key = _key;

                            var iv = aes.IV;
                            fileStream.Write(iv, 0, iv.Length);

                            using (var cryptoStream = new CryptoStream(
                                fileStream,
                                aes.CreateEncryptor(),
                                CryptoStreamMode.Write))
                            {
                                using (var encryptWriter = new StreamWriter(cryptoStream))
                                {
                                    encryptWriter.Write(input);
                                }
                            }
                        }
                    }

                    return "a";
                }
                catch (Exception)
                {
                    return "Encryption failed.";
                }
            }

            DialogResult result;

            //handle import overwrites
            if (import)
            {
                //ask to overwrite all
                if (all == 0)
                {
                    result = MessageBox.Show(@"Overwrite all?", @"File(s) Already Exists",
                        MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        File.Delete(filename);
                        try
                        {
                            using (var fileStream = new FileStream(filename, FileMode.OpenOrCreate))
                            {
                                using (var aes = Aes.Create())
                                {
                                    aes.Key = _key;

                                    var iv = aes.IV;
                                    fileStream.Write(iv, 0, iv.Length);

                                    using (var cryptoStream = new CryptoStream(
                                        fileStream,
                                        aes.CreateEncryptor(),
                                        CryptoStreamMode.Write))
                                    {
                                        using (var encryptWriter = new StreamWriter(cryptoStream))
                                        {
                                            encryptWriter.Write(input);
                                        }
                                    }
                                }
                            }

                            //communicates overwrite all to importButton_Click's logic
                            return "a";
                        }
                        catch (Exception)
                        {
                            return "Encryption failed.";
                        }
                    }

                    //communicates import cancellation to importButton_Click's logic
                    if (result == DialogResult.Cancel) return "c";
                } //end overwrite all check

                result = MessageBox.Show(@"Overwrite " + filename + @"?", @"File Already Exists",
                    MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Cancel) return "c";
            }
            //normal operation as a result of the save button
            else
            {
                result = MessageBox.Show(@"Overwrite " + filename + @"?", @"File Already Exists",
                    MessageBoxButtons.YesNo);
            }

            if (result == DialogResult.Yes)
            {
                File.Delete(filename);
                try
                {
                    using (var fileStream = new FileStream(filename, FileMode.OpenOrCreate))
                    {
                        using (var aes = Aes.Create())
                        {
                            aes.Key = _key;

                            var iv = aes.IV;
                            fileStream.Write(iv, 0, iv.Length);

                            using (var cryptoStream = new CryptoStream(
                                fileStream,
                                aes.CreateEncryptor(),
                                CryptoStreamMode.Write))
                            {
                                using (var encryptWriter = new StreamWriter(cryptoStream))
                                {
                                    encryptWriter.Write(input);
                                }
                            }
                        }
                    }

                    return "File encrypted.";
                }
                catch (Exception)
                {
                    return "Encryption failed.";
                }
            }

            return Empty;
        } //end Encryptor

        internal static string Decryptor(string filename)
        {
            //more helpful than "decryption failed" if file is removed by user/etc between refreshes
            if (!File.Exists(filename)) return "File no longer exists.";

            string result;
            try
            {
                using (var fileStream = new FileStream(filename, FileMode.Open))
                {
                    using (var aes = Aes.Create())
                    {
                        var iv = new byte[aes.IV.Length];
                        var numBytesToRead = aes.IV.Length;
                        var numBytesRead = 0;
                        while (numBytesToRead > 0)
                        {
                            var n = fileStream.Read(iv, numBytesRead, numBytesToRead);
                            if (n == 0) break;

                            numBytesRead += n;
                            numBytesToRead -= n;
                        }

                        using (var cryptoStream = new CryptoStream(
                            fileStream,
                            aes.CreateDecryptor(_key, iv),
                            CryptoStreamMode.Read))
                        {
                            using (var decryptReader = new StreamReader(cryptoStream))
                            {
                                result = decryptReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                result = "Decryption failed.";
            }

            return result;
        } //end Decryptor

        //repurposed from https://www.csharp-examples.net/inputbox/
        private static DialogResult InputBox(string title, string promptText, ref string value)
        {
            var form = new Form();
            var label = new Label();
            var textBox = new TextBox();
            var buttonOk = new Button();
            var buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = @"OK";
            buttonCancel.Text = @"Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;
            
            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);
            
            label.AutoSize = true;
            textBox.Anchor |= AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] {label, textBox, buttonOk, buttonCancel});
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            var dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        } //end InputBox
    }
}