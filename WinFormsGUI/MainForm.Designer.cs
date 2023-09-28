namespace FlyBooking.WFORM
{
	partial class MainForm
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
            this.LoginPnl = new System.Windows.Forms.Panel();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.UsernameTxt = new System.Windows.Forms.TextBox();
            this.PasswordLbl = new System.Windows.Forms.Label();
            this.UsernameLbl = new System.Windows.Forms.Label();
            this.LoginLbl = new System.Windows.Forms.Label();
            this.FlightLst = new System.Windows.Forms.ListBox();
            this.MainPnl = new System.Windows.Forms.Panel();
            this.ButtonPnl = new System.Windows.Forms.Panel();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.CreateNewbtn = new System.Windows.Forms.Button();
            this.FlightInfoPnl = new System.Windows.Forms.Panel();
            this.FlightPriceTxt = new System.Windows.Forms.TextBox();
            this.DestinationLbl = new System.Windows.Forms.Label();
            this.PlaneLbl = new System.Windows.Forms.Label();
            this.FlightPriceLbl = new System.Windows.Forms.Label();
            this.Arrival = new System.Windows.Forms.Label();
            this.DepartureLbl = new System.Windows.Forms.Label();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.DestinationCb = new System.Windows.Forms.ComboBox();
            this.PlaneCb = new System.Windows.Forms.ComboBox();
            this.ArrivalDt = new System.Windows.Forms.DateTimePicker();
            this.DepartureDt = new System.Windows.Forms.DateTimePicker();
            this.BackBtn = new System.Windows.Forms.Button();
            this.FlightIdLbl = new System.Windows.Forms.Label();
            this.LoginPnl.SuspendLayout();
            this.MainPnl.SuspendLayout();
            this.ButtonPnl.SuspendLayout();
            this.FlightInfoPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginPnl
            // 
            this.LoginPnl.Controls.Add(this.LoginBtn);
            this.LoginPnl.Controls.Add(this.PasswordTxt);
            this.LoginPnl.Controls.Add(this.UsernameTxt);
            this.LoginPnl.Controls.Add(this.PasswordLbl);
            this.LoginPnl.Controls.Add(this.UsernameLbl);
            this.LoginPnl.Controls.Add(this.LoginLbl);
            this.LoginPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginPnl.Enabled = false;
            this.LoginPnl.Location = new System.Drawing.Point(0, 0);
            this.LoginPnl.Name = "LoginPnl";
            this.LoginPnl.Size = new System.Drawing.Size(1264, 681);
            this.LoginPnl.TabIndex = 0;
            this.LoginPnl.Visible = false;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoginBtn.Location = new System.Drawing.Point(637, 377);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(102, 53);
            this.LoginBtn.TabIndex = 5;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordTxt.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PasswordTxt.Location = new System.Drawing.Point(540, 328);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.Size = new System.Drawing.Size(199, 31);
            this.PasswordTxt.TabIndex = 4;
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UsernameTxt.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UsernameTxt.Location = new System.Drawing.Point(540, 235);
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.Size = new System.Drawing.Size(199, 31);
            this.UsernameTxt.TabIndex = 3;
            // 
            // PasswordLbl
            // 
            this.PasswordLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordLbl.AutoSize = true;
            this.PasswordLbl.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PasswordLbl.Location = new System.Drawing.Point(540, 300);
            this.PasswordLbl.Name = "PasswordLbl";
            this.PasswordLbl.Size = new System.Drawing.Size(96, 25);
            this.PasswordLbl.TabIndex = 2;
            this.PasswordLbl.Text = "Password: ";
            // 
            // UsernameLbl
            // 
            this.UsernameLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UsernameLbl.AutoSize = true;
            this.UsernameLbl.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UsernameLbl.Location = new System.Drawing.Point(536, 207);
            this.UsernameLbl.Name = "UsernameLbl";
            this.UsernameLbl.Size = new System.Drawing.Size(100, 25);
            this.UsernameLbl.TabIndex = 1;
            this.UsernameLbl.Text = "Username: ";
            // 
            // LoginLbl
            // 
            this.LoginLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginLbl.AutoSize = true;
            this.LoginLbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoginLbl.Location = new System.Drawing.Point(597, 129);
            this.LoginLbl.Name = "LoginLbl";
            this.LoginLbl.Size = new System.Drawing.Size(84, 37);
            this.LoginLbl.TabIndex = 0;
            this.LoginLbl.Text = "Login";
            this.LoginLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FlightLst
            // 
            this.FlightLst.Dock = System.Windows.Forms.DockStyle.Right;
            this.FlightLst.FormattingEnabled = true;
            this.FlightLst.ItemHeight = 23;
            this.FlightLst.Location = new System.Drawing.Point(209, 0);
            this.FlightLst.Name = "FlightLst";
            this.FlightLst.Size = new System.Drawing.Size(1055, 681);
            this.FlightLst.TabIndex = 1;
            // 
            // MainPnl
            // 
            this.MainPnl.BackColor = System.Drawing.SystemColors.Control;
            this.MainPnl.Controls.Add(this.ButtonPnl);
            this.MainPnl.Controls.Add(this.FlightLst);
            this.MainPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPnl.Enabled = false;
            this.MainPnl.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainPnl.Location = new System.Drawing.Point(0, 0);
            this.MainPnl.Name = "MainPnl";
            this.MainPnl.Size = new System.Drawing.Size(1264, 681);
            this.MainPnl.TabIndex = 6;
            this.MainPnl.Visible = false;
            // 
            // ButtonPnl
            // 
            this.ButtonPnl.Controls.Add(this.DeleteBtn);
            this.ButtonPnl.Controls.Add(this.EditBtn);
            this.ButtonPnl.Controls.Add(this.CreateNewbtn);
            this.ButtonPnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonPnl.Location = new System.Drawing.Point(0, 0);
            this.ButtonPnl.Name = "ButtonPnl";
            this.ButtonPnl.Size = new System.Drawing.Size(200, 681);
            this.ButtonPnl.TabIndex = 2;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Enabled = false;
            this.DeleteBtn.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeleteBtn.Location = new System.Drawing.Point(41, 125);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(100, 35);
            this.DeleteBtn.TabIndex = 1;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // EditBtn
            // 
            this.EditBtn.Enabled = false;
            this.EditBtn.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EditBtn.Location = new System.Drawing.Point(41, 84);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(100, 35);
            this.EditBtn.TabIndex = 2;
            this.EditBtn.Text = "Edit";
            this.EditBtn.UseVisualStyleBackColor = true;
            // 
            // CreateNewbtn
            // 
            this.CreateNewbtn.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreateNewbtn.Location = new System.Drawing.Point(41, 43);
            this.CreateNewbtn.Name = "CreateNewbtn";
            this.CreateNewbtn.Size = new System.Drawing.Size(100, 35);
            this.CreateNewbtn.TabIndex = 3;
            this.CreateNewbtn.Text = "New";
            this.CreateNewbtn.UseVisualStyleBackColor = true;
            // 
            // FlightInfoPnl
            // 
            this.FlightInfoPnl.Controls.Add(this.FlightIdLbl);
            this.FlightInfoPnl.Controls.Add(this.FlightPriceTxt);
            this.FlightInfoPnl.Controls.Add(this.DestinationLbl);
            this.FlightInfoPnl.Controls.Add(this.PlaneLbl);
            this.FlightInfoPnl.Controls.Add(this.FlightPriceLbl);
            this.FlightInfoPnl.Controls.Add(this.Arrival);
            this.FlightInfoPnl.Controls.Add(this.DepartureLbl);
            this.FlightInfoPnl.Controls.Add(this.SubmitBtn);
            this.FlightInfoPnl.Controls.Add(this.DestinationCb);
            this.FlightInfoPnl.Controls.Add(this.PlaneCb);
            this.FlightInfoPnl.Controls.Add(this.ArrivalDt);
            this.FlightInfoPnl.Controls.Add(this.DepartureDt);
            this.FlightInfoPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlightInfoPnl.Enabled = false;
            this.FlightInfoPnl.Location = new System.Drawing.Point(0, 0);
            this.FlightInfoPnl.Name = "FlightInfoPnl";
            this.FlightInfoPnl.Size = new System.Drawing.Size(1264, 681);
            this.FlightInfoPnl.TabIndex = 3;
            this.FlightInfoPnl.UseWaitCursor = true;
            this.FlightInfoPnl.Visible = false;
            // 
            // FlightPriceTxt
            // 
            this.FlightPriceTxt.Location = new System.Drawing.Point(448, 348);
            this.FlightPriceTxt.Name = "FlightPriceTxt";
            this.FlightPriceTxt.Size = new System.Drawing.Size(202, 23);
            this.FlightPriceTxt.TabIndex = 9;
            this.FlightPriceTxt.UseWaitCursor = true;
            // 
            // DestinationLbl
            // 
            this.DestinationLbl.AutoSize = true;
            this.DestinationLbl.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DestinationLbl.Location = new System.Drawing.Point(691, 241);
            this.DestinationLbl.Name = "DestinationLbl";
            this.DestinationLbl.Size = new System.Drawing.Size(102, 25);
            this.DestinationLbl.TabIndex = 8;
            this.DestinationLbl.Text = "Destination";
            this.DestinationLbl.UseWaitCursor = true;
            // 
            // PlaneLbl
            // 
            this.PlaneLbl.AutoSize = true;
            this.PlaneLbl.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlaneLbl.Location = new System.Drawing.Point(691, 141);
            this.PlaneLbl.Name = "PlaneLbl";
            this.PlaneLbl.Size = new System.Drawing.Size(54, 25);
            this.PlaneLbl.TabIndex = 7;
            this.PlaneLbl.Text = "Plane";
            this.PlaneLbl.UseWaitCursor = true;
            // 
            // FlightPriceLbl
            // 
            this.FlightPriceLbl.AutoSize = true;
            this.FlightPriceLbl.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FlightPriceLbl.Location = new System.Drawing.Point(450, 320);
            this.FlightPriceLbl.Name = "FlightPriceLbl";
            this.FlightPriceLbl.Size = new System.Drawing.Size(58, 25);
            this.FlightPriceLbl.TabIndex = 6;
            this.FlightPriceLbl.Text = "Price: ";
            this.FlightPriceLbl.UseWaitCursor = true;
            // 
            // Arrival
            // 
            this.Arrival.AutoSize = true;
            this.Arrival.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Arrival.Location = new System.Drawing.Point(450, 242);
            this.Arrival.Name = "Arrival";
            this.Arrival.Size = new System.Drawing.Size(66, 25);
            this.Arrival.TabIndex = 6;
            this.Arrival.Text = "Arrival:";
            this.Arrival.UseWaitCursor = true;
            // 
            // DepartureLbl
            // 
            this.DepartureLbl.AutoSize = true;
            this.DepartureLbl.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DepartureLbl.Location = new System.Drawing.Point(450, 141);
            this.DepartureLbl.Name = "DepartureLbl";
            this.DepartureLbl.Size = new System.Drawing.Size(91, 25);
            this.DepartureLbl.TabIndex = 5;
            this.DepartureLbl.Text = "Departure";
            this.DepartureLbl.UseWaitCursor = true;
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SubmitBtn.Location = new System.Drawing.Point(1029, 565);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(94, 41);
            this.SubmitBtn.TabIndex = 4;
            this.SubmitBtn.Text = "Create";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.UseWaitCursor = true;
            // 
            // DestinationCb
            // 
            this.DestinationCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DestinationCb.FormattingEnabled = true;
            this.DestinationCb.Location = new System.Drawing.Point(691, 272);
            this.DestinationCb.Name = "DestinationCb";
            this.DestinationCb.Size = new System.Drawing.Size(121, 23);
            this.DestinationCb.TabIndex = 3;
            this.DestinationCb.UseWaitCursor = true;
            // 
            // PlaneCb
            // 
            this.PlaneCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlaneCb.FormattingEnabled = true;
            this.PlaneCb.Location = new System.Drawing.Point(691, 179);
            this.PlaneCb.Name = "PlaneCb";
            this.PlaneCb.Size = new System.Drawing.Size(121, 23);
            this.PlaneCb.TabIndex = 2;
            this.PlaneCb.UseWaitCursor = true;
            // 
            // ArrivalDt
            // 
            this.ArrivalDt.Location = new System.Drawing.Point(450, 272);
            this.ArrivalDt.Name = "ArrivalDt";
            this.ArrivalDt.Size = new System.Drawing.Size(200, 23);
            this.ArrivalDt.TabIndex = 1;
            this.ArrivalDt.UseWaitCursor = true;
            // 
            // DepartureDt
            // 
            this.DepartureDt.Location = new System.Drawing.Point(450, 179);
            this.DepartureDt.Name = "DepartureDt";
            this.DepartureDt.Size = new System.Drawing.Size(200, 23);
            this.DepartureDt.TabIndex = 0;
            this.DepartureDt.UseWaitCursor = true;
            // 
            // BackBtn
            // 
            this.BackBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackBtn.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BackBtn.Location = new System.Drawing.Point(15, 565);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(94, 41);
            this.BackBtn.TabIndex = 7;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.UseWaitCursor = true;
            // 
            // FlightIdLbl
            // 
            this.FlightIdLbl.AutoSize = true;
            this.FlightIdLbl.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FlightIdLbl.Location = new System.Drawing.Point(450, 90);
            this.FlightIdLbl.Name = "FlightIdLbl";
            this.FlightIdLbl.Size = new System.Drawing.Size(83, 25);
            this.FlightIdLbl.TabIndex = 10;
            this.FlightIdLbl.Text = "Flight ID:";
            this.FlightIdLbl.UseWaitCursor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.FlightInfoPnl);
            this.Controls.Add(this.MainPnl);
            this.Controls.Add(this.LoginPnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Flight Booking";
            this.LoginPnl.ResumeLayout(false);
            this.LoginPnl.PerformLayout();
            this.MainPnl.ResumeLayout(false);
            this.ButtonPnl.ResumeLayout(false);
            this.FlightInfoPnl.ResumeLayout(false);
            this.FlightInfoPnl.PerformLayout();
            this.ResumeLayout(false);

		}

        #endregion

        private Panel LoginPnl;
        private TextBox PasswordTxt;
        private TextBox UsernameTxt;
        private Label PasswordLbl;
        private Label UsernameLbl;
        private Label LoginLbl;
        private Button LoginBtn;
        private ListBox FlightLst;
        private Panel MainPnl;
        private Panel ButtonPnl;
        private Button DeleteBtn;
        private Button EditBtn;
        private Button CreateNewbtn;
        private Panel FlightInfoPnl;
        private Label Arrival;
        private Label DepartureLbl;
        private Button SubmitBtn;
        private ComboBox DestinationCb;
        private ComboBox PlaneCb;
        private DateTimePicker ArrivalDt;
        private DateTimePicker DepartureDt;
        private Button BackBtn;
        private Label DestinationLbl;
        private Label PlaneLbl;
        private TextBox FlightPriceTxt;
        private Label FlightPriceLbl;
        private Label FlightIdLbl;
    }
}