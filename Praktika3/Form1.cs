using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktika3
{
    public partial class Form1 :Form
    {
        private List<TovarSklad> tovarSklad;
        public Form1 ()
        {
            InitializeComponent( );
            tovarSklad = new List<TovarSklad>( );

        }

        private void Form1_Load (object sender, EventArgs e)
        {

        }

        private void AddTovarSklad (string name, decimal price, int quantity)
        {
            TovarSklad item = new TovarSklad(name, price, quantity);
            tovarSklad.Add(item);

            ClearInputs( );
            UpdateListBox( );
        }


        private void AddYearTovar (string name, decimal price, int quantity, int year)
        {
            YearTovar item = new YearTovar(name, price, quantity, year);
            tovarSklad.Add(item);

            ClearInputs( );
            UpdateListBox( );
        }

        private void RemoveSelectedItem ()
        {
            if ( listBox1.SelectedIndex != -1 )
            {
                tovarSklad.RemoveAt(listBox1.SelectedIndex);
                UpdateListBox( );
            }
        }


        private void button1_Click (object sender, EventArgs e)
        {
            try
            {
                
                string name = textBox1.Text;
                decimal price = decimal.Parse(textBox2.Text);
                int quantity = int.Parse(textBox3.Text);
                if (price < 0)
                {
                    MessageBox.Show("Цена не может быть меньше 0");
                }
                else
                {
                    AddTovarSklad(name, price, quantity);
                }
               
            }catch
            {
                MessageBox.Show("Неверный ввод");
            }
            
        }

        private void button2_Click (object sender, EventArgs e)
        {
            RemoveSelectedItem( );
        }


        private void UpdateListBox ()
        {
            listBox1.Items.Clear();
            foreach (var item in tovarSklad)
            {
                listBox1.Items.Add(item.Name);
            }
        }

        private void listBox1_SelectedIndexChanged (object sender, EventArgs e)
        {
           int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex != -1)
            {
                TovarSklad selectedItem = tovarSklad[selectedIndex];
                DisplayItemInfo(selectedItem);
            }
            else
            {
                ClearItemInfo();
            }
        }
        private void DisplayItemInfo (TovarSklad item)
        {
            label1.Text = $"Имя: {item.Name}";
            label2.Text = $"Цена: {item.Price}";
            label3.Text = $"Количество: {item.Quantity}";
            label4.Text = $"Качество: {item.CalculateQuality( )}";
        }
        private void ClearItemInfo ()
        {
            label1.Text = "Имя:";
            label2.Text = "Цена:";
            label3.Text = "Количество:";
            label4.Text = "Качество:";
        }
        private void ClearInputs ()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button3_Click (object sender, EventArgs e)
        {
            var sortedItems = tovarSklad.OrderBy(item => item.Name).ToList( ); 
            tovarSklad = sortedItems; 

            UpdateListBox( ); 
        }

        private void label5_Click (object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged (object sender, EventArgs e)
        {

        }
    }
}
