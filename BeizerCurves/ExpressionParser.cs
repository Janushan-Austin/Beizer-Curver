using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeizerCurves
{
    class ExpressionParser
    {
        public class ArithmeticNode
        {
            public string symbol;
            public float number;
            public bool isNumber;
            public bool isID;
            public int IDIndex;
            public ArithmeticNode left, right;

            public ArithmeticNode()
            {
                symbol = "\0";
                number = 0f;
                isNumber = false;
                isID = false;
                IDIndex = -1;
                left = right = null;
            }
        }

        ArithmeticNode Root;

        string[] Identifiers;
        int numIdentifiers;

        public ExpressionParser()
        {
            Root = new ArithmeticNode();
            Identifiers = new string[5];
            numIdentifiers = 0;

        }

        public int GetNumberofIdentifiers()
        {
            return numIdentifiers;
        }

        public string GetVars()
        {
            string vars = "";
            for(int i=0; i< numIdentifiers; i++)
            {
                vars += Identifiers[i] + ", ";
            }

            return vars;
        }

        public void EvaluateExpression(string exp)
        {
            exp = DeleteSpace(exp);
            if (Root != null)
            {
                DeleteExpression(ref Root);
                Root = new ArithmeticNode();
            }
            EvaluateExpression(ref Root, exp);
        }
        private void EvaluateExpression(ref ArithmeticNode node, string exp)
        {
            bool opFound = false;
            int i = exp.Length - 1, lp = 0, rp = 0;
            while (i >= 0)
            {
                if ((exp[i] == '+' || exp[i] == '-') && lp == rp)
                {
                    opFound = true;
                    node.symbol = exp[i].ToString();
                    node.left = new ArithmeticNode();
                    node.right = new ArithmeticNode();
                    break;
                }
                else if (exp[i] == '(')
                {
                    lp++;
                }
                else if (exp[i] == ')')
                {
                    rp++;
                }
                i--;
            }
            if (opFound)
            {
                string left = "", right = "";
                for (int j = 0; j < i; j++)
                {
                    left += exp[j];
                }
                for (int j = i + 1; j < exp.Length; j++)
                {
                    right += exp[j];
                }

                EvaluateExpression(ref node.left, left);
                EvaluateTerm(ref node.right, right);
            }
            else
            {
                EvaluateTerm(ref node, exp);
            }
        }

        private void EvaluateTerm(ref ArithmeticNode node, string exp)
        {
            bool opFound = false;
            int i = exp.Length - 1, lp = 0, rp = 0;
            while (i >= 0)
            {
                if ((exp[i] == '*' || exp[i] == '/') && lp == rp)
                {
                    opFound = true;
                    node.symbol = exp[i].ToString();
                    node.left = new ArithmeticNode();
                    node.right = new ArithmeticNode();
                    break;
                }
                else if (exp[i] == '(')
                {
                    lp++;
                }
                else if (exp[i] == ')')
                {
                    rp++;
                }
                i--;
            }
            if (opFound)
            {
                string left = "", right = "";
                for (int j = 0; j < i; j++)
                {
                    left += exp[j];
                }
                for (int j = i + 1; j < exp.Length; j++)
                {
                    right += exp[j];
                }

                EvaluateTerm(ref node.left, left);
                EvaluateFactor(ref node.right, right);
            }
            else
            {
                EvaluateFactor(ref node, exp);
            }
        }

        private void EvaluateFactor(ref ArithmeticNode node, string exp)
        {
            bool parFound = false, expFound = false;
            int i = exp.Length - 1, lp = 0, rp = 0;

            for (; i >= 0; i--)
            {
                if (exp[i] == ')')
                {
                    parFound = true;
                    rp++;
                }
                else if (exp[i] == '(')
                {
                    lp++;
                }
                else if (exp[i] == '^' && lp == rp)
                {
                    expFound = true;
                    break;
                }
            }

            if (expFound)
            {
                string left = "", right = "";

                node.symbol = "^";
                node.left = new ArithmeticNode();
                node.right = new ArithmeticNode();

                for (int j = 0; j < i; j++)
                {
                    left += exp[j];
                }
                for (int j = i + 1; j < exp.Length; j++)
                {
                    right += exp[j];
                }

                EvaluateFactor(ref node.left, left);
                EvaluateExpression(ref node.right, right);
            }
            else if (parFound)
            {
                string child = "";

                node.symbol = "(";
                node.right = new ArithmeticNode();
                node.left = null;

                for (int j = 1; j < exp.Length - 1; j++)
                {
                    child += exp[j];
                }

                EvaluateExpression(ref node.right, child);
            }
            else
            {
                EvaluateID(ref node, exp);
            }

        }

        private void EvaluateID(ref ArithmeticNode node, string exp)
        {
            node.number = 0f;
            bool floating = false;
            int i;

            node.left = null;
            node.right = null;

            if (exp[0] >= 'a' && exp[0] <= 'z' || exp[0] >= 'A' && exp[0] <= 'Z')
            {
                node.isID = true;
                for(i = 0; i< Identifiers.Length; i++)
                {
                    if(exp == Identifiers[i])
                    {
                        break;
                    }
                }
                if (i < Identifiers.Length)
                {
                    node.symbol = Identifiers[i];
                    node.IDIndex = i;
                }
                else
                {
                    node.symbol = exp;
                    node.IDIndex = numIdentifiers;
                    if(numIdentifiers >= Identifiers.Length)
                    {
                        string[] temp = Identifiers;
                        Identifiers = new string[2 * temp.Length];
                        for (i = 0; i < temp.Length; i++)
                        {
                            Identifiers[i] = temp[i];
                        }
                    }
                    Identifiers[numIdentifiers] = exp;                    
                    numIdentifiers++;
                }
                return;
            }

            node.isNumber = true;

            for (i =0; i < exp.Length; i++)
            {
                if (exp[i] == '.')
                {
                    floating = true;
                    break;
                }

                if (exp[i] < '0' || exp[i] > '9')
                {
                    MessageBox.Show("Invalid number in formula, made it to ID stage! Current string is\"" + exp + "\"");
                    node.number = 0f;
                    return;
                }

                node.number *= 10;
                node.number += exp[i] - '0';
            }

            if (floating)
            {
                float number = 0f;
                for (int j = exp.Length - 1; j > i; j--)
                {
                    if (exp[j] < '0' || exp[j] > '9')
                    {
                        MessageBox.Show("Invalid number in formula, made it to ID stage!");
                        node.number = 0f;
                        return;
                    }
                    char tmp = exp[j];
                    number += (exp[j] - '0');
                    number /= 10;
                }

                node.number += number;
            }
        }

        public double CalculateExpression(double[] vars)
        {
            if (Root == null)
            {
                MessageBox.Show("Root is a null node!");
                return 0.0;
            }
            else if( vars.Length < numIdentifiers)
            {
                MessageBox.Show("Improper number of input for current expression: Too few arguments");
                return 0.0;
            }
            else if (vars.Length > numIdentifiers)
            {
                MessageBox.Show("Improper number of input for current expression: Too many arguments");
                return 0.0;
            }
            return CalculateExpression(ref Root, vars);
        }
        private double CalculateExpression(ref ArithmeticNode node, double[] vars)
        {
            if(node == null)
            {
                return 0;
            }
            else if (node.isNumber)
            {
                return node.number;
            }
            else if (node.isID)
            {
                return vars[node.IDIndex];
            }
            else if (node.symbol == "+")
            {
                return CalculateExpression(ref node.left, vars) + CalculateExpression(ref node.right, vars);
            }
            else if (node.symbol == "-")
            {
                return CalculateExpression(ref node.left, vars) - CalculateExpression(ref node.right, vars);
            }
            else if (node.symbol == "*")
            {
                return CalculateExpression(ref node.left, vars) * CalculateExpression(ref node.right, vars);
            }
            else if (node.symbol == "/")
            {
                return CalculateExpression(ref node.left, vars) / CalculateExpression(ref node.right, vars);
            }
            else if (node.symbol == "^")
            {

                return Math.Pow(CalculateExpression(ref node.left, vars), CalculateExpression(ref node.right, vars));
            }
            else if (node.symbol == "(")
            {
                return CalculateExpression(ref node.right, vars);
            }
            else
            {
                return 0;
            }
        }

        private void DeleteExpression(ref ArithmeticNode node)
        {
            if (node != null)
            {
                DeleteExpression(ref node.left);
                DeleteExpression(ref node.right);
                node = null;
            }
        }

        public bool RearrangeArgs(string[] newOrder)
        {
            if(newOrder.Length < numIdentifiers || newOrder.Length > numIdentifiers)
            {
                MessageBox.Show("Invalid number of arguments for rearrangment! Looking for " + numIdentifiers.ToString() + " number of arguments");
                return false;
            }
            else
            {
                for (int i = 0; i < Identifiers.Length; i++)
                {
                    bool varFound = false;
                    for (int j = 0; j < newOrder.Length; j++) {
                        if (Identifiers[i] == newOrder[j])
                        {
                            varFound = true;
                        }
                    }
                    if (!varFound)
                    {
                        MessageBox.Show("Variable " + Identifiers[i] + " not found in the new ordered list of variables");
                        return false;
                    }
                }
                Identifiers = newOrder;
            }
            return true;
        }

        private void RenumberIdentifierInTree(ref ArithmeticNode node,string id, int newIndex)
        {
            if(node == null)
            {
                return;
            }
            else if(node.symbol == id)
            {
                node.IDIndex = newIndex;
            }
            else
            {
                RenumberIdentifierInTree(ref node.left, id, newIndex);
                RenumberIdentifierInTree(ref node.right, id, newIndex);
            }
        } 

        public void PrintParseTree()
        {
            if (Root == null)
            {
                MessageBox.Show("There is no parse tree to print");
                return;
            }

            MessageBox.Show(PrintParseTree(ref Root));
        }
        private string PrintParseTree(ref ArithmeticNode node)
        {
            string ans = "";
            if (node != null)
            {
                ans += PrintParseTree(ref node.left);
                if (node.isNumber)
                {
                    // MessageBox.Show(node.number);
                    ans += node.number.ToString();
                }
                else
                {
                    // MessageBox.Show(node.symbol);
                    ans += node.symbol;
                }
                ans += PrintParseTree(ref node.right);
                if (node.symbol == "(")
                {
                    //MessageBox.Show(')');
                    ans += ')';
                }
            }

            return ans;
        }

        private string DeleteSpace(string str)
        {
            string newstr = "";
            char lastChar = '\0';
            bool deletingSpace = false;
            int lp = 0, rp = 0;

            if (str == "")
            {
                MessageBox.Show("No function provided, returning y=x");
                return "x";
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    lp++;
                }
                else if (str[i] == ')')
                {
                    rp++;
                }


                if (str[i] == ' ')
                {
                    deletingSpace = true;
                }
                else if ((str[i] >= '0' && str[i] <= '9') || str[i] == '.')
                {
                    if (deletingSpace && lastChar >= '0' && lastChar <= '9')
                    {
                        MessageBox.Show("Invalid function! Interpretation will be incorrect! Setting function to y=x");
                        return "x";
                    }
                    //Remove lastChar == 'x' for ambiquious state
                    else if (lastChar == 'x' || lastChar == ')')
                    {
                        newstr += "*" + str[i];
                        lastChar = str[i];
                        deletingSpace = false;
                    }
                    else
                    {
                        newstr += str[i];
                        lastChar = str[i];
                        deletingSpace = false;
                    }
                }
                //Remove lastChar == 'x' for ambiquious state
                else if ((str[i] == 'x' || str[i] == '(') && ((lastChar >= '0' && lastChar <= '9') || lastChar == ')'))
                {
                    newstr += "*" + str[i];
                    lastChar = str[i];
                    deletingSpace = false;
                }
                else if (str[i] == ')' && (lastChar == '+' || lastChar == '*' || lastChar == '/' || lastChar == '-' || lastChar == '(' || lastChar == '^'))
                {
                    MessageBox.Show("Invalid function! Interpretation will be incorrect! Setting function to y=x");
                    return "x";
                }
                else if ((str[i] == '+' || str[i] == '*' || str[i] == '/' || str[i] == '^') && (lastChar == '(' || lastChar == '\0'))
                {
                    MessageBox.Show("Invalid function! Interpretation will be incorrect! Setting function to y=x");
                    return "x";
                }
                else if ((str[i] == '+' || str[i] == '*' || str[i] == '/' || str[i] == '^') && (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/' || lastChar == '^'))
                {
                    MessageBox.Show("Invalid function! Interpretation will be incorrect! Setting function to y=x");
                    return "x";

                }
                else
                {
                    newstr += str[i];
                    lastChar = str[i];
                    deletingSpace = false;
                }
            }

            if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/' || lastChar == '(' || lastChar == '^' || lastChar == '\0' || lp != rp)
            {
                MessageBox.Show("Invalid function! Interpretation will be incorrect! Setting function to y=x");
                return "x";

            }

            return newstr;
        }
    }
}
