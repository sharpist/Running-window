using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Убегающее_окно
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void описаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Добро пожаловать в забавное приложение «Убегающее окно». Постарайтесь ответить верно, особенно усердные смогут попасть по кнопке «Да, конечно!».\r\n     PS: сделал 12 янв. 2017 на C#, Александр Усов", "Описание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // Переводит координату X в строку и записывает в поля ввода
            textBox1.Text = e.X.ToString();
            // Переводит координату Y в строку и записывает в поля ввода
            textBox2.Text = e.Y.ToString();
            // Мы объявили экземпляр класса Random (rnd), с помощью которого будем генерировать случайные числа
            // Используем код, вида rnd.Next (диапазон_генерации) или rnd.Next (от, до -1)
            Random rnd = new Random();
            // Также объявим еще несколько переменных
            // tmp_location объявляется, чтобы временно хранить положение окна
            // А _h и _w будут хранить в себе размеры экрана, чтобы при случайном перемещении окно не вышло за его пределы
            Point tmp_location;
            int _w = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
            int _h = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
            // Если координата по оси X и по оси Y лежит в очерчиваемом вокруг кнопки "Да, конечно!" квадрате
            if (e.X > 0 && e.X < 130 && e.Y > 100 && e.Y < 160)
            {
                // Запоминаем текущее положение окна
                tmp_location = this.Location;
                // Генерируем перемещения по осям X и Y и прибавляем их к хранимому значению текущего положения окна
                // Числа генерируются в диапазоне от -100 до 100.
                tmp_location.X += rnd.Next(-100, 100);
                tmp_location.Y += rnd.Next(-100, 100);
                // Если окно вылезло за пределы экрана по одной из осей
                if (tmp_location.X < 0 || tmp_location.X > (_w - this.Width / 2) || tmp_location.Y < 0 || tmp_location.Y > (_h - this.Height / 2))
                {
                    // Новыми координатами станет центр окна
                    tmp_location.X = _w / 2;
                    tmp_location.Y = _h / 2;
                }
                // Обновляем положение окна, на новое сгенерированное
                this.Location = tmp_location;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Вывести сообщение с текстом "Вы усердны!"
            // Второй параметр - заголовок окна сообщения "Результат"
            // MessageBoxButtons.OK - тип размещаемой кнопки на форме сообщения
            // MessageBoxIcon.Information - тип сообщения - будет иметь иконку "информация" и соответствующий звуковой сигнал
            MessageBox.Show("Вы усердны!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Завершить приложение
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Вывести сообщение с текстом "Мы не сомневались в вешем безразличии..."
            MessageBox.Show("Мы не сомневались в вешем безразличии...", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}