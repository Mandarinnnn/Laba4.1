using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Laba4
{
    class Shape
    {
        virtual public void draw()
        {
        }
        virtual public bool isClicked(MouseEventArgs e)
        {
            return true;
        }
        virtual public void MakeCheckedTrue()
        {
        }
        virtual public void MakeCheckedFalse()
        {
        }
        virtual public void Draw(PictureBox pictureBox1, Graphics g, Bitmap bmp)
        {
        }

        virtual public bool isChecked()
        {
            return true;
        }
    }

    class Circle: Shape
    {
        private int x;
        private int y;
        private int r;
        private bool Checked;
        public Circle(int x,int y, int r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
            Checked = true;
        }
        public void Draw()
        {

        }
        override public bool isClicked(MouseEventArgs e)
        {
            if (((e.X - x)*(e.X - x) + (e.Y - y) * (e.Y - y)) <= r * r)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        override public void MakeCheckedTrue()
        {
            Checked = true;
        }
        override public void MakeCheckedFalse()
        {
            Checked = false;
        }

        override public void Draw(PictureBox pictureBox1, Graphics g, Bitmap bmp)
        {
            Rectangle rect = new Rectangle(x - r, y - r, r * 2, r * 2);
            Pen pen;
            if (Checked== true)
            {
                pen = new Pen(Color.Blue);
            }
            else
            {
                pen = new Pen(Color.Black);
            }      
            g.DrawEllipse(pen, rect);
            pictureBox1.Image = bmp;
        }
        override public bool isChecked()
        {
            return Checked;
        }
    }

    class MyStorage
    {
        private int size;
        Shape[] storage;
        public MyStorage()
        {
            size = 0;
        }
        public MyStorage(int size)
        {
            this.size = size;
            storage = new Shape[size];
        }

        public void setObject(int i, Shape obj)
        {
            storage[i] = obj;
        }

        public void addObject(Shape obj)
        {
            Shape[] storage2 = new Shape [size+1];
            if (size != 0)
            {
                for(int i = 0; i < size; i++)
                {
                    storage2[i] = storage[i];
                }
            }
            storage = storage2;
            storage[size] = obj;
            size = size + 1;
        }

        public int getCount()
        {
            return size;
        }

        public bool isCheckedStorage(MouseEventArgs e)
        {
            for(int i = 0; i < size; i++)
            {
                if (storage[i].isClicked(e) == true)
                {
                    return true;
                }
            }
            return false;
        }

        public void MakeCheckedObjectStorage(MouseEventArgs e)
        {
            for (int i = 0; i < size; i++)
            {
                if (storage[i].isClicked(e) == true)
                {
                    storage[i].MakeCheckedTrue();
                    break;
                }
            }
        }

        public void removeObject(int i)
        {
            if (size != 0 && i<size && size!=0)
            {
                Shape[] storage2 = new Shape[size - 1];
                for (int j = 0; j < i; j++)
                {
                    storage2[j] = storage[j];
                }
                for (int j = i; j < size - 1; j++)
                {
                    storage2[j] = storage[j+1];
                }
                size = size - 1;
                storage = storage2;
            }
            else if (size == 1)
            {
                storage[0] = null;
                size = 0;
            }
        }

        public void removeCheckedObject(MyStorage storage)
        {
            for(int i = 0; i < size; i++)
            {
                if (this.storage[i].isChecked() == true)
                {
                    storage.removeObject(i);
                    i = i - 1;
                }
            }
        }


        public void AllNotChecked()
        {
            for(int i = 0; i < size; i++)
            {
                storage[i].MakeCheckedFalse();
            }
        }

        public void DrawAll(PictureBox pictureBox1, Graphics g, Bitmap bmp)
        {
            for (int i = 0; i < size; i++)
            {
                storage[i].Draw(pictureBox1, g, bmp);
            }
        }

    }


}
