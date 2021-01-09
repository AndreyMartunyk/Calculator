namespace Assets.Scripts
{
    public enum CalcButton
    {
        none = -1,
        zero = 0,
        one = 1,
        two = 2,
        three = 3,
        four = 4,
        five = 5,
        six = 6,
        seven = 7,
        eight = 8,
        nine = 9,
        plus,
        minus,
        divide,
        multiply,
        equal,
        persent,
        power,
        root,
        c,
        ce,
        del,
        dot,
        reverseSign,
        dividedByOne,
    }

    public static class CalcButtonExtensions
    {
        public static string ToCalcScreenString(this CalcButton btn)
        {
            string res = "";
            switch (btn)
            {
                case CalcButton.none:
                    res = " ";
                    break;
                case CalcButton.zero:
                    res = "0";
                    break;
                case CalcButton.one:
                    res = "1";
                    break;
                case CalcButton.two:
                    res = "2";
                    break;
                case CalcButton.three:
                    res = "3";
                    break;
                case CalcButton.four:
                    res = "4";
                    break;
                case CalcButton.five:
                    res = "5";
                    break;
                case CalcButton.six:
                    res = "6";
                    break;
                case CalcButton.seven:
                    res = "7";
                    break;
                case CalcButton.eight:
                    res = "8";
                    break;
                case CalcButton.nine:
                    res = "9";
                    break;
                case CalcButton.plus:
                    res = "+";
                    break;
                case CalcButton.minus:
                    res = "-";
                    break;
                case CalcButton.divide:
                    res = "÷";
                    break;
                case CalcButton.multiply:
                    res = "x";
                    break;
                case CalcButton.equal:
                    res = "=";
                    break;
                case CalcButton.persent:
                    res = "%";
                    break;
                case CalcButton.power:
                    res = "x2";
                    break;
                case CalcButton.root:
                    res = "²√x";
                    break;
                case CalcButton.c:
                    res = "c";
                    break;
                case CalcButton.ce:
                    res = "ce";
                    break;
                case CalcButton.del:
                    res = "←";
                    break;
                case CalcButton.dot:
                    res = ",";
                    break;
                case CalcButton.reverseSign:
                    res = "⁺/₋";
                    break;
                default:
                    res = "";
                    break;
            }

            return res;
        }

    }
}
