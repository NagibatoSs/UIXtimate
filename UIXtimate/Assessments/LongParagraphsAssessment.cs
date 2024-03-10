

namespace UIXtimate.Assessments
{
    public class LongParagraphsAssessment : Assessment
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        int wordsCountInParagraph = 5;
        public override Tuple<double, string> DoAssessment(string xamlText)
        {
            Rate = 10;

            string[] arr;
            char[] chars = { '\r', '\n' };
            arr = xamlText.Split(chars);
            arr = arr.Where((element, index) => index % 2 == 0).ToArray();

            var tagsForCheck = GetTags();
            var tags = xamlText
               .Split(' ');
            RateMessage =
                "Оценка на наличие длинных абзацев: ";
            for (int i = 0; i < arr.Length;i++)
            {
                if (arr[i].Contains("TextBlock"))
                {
                    if (arr[i].Contains("/>") || arr[i].Contains("</TextBlock"))
                    {
                        //Если textbox проверять Text = и Content
                        var textEndIndex = arr[i].IndexOf("</Text");
                        var textStartIndex = arr[i].IndexOf("Text=");
                        if (textStartIndex > 0)
                        {
                            textStartIndex += 6;
                            var secondPartOfStr = arr[i].Substring(textStartIndex);
                            textEndIndex = secondPartOfStr.IndexOf("\"");
                            if (textEndIndex > 0)
                                textEndIndex+= textStartIndex;
                        }
                        if (textStartIndex < 0)
                        {
                           // textEndIndex = arr[i].IndexOf("</Text");
                            textStartIndex = arr[i].IndexOf(">");
                        }

                        var text = arr[i].Substring(textStartIndex, textEndIndex - textStartIndex);
                        var count = text.Split(' ').Count();
                        if (count>wordsCountInParagraph)
                        {
                            RateMessage += "Слишком длинный абзац " + text.Substring(1,15) + "... ";
                            Rate -= 1;
                        }
                    }
                    //написать иначе, если абзац кончается на жругой строке
                }   
                   
            }
            return Tuple.Create(Rate, RateMessage);
        }

        private string[] GetTags()
        {
            //Изменить с появлением БД
            return new string[] { "<TextBox", "<RichTextBox", "<Label", "<TextBlock" };
        }
    }
}
