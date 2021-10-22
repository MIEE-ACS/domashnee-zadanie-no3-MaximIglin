using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            correct_count.Text = 0.ToString();
            incorrect_count.Text = 0.ToString();
            message.Content = "";
            updateValues();
        }

        private void checkData(object sender, RoutedEventArgs e)
        {
            var variants = new List<RadioButton> { variant1, variant2, variant3, variant4 };
            String first_correct_variant = (int.Parse(first_value.Text) + int.Parse(second_value.Text)).ToString();
            String second_correct_variant = (int.Parse(first_value.Text) - int.Parse(second_value.Text)).ToString();
            foreach (RadioButton variant in variants)
            {
                if (variant.IsChecked != false)
                {
                    if (variant.Content.ToString() == first_correct_variant && sign.Text == "+")
                    {
                        correct_count.Text = (int.Parse(correct_count.Text) + 1).ToString();
                        message.Content = "Правильный ответ";
                        variant.IsChecked = false;
                        break;
                    }
                    else if (variant.Content.ToString() == second_correct_variant && sign.Text == "-")
                    {
                        correct_count.Text = (int.Parse(correct_count.Text) + 1).ToString();
                        message.Content = "Правильный ответ";
                        variant.IsChecked = false;
                        break;
                    }
                    else
                    {
                        incorrect_count.Text = (int.Parse(incorrect_count.Text) + 1).ToString();
                        message.Content = "Неправильный ответ";
                        variant.IsChecked = false;
                        break;
                    }
                }
                else
                {
                    continue;
                }


            }
            updateValues();
        }

        public void updateValues()
        {
            Random rnd = new Random();
            String[] signs = new String[2] { "+", "-" };
            first_value.Text = rnd.Next(0, 50).ToString();
            second_value.Text = rnd.Next(0, 50).ToString();
            sign.Text = signs[rnd.Next(0, 2)];
            var variants = new List<RadioButton> { variant1, variant2, variant3, variant4 };
            foreach (RadioButton variant in variants)
            {
                variant.Content = "";
            }
            String first_correct_variant = (int.Parse(first_value.Text) + int.Parse(second_value.Text)).ToString();
            String second_correct_variant = (int.Parse(first_value.Text) - int.Parse(second_value.Text)).ToString();
            variants[rnd.Next(0, 4)].Content = first_correct_variant;

            foreach (RadioButton variant in variants)
            {
                if (variant.Content.ToString() != first_correct_variant)
                {
                    variant.Content = second_correct_variant;
                    break;
                }
            }
            foreach (RadioButton variant in variants)
            {
                if (variant.Content.ToString() != first_correct_variant && variant.Content.ToString() != second_correct_variant)
                {
                    variant.Content = rnd.Next(-100, 100);

                }
            }

        }
    }
}



