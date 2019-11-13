using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Views;
using System.Collections;

namespace App3
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private TextView calculatorText;

 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
 
            calculatorText = FindViewById<TextView>(Resource.Id.calculator_text_view);

            FindViewById<Button>(Resource.Id.one).Click += (o, e) =>
            calculatorText.Text += "1";
            FindViewById<Button>(Resource.Id.two).Click += (o, e) =>
            calculatorText.Text += "2";
            FindViewById<Button>(Resource.Id.three).Click += (o, e) =>
            calculatorText.Text += "3";
            FindViewById<Button>(Resource.Id.four).Click += (o, e) =>
            calculatorText.Text += "4";
            FindViewById<Button>(Resource.Id.five).Click += (o, e) =>
            calculatorText.Text += "5";
            FindViewById<Button>(Resource.Id.six).Click += (o, e) =>
            calculatorText.Text += "6";
            FindViewById<Button>(Resource.Id.seven).Click += (o, e) =>
            calculatorText.Text += "7";
            FindViewById<Button>(Resource.Id.eight).Click += (o, e) =>
            calculatorText.Text += "8";
            FindViewById<Button>(Resource.Id.nine).Click += (o, e) =>
            calculatorText.Text += "9";
            FindViewById<Button>(Resource.Id.zero).Click += (o, e) =>
            calculatorText.Text += "0";
            FindViewById<Button>(Resource.Id.dzero).Click += (o, e) =>
            calculatorText.Text += "00";

            FindViewById<Button>(Resource.Id.plus).Click += (o, e) =>
            calculatorText.Text += " + ";
            FindViewById<Button>(Resource.Id.minus).Click += (o, e) =>
            calculatorText.Text += " - ";
            FindViewById<Button>(Resource.Id.multiply).Click += (o, e) =>
            calculatorText.Text += "*";
            FindViewById<Button>(Resource.Id.divide).Click += (o, e) =>
            calculatorText.Text += "/";

            FindViewById<Button>(Resource.Id.dot).Click += (o, e) =>
            calculatorText.Text += ".";

            FindViewById<Button>(Resource.Id.del).Click += (o, e) =>
            calculatorText.Text = delete(calculatorText.Text);

            FindViewById<Button>(Resource.Id.equals).Click += (o, e) =>
            calculatorText.Text = calculate(calculatorText.Text);
        }

        private string calculate(string expression)
        {
            string[] expressions = expression.Split(" ");

            for (int i = 0; i < expressions.Length; i++)
            {
                if (hasAnOperation(expressions[i].ToCharArray()))
                {
                    expressions[i] = calcExpression(expressions[i]);
                }
            }

            for (int i = 1; i < expressions.Length - 1; i += 2)
            {
                expressions[i + 1] = basicCalc(expressions[i - 1], expressions[i], expressions[i + 1]);
            }

            return expressions[expressions.Length - 1];
        }

        private string calcExpression(string expression)
        {
            string[] splExpression = splitExpression(expression);

            for (int i = 1; i < splExpression.Length - 1; i += 2)
            {
                splExpression[i + 1] = basicCalc(splExpression[i - 1], splExpression[i], splExpression[i + 1]);
            }

            return splExpression[splExpression.Length - 1];
        }

        private string basicCalc(string a, string operation, string b)
        {
            string result = "";

            if (operation.Equals("*"))
            {
                result = (double.Parse(a) * double.Parse(b)).ToString();
            }
            if (operation.Equals("/"))
            {
                result = (double.Parse(a) / double.Parse(b)).ToString();
            }
            if (operation.Equals("+"))
            {
                result = (double.Parse(a) + double.Parse(b)).ToString();
            }
            if (operation.Equals("-"))
            {
                result = (double.Parse(a) - double.Parse(b)).ToString();
            }

            return result;
        }

        private string[] splitExpression(string expression)
        {
            ArrayList list = new ArrayList();
            char[] chars = expression.ToCharArray();

            int k = 0, start = k;
            string temp = "";

            while (k != chars.Length)
            {
                if (isOperation(chars[k]))
                {
                    for (int i = start; i < k; i++)
                    {
                        temp += chars[i];
                    }
                    list.Add(temp);
                    list.Add("" + chars[k]);
                    start = k + 1;
                    temp = "";
                }
                k++;
            }

            for (int i = start; i < chars.Length; i++)
            {
                temp += chars[i];
            }
            list.Add(temp);
            string[] array = (string[])list.ToArray(typeof(string));

            return array;
        }

        private bool isOperation(char c)
        {
            bool result = false;

            if (c == '*' || c == '/')
            {
                result = true;
            }

            return result;
        }

        private bool hasAnOperation(char[] chars)
        {
            bool result = false;

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '*' || chars[i] == '/')
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private string delete(string text)
        {
            char[] chars = text.ToCharArray();
            string result = "";

            for (int i = 0; i < chars.Length - 1; i++) {
                result += chars[i];
            }

            return result;
        }
    }
}