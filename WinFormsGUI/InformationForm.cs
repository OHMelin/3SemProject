using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyBooking.WFORM
{
    public partial class InformationForm : Form
    {
        int result;
        public InformationForm()
        {
            InitializeComponent();
            AcceptBtn.Click += (_, _) => Accept();
            CancelBtn.Click += (_, _) => Cancel();
        }

        public void ShowInformationForm(string message)
        {
            MessageTxt.Text = message;
            this.ShowDialog();
        }

        public void Accept()
        {
            this.Dispose();
        }

        public void Cancel()
        {
            this.Dispose();
        }
    }
}
