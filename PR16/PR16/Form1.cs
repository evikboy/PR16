using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pen_for_draw.StartCap = pen_for_draw.EndCap =
            System.Drawing.Drawing2D.LineCap.Round;

        }

        Bitmap bmp_for_draw;
        Point start_point;
        bool dozvil;
        Pen pen_for_draw = new Pen(Color.Black, 4);

        string full_name_of_image;




        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP,*.JPG,*.GIF,*.PNG)|*.bmp,*.jpg,*.gif,*.png|All Files(*.*)|*.*";
            open_dialog.Filter = "Image Files(All Files(*.*)|*.*";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    full_name_of_image = open_dialog.FileName;
                    bmp_for_draw = new Bitmap(open_dialog.FileName);
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    pictureBox1.Image = bmp_for_draw;
                    pictureBox1.Invalidate();
                }
                catch
                {
                    DialogResult result = MessageBox.Show("It's impossible to open selected file");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                string format = full_name_of_image.Substring(full_name_of_image.Length - 4, 4);
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Зберегти як ...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckFileExists = true;
                savedialog.ShowHelp = true;
                savedialog.Filter = "Image Files(All Files(*.*)|*.*";
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        bmp_for_draw.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("It's impossible to save image");
                    }
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(SystemColors.Window);

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    g.DrawLine(pen_for_draw, start_point, e.Location);
                    start_point = e.Location;
                    pictureBox1.Invalidate();
                }
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dozvil = true;
                start_point = e.Location;
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dozvil = false;
            }

        }
    }
}

