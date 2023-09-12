using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_Lemeshko
{
    public partial class fMain : Form
    {
        CEmblem[] emblem;
        int EmblemCount = 0;
        int CurrentEmblemIndex;

        public fMain()
        {
            InitializeComponent();
            // Створення масиву для об'єктів - кіл
            emblem = new CEmblem[100];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            if (EmblemCount >= 99)
            {
                MessageBox.Show("Досягнуто межі кількості об'єктів!");
                return;
            }
            Graphics graphics = pnMain.CreateGraphics();
            CurrentEmblemIndex = EmblemCount;
            // Створення нового об'єкта - екземпляра класу CCircle
            emblem[CurrentEmblemIndex] =
            new CEmblem(graphics, pnMain.Width / 2, pnMain.Height / 2, 50);
            emblem[CurrentEmblemIndex].Show();
            EmblemCount++;
            cbEmblem.Items.Add("Емблема No" + (EmblemCount - 1).ToString());
            cbEmblem.SelectedIndex = EmblemCount - 1;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            CurrentEmblemIndex = cbEmblem.SelectedIndex;
            if ((CurrentEmblemIndex > EmblemCount) || (CurrentEmblemIndex < 0))
                return;
            // Приховування поточного об'єкта - екземпляра класу CCircle
            emblem[CurrentEmblemIndex].Hide();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            CurrentEmblemIndex = cbEmblem.SelectedIndex;
            if ((CurrentEmblemIndex > EmblemCount) || (CurrentEmblemIndex < 0))
                return;
            // Відображення поточного об'єкта
            emblem[CurrentEmblemIndex].Show();
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            CurrentEmblemIndex = cbEmblem.SelectedIndex;
            if ((CurrentEmblemIndex > EmblemCount) || (CurrentEmblemIndex < 0))
                return;
            // Розширення поточного об'єкта - екземпляра класу CCircle
            emblem[CurrentEmblemIndex].Expand(5);
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            CurrentEmblemIndex = cbEmblem.SelectedIndex;
            if ((CurrentEmblemIndex > EmblemCount) || (CurrentEmblemIndex < 0))
                return;
            // Стискання поточного об'єкта - екземпляра класу CCircle
            emblem[CurrentEmblemIndex].Collapse(5);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            CurrentEmblemIndex = cbEmblem.SelectedIndex;
            if ((CurrentEmblemIndex > EmblemCount) || (CurrentEmblemIndex < 0))
                return;
            // Переміщення вверх поточного об'єкта
            emblem[CurrentEmblemIndex].Move(0, -10);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            CurrentEmblemIndex = cbEmblem.SelectedIndex;
            if ((CurrentEmblemIndex > EmblemCount) || (CurrentEmblemIndex < 0))
                return;
            // Переміщення вниз поточного об'єкта
            emblem[CurrentEmblemIndex].Move(0, 10);
        }
        private void btnRight_Click(object sender, EventArgs e)
        {
            CurrentEmblemIndex = cbEmblem.SelectedIndex;
            if ((CurrentEmblemIndex > EmblemCount) || (CurrentEmblemIndex < 0))
                return;
            // Переміщення вправо поточного об'єкта
            emblem[CurrentEmblemIndex].Move(10, 0);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            CurrentEmblemIndex = cbEmblem.SelectedIndex;
            if ((CurrentEmblemIndex > EmblemCount) || (CurrentEmblemIndex < 0))
                return;
            // Переміщення вліво поточного об'єкта
            emblem[CurrentEmblemIndex].Move(-10, 0);
        }

        private void btnRightFar_Click(object sender, EventArgs e)
        {
            CurrentEmblemIndex = cbEmblem.SelectedIndex;
            if ((CurrentEmblemIndex > EmblemCount) || (CurrentEmblemIndex < 0))
                return;
            // Переміщення поточного об'єкта вправо на більшу відстань
            for (int i = 0; i < 100; i++)
            {
                emblem[CurrentEmblemIndex].Move(1, 0);
                System.Threading.Thread.Sleep(5);
            }
        }

        private void btnLeftFar_Click(object sender, EventArgs e)
        {
            CurrentEmblemIndex = cbEmblem.SelectedIndex;
            if ((CurrentEmblemIndex > EmblemCount) || (CurrentEmblemIndex < 0))
                return;
            // Переміщення поточного об'єкта вліво на більшу відстань
            for (int i = 0; i < 100; i++)
            {
                emblem[CurrentEmblemIndex].Move(-1, 0);
                System.Threading.Thread.Sleep(5);
            }
        }

        private void btnUpFar_Click(object sender, EventArgs e)
        {
            CurrentEmblemIndex = cbEmblem.SelectedIndex;
            if ((CurrentEmblemIndex > EmblemCount) || (CurrentEmblemIndex < 0))
                return;
            // Переміщення поточного об'єкта вверх на більшу відстань
            for (int i = 0; i < 100; i++)
            {
                emblem[CurrentEmblemIndex].Move(0, -1);
                System.Threading.Thread.Sleep(5);
            }
        }

        private void btnDownFar_Click(object sender, EventArgs e)
        {
            CurrentEmblemIndex = cbEmblem.SelectedIndex;
            if ((CurrentEmblemIndex > EmblemCount) || (CurrentEmblemIndex < 0))
                return;
            // Переміщення поточного об'єкта вниз на більшу відстань
            for (int i = 0; i < 100; i++)
            {
                emblem[CurrentEmblemIndex].Move(0, 1);
                System.Threading.Thread.Sleep(5);
            }
        }
    }
}
