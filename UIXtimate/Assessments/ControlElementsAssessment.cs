using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

namespace UIXtimate.Assessments
{

    public class ControlElementsAssessment : Assessment
    {
        private int elementsCount;
        double koef = 0.07;
        const int etalonCount = 7;
        const int minEtalon = etalonCount - 2;
        const int maxEtalon = etalonCount + 2;
        public override Tuple<double, string> DoAssessment(string xamlText)
        {
            //Вопрос соловьевой, а что делать если слишком мало элементов? Считать ли это за недостаток, или просто оставлять 10?
            //Пока сделаю, что это недочет
            CountElements();
            CalculateRate();

            if (elementsCount > maxEtalon)
            {
                RateMessage =
                       "Оценка по количеству управляющих элементов - эталон 7±2: Cлишком много элементов - " + elementsCount;
            }
            if (elementsCount < minEtalon)
            {
                RateMessage =
                       "Оценка по количеству управляющих элементов - эталон 7±2: Cлишком мало элементов - " + elementsCount;
            }
            if (elementsCount >= minEtalon && elementsCount <= maxEtalon)
            {
                RateMessage =
                    "Оценка по количеству управляющих элементов - эталон 7±2: Элементов самый раз - " + elementsCount;
                Rate = 10;
            }
            return Tuple.Create(Rate, RateMessage);
        }

        private void CountElements()
        {
            string[] tags = GetTags();
            elementsCount = 0;
            foreach (var tag in tags)
                elementsCount += Regex.Matches(xamlText, "<" + tag).Count;
        }
        private void CalculateRate()
        {
            var percent = elementsCount * 100 / etalonCount;
            var minusPoints = Math.Abs(100 - percent) * koef;
            Rate = 10 - minusPoints;
        }
        private string[] GetTags()
        {
            //Изменить с появлением БД
            return new string[] { "Button", "CheckBox", "RadioButton",
                "ToggleButton", "RepeatButton", "Expander", "Calendar", 
                "ScrollViewer","TextBox","ComboBox", "RichTextBox",
                "Slider","DatePicker","PasswordBox","TabItem","TabControl",
                "Menu","TreeView"};
        }
    }
}
