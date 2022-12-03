using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentNum = "";
        private string memoryNum = "";
        private char currentChar = ' ';

        public MainWindow()
        {
            InitializeComponent();
        }

        private void changeChar_Click(object sender, RoutedEventArgs e)
        {
            currentNum = (-(double.Parse(currentNum))).ToString();
            update();
        }
        private void equals_Click(object sender, RoutedEventArgs e)
        {
            calculateCurrentNum();
            update();
        }

        private void squareroot_Click(object sender, RoutedEventArgs e)
        {
            currentChar = '@';
            saveToMemory();
            calculateCurrentNum();

            update();
        }

        private void calculateCurrentNum() => currentNum = Calculate(currentNum, memoryNum, currentChar);

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            currentChar = '+';
            saveToMemory();
            update();
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            currentChar = '-';
            saveToMemory();
            update();
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            currentChar = '*';
            saveToMemory();
            update();
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            currentChar = '/';
            saveToMemory();
            update();
        }

        private void square_Click(object sender, RoutedEventArgs e)
        {
            currentChar = '^';
            saveToMemory();
            update();
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            clearCurrentNum();
            update();
        }

        private void clearEverything_Click(object sender, RoutedEventArgs e)
        {
            clearCurrentNum();
            clearMemoryNum();
            clearCurrentChar();
            update();
        }

        private void saveToMemory()
        {
            memoryNum = currentNum;
            updateCurrentChar();
            clearCurrentNum();
        }

        private void clearCurrentNum() => currentNum = "";
        private void clearMemoryNum() => memoryNum = "";
        private void clearCurrentChar() => currentChar = ' ';

        private void number_Click(object sender, RoutedEventArgs e)
        {
            currentNum += ((Button)sender).Content;
            update();
        }

        private void update()
        {
            updateCurrentNum();
            updateMemoryNum();
            updateCurrentChar();
        }

        private void updateCurrentNum()
        {
            currentNumbers.Text = currentNum;
        }

        private void updateMemoryNum()
        {
            memoryNumbers.Text = memoryNum;
        }

        private void updateCurrentChar()
        {
            currentCharacter.Text = $"{currentChar}";
        }

        private string Calculate(string val1, string val2, char sign)
        {
            if (String.IsNullOrEmpty(val1) | String.IsNullOrEmpty(val2)) return currentNum;
            
            memoryNum = "";
            clearCurrentChar();

            string calculatedVal = "";
            double _val1 = Convert.ToDouble(val1);
            double _val2 = Convert.ToDouble(val2);

            switch (sign)
            {
                case '+':
                    calculatedVal = $"{_val1 + _val2}";
                    break;
                case '-':
                    calculatedVal = $"{_val2 - _val1}";
                    break;
                case '/':
                    if (_val1 == 0) break;
                    calculatedVal = $"{_val2 / _val1}";
                    break;
                case '*':
                    calculatedVal = $"{_val1 * _val2}";
                    break;
                case '^':
                    calculatedVal = $"{Math.Pow(_val2, _val1)}";
                    break;
                case '@':
                    calculatedVal = $"{Math.Pow(_val2, 1/_val1)}";
                    break;
                default:
                    break;
            }

            return calculatedVal;
        }
    }
}
