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
using System.Windows.Markup;
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CreatePassword(object sender, RoutedEventArgs e)
        {
            int Lenght()
            {
                bool isDigit = int.TryParse(PasswordLenght.Text, out int number);
                if (isDigit)
                {
                    return number;
                }
                else
                {
                    return 6;
                }
            }

            Random rnd = new Random();
            TextBox.Text = "";
            bool[] symbolApproved = new bool[]
                                    {
                                        false,
                                        false,
                                        false,
                                        false
                                    };
            if (first.IsChecked == true)
                symbolApproved[0] = true;
            if (second.IsChecked == true)
                symbolApproved[1] = true;
            if (therd.IsChecked == true)
                symbolApproved[2] = true;
            if (fourth.IsChecked == true)
                symbolApproved[3] = true;
            string chars = "";
            for (int i = 0; i < symbolApproved.Length; i++)
            {
                if (symbolApproved[i] == true)
                {
                    chars = string.Concat(chars, i.ToString());
                }
            }

            if (chars == "")
            {
                const string message = "Выберите символы";
                MessageBoxResult result = MessageBox.Show(message);
                chars = 1.ToString();
            }


            if (PasswordLenght != null)
            {
                for (int j = 0; j < 7; j++)
                {
                    string? password = null;
                    int lenght = Lenght();
                    for (int i = 0; i < lenght; i++)
                    {
                        password = string.Concat(
                            password, GenerateSymbol(
                                Int32.Parse(
                                    new string(
                                        Enumerable.Repeat(chars, 1)
                                            .Select(s => s[rnd.Next(s.Length)]).ToArray()
                                    )
                                )
                            )
                        );
                    }

                    TextBox.AppendText(password + "\r");
                }
            }
        }
        private static string? GenerateSymbol(int inIndex)
        {
            Random rnd = new Random();
            int length = 1;
            string? str = null;

            switch (inIndex)
            {
                case 0:
                {
                    const string chars = "0123456789";
                    return str = new string(
                        Enumerable.Repeat(chars, length)
                            .Select(s => s[rnd.Next(s.Length)]).ToArray());
                }
                case 1:
                {
                    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    return str = new string(
                        Enumerable.Repeat(chars, length)
                            .Select(s => s[rnd.Next(s.Length)]).ToArray());
                }
                case 2:
                {
                    const string chars = "abcdefghijklmnopqrstuvwxyz";
                    return str = new string(
                        Enumerable.Repeat(chars, length)
                            .Select(s => s[rnd.Next(s.Length)]).ToArray());
                }
                case 3:
                {
                    const string chars = "@#$%^&*()!~";
                    return str = new string(
                        Enumerable.Repeat(chars, length)
                            .Select(s => s[rnd.Next(s.Length)]).ToArray());
                }
            }

            return str;
        }
    }
}