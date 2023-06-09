﻿using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel.Application;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace lab3
{
    public partial class Dictionary : Form
    {
        Image image;
        String tenImage,text;
        String url = "G:\\Oanhhh\\c#\\image\\lab3\\Jobs";
        string filePathExcel = "G:\\Oanhhh\\c#\\lab3\\lab3\\DicData.xlsx";
        String topic = "Jobs";

        Excel excel = new Excel();
        Workbook wb;
        Worksheet ws;
        Range range;
        int idSelectRow;
        System.Data.DataTable dataTable = new System.Data.DataTable();
        private readonly DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
        public Dictionary()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            excel.Quit();

            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void guna2CirclePictureBox6_Click(object sender, EventArgs e)
        {
            if (Program.isPlay == true)
            {
                Program.dungNhac(guna2CirclePictureBox6);
            }
            else if (Program.isPlay == false)
            {
                Program.moNhac(guna2CirclePictureBox6);
            }
        }

        private void Dictionary_Load(object sender, EventArgs e)
        {
            loadData();
            guna2DataGridView1.Columns.Add(btn);
            if (Program.isPlay == true)
            {
                Program.moNhac(guna2CirclePictureBox6);
                guna2CirclePictureBox6.Image = Image.FromFile("G:\\Oanhhh\\c#\\lab3\\lab3\\Resources\\volume.png");
            }
            else if (Program.isPlay == false)
            {
                guna2CirclePictureBox6.Image = Image.FromFile("G:\\Oanhhh\\c#\\lab3\\lab3\\Resources\\volume-mute.png");
            }
        }

        private void btn_job_Click(object sender, EventArgs e)
        {
            btn_job.BackColor = Color.FromArgb(71, 169, 146);
            btn_animal.BackColor = Color.Transparent;
            btn_fruit.BackColor = Color.Transparent;
            btn_color.BackColor = Color.Transparent;
            url = "G:\\Oanhhh\\c#\\image\\lab3\\Jobs";
            topic = "Jobs";
            loadData();
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            btn_color.BackColor = Color.FromArgb(71, 169, 146);
            btn_animal.BackColor = Color.Transparent;
            btn_fruit.BackColor = Color.Transparent;
            btn_job.BackColor = Color.Transparent;
            url = "G:\\Oanhhh\\c#\\image\\lab3\\color";
            topic = "color";
            loadData();
        }

        private void btn_animal_Click(object sender, EventArgs e)
        {
            btn_animal.BackColor = Color.FromArgb(71, 169, 146);
            btn_job.BackColor = Color.Transparent;
            btn_fruit.BackColor = Color.Transparent;
            btn_color.BackColor = Color.Transparent;
            url = "G:\\Oanhhh\\c#\\image\\lab3\\animal";
            topic = "animal";
            loadData();

        }

        private void btn_fruit_Click(object sender, EventArgs e)
        {
            btn_fruit.BackColor = Color.FromArgb(71, 169, 146);
            btn_animal.BackColor = Color.Transparent;
            btn_job.BackColor = Color.Transparent;
            btn_color.BackColor = Color.Transparent;
            url = "G:\\Oanhhh\\c#\\image\\lab3\\fruit";
            topic = "fruit";
            loadData();

        }

        private void loadData()
        {
            while (guna2DataGridView1.Rows.Count > 1)
            {
                guna2DataGridView1.Rows.Remove(guna2DataGridView1.Rows[0]);
            }

            wb = excel.Workbooks.Open(filePathExcel);
            ws = wb.Worksheets[topic];
            range = ws.UsedRange;

            for (int row = 1; row <= range.Rows.Count; ++row)//đọc row hiện có trong Excel
            {
                guna2DataGridView1.Rows.Add(new Bitmap(range.Cells[row, 1].Text), range.Cells[row, 2].Text);
                
            }
            wb.Close();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idSelectRow = e.RowIndex;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = url;
            fileDialog.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                tenImage = fileDialog.FileName;
                guna2PictureBox1.Image = new Bitmap(tenImage);
            }

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            wb = excel.Workbooks.Open(filePathExcel);
            ws = wb.Worksheets[topic];
            range = ws.UsedRange;

            int id = ws.UsedRange.Rows.Count + 1;
            Range cells = ws.Range[$"A{id}:B{id}"];
            string[] things = { tenImage, text_search.Text };
            cells.set_Value(XlRangeValueDataType.xlRangeValueDefault, things);

            wb.Save();
            wb.Close();
            //excel.Quit();

            guna2DataGridView1.Rows.Add(new Bitmap(tenImage), text_search.Text);

            text_search.Text = "";
            guna2PictureBox1.Image = Image.FromFile("Resources/picture.png");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.RemoveAt(idSelectRow);

        }

    }
}
