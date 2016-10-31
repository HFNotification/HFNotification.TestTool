using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;

namespace NotificationSender
{
	public partial class Form1 : Form
	{
		string[] reg_ids;
		int n;
		DataGridView Dat1 = new DataGridView();
		public Form1()
		{
			InitializeComponent();
		}

		private void Topic_CheckedChanged(object sender, EventArgs e)
		{
			tableLayoutPanel1.Visible = true;

		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			Topic.Visible = true;
			tableLayoutPanel3.Visible = true;
			tableLayoutPanel1.Visible = false;
			tableLayoutPanel2.Visible = false;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			int n = int.Parse(textBox4.Text);
			
			Dat1.RowCount = n;
			Dat1.ColumnCount = 1;
			Dat1.Columns[0].HeaderText = "Token ID";
			Dat1.Location = new Point(0, textBox6.Location.Y + textBox6.Height + 10);
			this.Controls.Add(Dat1);
			Dat1.Width = 500;
			// Dat1.Height = n * 30;
			Dat1.Columns[0].Width = 480;
			// Dat1.Rows[0].HeaderCell.Value = n.ToString();
			for (int i = 1; i <= n; i++)
			{
				Dat1.Rows[(i - 1)].HeaderCell.Value = i.ToString();
			}
			tableLayoutPanel5.Visible = false;
			tableLayoutPanel3.Visible = false;
			tableLayoutPanel1.Visible = false;
			tableLayoutPanel4.Visible = true;
			Topic.Visible = false;

			Dat1.Show();

		}

		private void button1_Click(object sender, EventArgs e)
		{
			tableLayoutPanel2.Visible = true;
			Topic.Visible = false;

			tableLayoutPanel3.Visible = false;
		}

		private void button6_Click(object sender, EventArgs e)
		{
			Program.sendToOne(textBox9.Text, textBox7.Text, textBox8.Text);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Program.sendToTopic(textBox2.Text, textBox1.Text, textBox3.Text);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			string[] tokens = new string[Dat1.RowCount-1];
			for (int i = 1; i <= Dat1.RowCount-1; i++)
			{
				Dat1.Rows[(i - 1)].HeaderCell.Value = i.ToString();
				tokens[i-1] = Dat1.Rows[i-1].Cells[0].Value.ToString();

			}
			reg_ids = tokens;
			Program.sendToFew(reg_ids, textBox6.Text, textBox5.Text);
		
		}
	}
}
