/*Lesson 3. Task 2.Написать функцию, которая «угадывает» задуманное пользователем число от 1 до 2000. 
Для запроса к пользователю использовать MessageBox. После того, как число отгадано, необходимо вывести 
количество запросов, потребовавшихся для этого, и предоставить пользователю возможность сыграть еще раз, 
не выходя из программы. (MessageBox'ы оформляются кнопками и значками соответственно ситуации).*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessTheNumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Shown += PlayGame; //обработчик закреплен на событие "первый показ формы"
        }

        private void PlayGame(object sender, EventArgs e)
        {
            this.Hide(); //скрываем показ формы за ненадобностью
            DialogResult result; // переменная для записи нажатой кнопки из метода Show
            int Try = 1; //количество попыток

            while (true) //бесконечный цикл пока не закроем форму
            {
                result = MessageBox.Show($"{new Random().Next(1, 2000)}",
                    $"Вы загадали число", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show($"Количество попыток: {Try}", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Try = 0; //обнуляем кол-во попыток в текущей игре

                    result = MessageBox.Show($"Новая игра", "Продолжить",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No) this.Close();                
                }
                if (result == DialogResult.Cancel) this.Close();

                Try++; //инкремент количества попыток
            }
        }
    }
}
