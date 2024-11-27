using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDIWindowsApp
{
    public partial class Form1 : Form
    {
        public Point point1;
        public Point point2;
        public int shape = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void OnFileOpen(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog(this);
        }

        private void OnFileExit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnFileSaveAs(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.ShowDialog(this);   
        }

        private void OnFormMouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("down event");
            point1=new Point(e.X, e.Y);
        }

        private void OnFormMouseUp(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("up event");
            point2=new Point(e.X, e.Y);
            Pen pen = new Pen(Color.Red);
            Graphics g=this.CreateGraphics();
            switch(shape)
            {
                case 1:
                    g.DrawLine(pen, point1, point2);
                    break;
                case 2:
                    float width = point2.X - point1.X;
                    float height = point2.Y - point1.Y;
                    g.DrawRectangle(pen, point1.X, point1.Y, width, height);
                    break;

            }
       
        }

        private void OnFormMouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
