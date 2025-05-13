namespace NOSDoTNetWinFormApp
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_cancel = new Button();
            txt_username = new TextBox();
            txt_password = new TextBox();
            lbl_username = new Label();
            lbl_password = new Label();
            btn_login = new Button();
            SuspendLayout();
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(38, 215);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(349, 46);
            btn_cancel.TabIndex = 0;
            btn_cancel.Text = "&Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += but_cancel_Click;
            // 
            // txt_username
            // 
            txt_username.Location = new Point(38, 49);
            txt_username.Name = "txt_username";
            txt_username.Size = new Size(686, 39);
            txt_username.TabIndex = 1;
            // 
            // txt_password
            // 
            txt_password.Location = new Point(38, 150);
            txt_password.Name = "txt_password";
            txt_password.Size = new Size(686, 39);
            txt_password.TabIndex = 2;
            txt_password.UseSystemPasswordChar = true;
            // 
            // lbl_username
            // 
            lbl_username.AutoSize = true;
            lbl_username.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_username.Location = new Point(38, 17);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(120, 29);
            lbl_username.TabIndex = 3;
            lbl_username.Text = "Username";
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_password.Location = new Point(38, 115);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(114, 29);
            lbl_password.TabIndex = 4;
            lbl_password.Text = "Password";
            // 
            // btn_login
            // 
            btn_login.BackColor = Color.Teal;
            btn_login.ForeColor = SystemColors.ButtonHighlight;
            btn_login.Location = new Point(393, 215);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(331, 46);
            btn_login.TabIndex = 5;
            btn_login.Text = "&Login";
            btn_login.UseVisualStyleBackColor = false;
            btn_login.Click += btn_login_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_login);
            Controls.Add(lbl_password);
            Controls.Add(lbl_username);
            Controls.Add(txt_password);
            Controls.Add(txt_username);
            Controls.Add(btn_cancel);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_cancel;
        private TextBox txt_username;
        private TextBox txt_password;
        private Label lbl_username;
        private Label lbl_password;
        private Button btn_login;
    }
}
