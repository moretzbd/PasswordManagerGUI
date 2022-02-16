using System.Windows.Forms;

namespace PasswordManagerGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.copyLButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.genButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.delButton = new System.Windows.Forms.Button();
            this.lengthTextBox = new System.Windows.Forms.TextBox();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.refrButton = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.copyLabel = new System.Windows.Forms.Label();
            this.loginLabel = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.importButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.copyPButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.searchLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // copyLButton
            // 
            this.copyLButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copyLButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.copyLButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyLButton.Location = new System.Drawing.Point(645, 104);
            this.copyLButton.Name = "copyLButton";
            this.copyLButton.Size = new System.Drawing.Size(146, 43);
            this.copyLButton.TabIndex = 7;
            this.copyLButton.Text = "Copy Login";
            this.copyLButton.UseVisualStyleBackColor = true;
            this.copyLButton.Click += new System.EventHandler(this.copyLButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nameLabel.Location = new System.Drawing.Point(7, 9);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.nameLabel.MaximumSize = new System.Drawing.Size(132, 31);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(132, 31);
            this.nameLabel.TabIndex = 16;
            this.nameLabel.Text = "Name";
            // 
            // genButton
            // 
            this.genButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.genButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genButton.Location = new System.Drawing.Point(645, 37);
            this.genButton.Name = "genButton";
            this.genButton.Size = new System.Drawing.Size(146, 43);
            this.genButton.TabIndex = 6;
            this.genButton.Text = "Generate";
            this.genButton.UseVisualStyleBackColor = true;
            this.genButton.Click += new System.EventHandler(this.genButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(645, 287);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(146, 43);
            this.clearButton.TabIndex = 9;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(645, 336);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(146, 43);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.passwordLabel.Location = new System.Drawing.Point(7, 143);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(0);
            this.passwordLabel.MaximumSize = new System.Drawing.Size(132, 31);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(132, 31);
            this.passwordLabel.TabIndex = 18;
            this.passwordLabel.Text = "Password";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nameTextBox.Location = new System.Drawing.Point(12, 43);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(469, 30);
            this.nameTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.passwordTextBox.Location = new System.Drawing.Point(12, 177);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(620, 30);
            this.passwordTextBox.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(12, 287);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(620, 404);
            this.listBox1.TabIndex = 5;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // delButton
            // 
            this.delButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delButton.Location = new System.Drawing.Point(645, 385);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(146, 43);
            this.delButton.TabIndex = 11;
            this.delButton.Text = "Delete";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // lengthTextBox
            // 
            this.lengthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lengthTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.lengthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lengthTextBox.Location = new System.Drawing.Point(588, 43);
            this.lengthTextBox.Name = "lengthTextBox";
            this.lengthTextBox.Size = new System.Drawing.Size(44, 30);
            this.lengthTextBox.TabIndex = 3;
            this.lengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lengthTextBox_KeyPress);
            // 
            // lengthLabel
            // 
            this.lengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lengthLabel.Location = new System.Drawing.Point(487, 43);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(95, 31);
            this.lengthLabel.TabIndex = 20;
            this.lengthLabel.Text = "Length:";
            // 
            // refrButton
            // 
            this.refrButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refrButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refrButton.Location = new System.Drawing.Point(486, 238);
            this.refrButton.Name = "refrButton";
            this.refrButton.Size = new System.Drawing.Size(146, 43);
            this.refrButton.TabIndex = 15;
            this.refrButton.Text = "Refresh";
            this.refrButton.UseVisualStyleBackColor = true;
            this.refrButton.Click += new System.EventHandler(this.refrButton_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(641, 704);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(163, 20);
            this.versionLabel.TabIndex = 22;
            this.versionLabel.Text = "Version: {0}.{1}.{2}.{3} ";
            // 
            // copyLabel
            // 
            this.copyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.copyLabel.AutoSize = true;
            this.copyLabel.Location = new System.Drawing.Point(12, 704);
            this.copyLabel.Name = "copyLabel";
            this.copyLabel.Size = new System.Drawing.Size(258, 20);
            this.copyLabel.TabIndex = 21;
            this.copyLabel.Text = "Copyright © Benjamin Moretz  2021";
            // 
            // loginLabel
            // 
            this.loginLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.loginLabel.Location = new System.Drawing.Point(7, 76);
            this.loginLabel.Margin = new System.Windows.Forms.Padding(0);
            this.loginLabel.MaximumSize = new System.Drawing.Size(132, 31);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(132, 31);
            this.loginLabel.TabIndex = 17;
            this.loginLabel.Text = "Login";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.loginTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.loginTextBox.Location = new System.Drawing.Point(12, 110);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(620, 30);
            this.loginTextBox.TabIndex = 1;
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importButton.Location = new System.Drawing.Point(645, 599);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(146, 43);
            this.importButton.TabIndex = 13;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportButton.Location = new System.Drawing.Point(645, 648);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(146, 43);
            this.exportButton.TabIndex = 14;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // copyPButton
            // 
            this.copyPButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copyPButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.copyPButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyPButton.Location = new System.Drawing.Point(645, 171);
            this.copyPButton.Name = "copyPButton";
            this.copyPButton.Size = new System.Drawing.Size(146, 43);
            this.copyPButton.TabIndex = 8;
            this.copyPButton.Text = "Copy PW";
            this.copyPButton.UseVisualStyleBackColor = true;
            this.copyPButton.Click += new System.EventHandler(this.copyPButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpButton.Location = new System.Drawing.Point(645, 492);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(146, 43);
            this.helpButton.TabIndex = 12;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // searchLabel
            // 
            this.searchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.searchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.searchLabel.Location = new System.Drawing.Point(7, 210);
            this.searchLabel.Margin = new System.Windows.Forms.Padding(0);
            this.searchLabel.MaximumSize = new System.Drawing.Size(132, 31);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(132, 31);
            this.searchLabel.TabIndex = 19;
            this.searchLabel.Text = "Search:";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.searchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.searchTextBox.Location = new System.Drawing.Point(12, 244);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(469, 30);
            this.searchTextBox.TabIndex = 4;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            this.searchTextBox.Enter += new System.EventHandler(this.searchTextBox_Enter);
            this.searchTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.searchTextBox_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(803, 729);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.copyPButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.copyLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.refrButton);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.lengthTextBox);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.genButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.copyLButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(825, 785);
            this.Name = "Form1";
            this.Text = "Password Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button copyLButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button genButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label passwordLabel;
        private TextBox nameTextBox;
        private TextBox passwordTextBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button delButton;
        private TextBox lengthTextBox;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Button refrButton;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label copyLabel;
        private System.Windows.Forms.Label loginLabel;
        private TextBox loginTextBox;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button copyPButton;
        private Button helpButton;
        private Label searchLabel;
        private TextBox searchTextBox;
    }
}

