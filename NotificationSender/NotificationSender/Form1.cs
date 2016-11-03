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
		DataGridView Dat1 = new DataGridView();
		public Form1()
		{
			InitializeComponent();
		}
		private void button2_Click(object sender, EventArgs e)
		{
			Topic.Visible = true;
			tableLayoutCountAddressee.Visible = true;
			tableLayoutToTopic.Visible = false;
			tableLayoutToOne.Visible = false;
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
			Dat1.Columns[0].Width = 480;
			for (int i = 1; i <= n; i++)
			{
				Dat1.Rows[(i - 1)].HeaderCell.Value = i.ToString();
			}
			tableLayoutStart.Visible = false;
			tableLayoutCountAddressee.Visible = false;
			tableLayoutToTopic.Visible = false;
			tableLayoutForFew.Visible = true;
			Topic.Visible = false;

			Dat1.Show();

		}

		private void button1_Click(object sender, EventArgs e)
		{
			tableLayoutToOne.Visible = true;
			Topic.Visible = false;

			tableLayoutCountAddressee.Visible = false;
		}

		private void button6_Click(object sender, EventArgs e)
		{
			Program.SendToOne(textBox9.Text, textBox7.Text, textBox8.Text);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Program.SendToTopic(textBox2.Text, textBox1.Text, textBox3.Text);
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

		private void Topic_CheckedChanged_1(object sender, EventArgs e)
		{
			if (Topic.Checked)
				tableLayoutToTopic.Visible = true;
			else
				tableLayoutToTopic.Visible = false;
		}
	}
}
