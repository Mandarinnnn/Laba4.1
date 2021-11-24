using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bmp = new Bitmap(1000, 1000);
        Rectangle rect;
        MyStorage storage = new MyStorage();
        

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(storage.isCheckedStorage(e)==false)//если нажато на пустое место
            {
                storage.AllNotChecked();
                storage.addObject(new Circle(e.X,e.Y,30));
                rect = new Rectangle(e.X - 32, e.Y - 32, 64, 64);
            }
            else//если нажать на круг
            {
                if(Control.ModifierKeys == Keys.Control)//если ctrl нажат
                {
                    storage.CheckedObjectStorage(e);
                }
                else//если ctrl не нажат
                {
                    storage.AllNotChecked();
                    storage.CheckedObjectStorage(e);
                }
            }
            this.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = Graphics.FromImage(bmp);

            storage.DrawAll(pictureBox1, g, bmp);
        }

    }
}
