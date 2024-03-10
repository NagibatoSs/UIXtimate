using System.Text.RegularExpressions;

namespace UIXtimate.Assessments
{
    //Content="Нажать"
    //<TextBlock>Hello!</TextBlock> -- про текст
    public class RepeatingElementsAssessment : Assessment
    {
        //Пока просто считает количество повторений тегов, надо как то сравнивать еще по контенту\тексту
        //Тут добавить спрашивание - должно ли быть так
        Dictionary<string, int> dict = new Dictionary<string, int>(); 
        public override Tuple<double, string> DoAssessment(string xamlText)
        {
            Rate = 10;

            var tagsForCheck = GetTags();
            var tags = xamlText
                .Split(' ')
                .Where(word => tagsForCheck.Contains(word));
            foreach(var tag in tags)
            {
                if (dict.ContainsKey(tag))
                    dict[tag] += 1;
                else
                    dict[tag] = 1;
            }
            RateMessage =
                "Оценка на наличие повторяющихся элементов: ";
            foreach (var tag in dict)
            {
                if (tag.Value > 3)
                {
                    RateMessage += "Многократное повторение элемента " + tag.Key.Trim('<') + " ";
                    Rate -= 0.5;
                }
            }
            return Tuple.Create(Rate, RateMessage);
        }
        private string[] GetTags()
        {
            //Изменить с появлением БД
            return new string[] { "<Button", "<CheckBox", "<RadioButton",
                "<ToggleButton", "<RepeatButton", "ComboBox", "<Expander", "<Calendar",
                "<ScrollViewer","<TextBox", "<RichTextBox",
                "<Slider","<DatePicker","<PasswordBox","<TabItem","<TabControl",
                "<TreeView"};
        }
    }
}
