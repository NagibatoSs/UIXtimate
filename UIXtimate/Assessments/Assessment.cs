using System.Collections;

namespace UIXtimate.Assessments
{
    public abstract class Assessment
    {
        public double Rate
        {
            get
            {
                return _rate;
            }
            protected set
            {
                _rate = value;
                if (value < 0)
                    _rate = 0;
                if (value > 10)
                    _rate = 10;
            }
        }
        private double _rate;
        public string RateMessage { get; protected set; }
        protected string xamlText;

        private static string path = "wwwroot\\Files";

        public void Process()
        {
            xamlText = ReadFiles();
            (Rate, RateMessage) = DoAssessment(xamlText);
        }
        public abstract Tuple<double,string> DoAssessment(string xamlText);

        private string ReadFiles()
        {
            IEnumerable<string> files = Directory.EnumerateFiles(path);
            WindowAssessment wa = new WindowAssessment();
            string xamlText = "";
            foreach (var file in files)
            {
                xamlText += (wa.ReadFileAsync(file)).Result;
            }
            return xamlText;
        }

        public static void DeleteAllFiles()
        {
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo file in di.EnumerateFiles())
            {
                file.Delete();
            }
        }
    }
}
