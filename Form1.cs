using System;
using System.Windows.Forms;
using System.Drawing;

namespace CALCULATOR
{
    public partial class Form1 : Form
    {
        private string currentValue = "0";
        private double previousValue = 0;
        private string operation = "";
        private bool isNewEntry = true;

        public Form1()
        {
            InitializeComponent();
            txtDisplay.ReadOnly = true; // Sécurité pour que l'utilisateur ne tape pas au clavier
        }

        // GESTION DES CHIFFRES (Tous les boutons 0-9)
        private void btn0_Click(object sender, EventArgs e) => AppendDigit("0");
        private void btn1_Click(object sender, EventArgs e) => AppendDigit("1");
        private void btn2_Click(object sender, EventArgs e) => AppendDigit("2");
        private void btn3_Click(object sender, EventArgs e) => AppendDigit("3");
        private void btn5_Click(object sender, EventArgs e) => AppendDigit("5");
        private void btn6_Click(object sender, EventArgs e) => AppendDigit("6");
        private void btn7_Click(object sender, EventArgs e) => AppendDigit("7");
        private void btn8_Click(object sender, EventArgs e) => AppendDigit("8");
        private void btn9_Click(object sender, EventArgs e) => AppendDigit("9");

        private void AppendDigit(string digit)
        {
            if (isNewEntry)
            {
                currentValue = digit;
                isNewEntry = false;
            }
            else
            {
                if (currentValue == "0") currentValue = digit;
                else currentValue += digit;
            }
            txtDisplay.Text = currentValue;
        }

        // GESTION DES OPÉRATIONS
        private void btnPlus_Click(object sender, EventArgs e) => HandleOperation("+");
        private void btnMinus_Click(object sender, EventArgs e) => HandleOperation("-");
        private void btnMultiply_Click(object sender, EventArgs e) => HandleOperation("×");
        private void btnDivide_Click(object sender, EventArgs e) => HandleOperation("÷");

        private void HandleOperation(string op)
        {
            if (operation != "" && !isNewEntry) Calculate();
            previousValue = double.Parse(currentValue);
            operation = op;
            isNewEntry = true;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            Calculate();
            operation = "";
            isNewEntry = true;
        }

        private void Calculate()
        {
            if (operation == "") return;
            double current = double.Parse(currentValue);
            double result = 0;

            switch (operation)
            {
                case "+": result = previousValue + current; break;
                case "-": result = previousValue - current; break;
                case "×": result = previousValue * current; break;
                case "÷":
                    if (current != 0) result = previousValue / current;
                    else
                    {
                        MessageBox.Show("Erreur : Division par zéro");
                        btnClear_Click(null, null);
                        return;
                    }
                    break;
            }
            currentValue = result.ToString();
            txtDisplay.Text = currentValue;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            currentValue = "0";
            previousValue = 0;
            operation = "";
            isNewEntry = true;
            txtDisplay.Text = "0";
        }

        private void btn4_Click(object sender, EventArgs e) => AppendDigit("4");
    }
}