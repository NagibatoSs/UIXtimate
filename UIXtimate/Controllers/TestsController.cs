using Microsoft.AspNetCore.Mvc;
using UIXtimate.Assessments;

namespace UIXtimate.Controllers
{
    public class TestsController: Controller
    {
        private readonly IWebHostEnvironment _webHost;
        public TestsController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(List<IFormFile> UploadedFiles)
        {
            string uploadFolder = Path.Combine(_webHost.WebRootPath, "Files");
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            foreach (var uploadedFile in UploadedFiles)
            {
                string fileName = Path.GetFileName(uploadedFile.FileName);
                string fileSavePath = Path.Combine(uploadFolder, fileName);
                using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(stream);
                }
                var assess1 = new ControlElementsAssessment();
                var assess2 = new LongParagraphsAssessment();
                var assess = new RepeatingElementsAssessment();
                assess.Process();
                assess1.Process();
                assess2.Process();
                Assessment.DeleteAllFiles();
                ViewBag.Message = String.Format("Rate = {0}, Message = {1}", assess.Rate, assess.RateMessage);
                ViewBag.Message += String.Format("Rate = {0}, Message = {1}", assess1.Rate, assess1.RateMessage);
                ViewBag.Message += String.Format("Rate = {0}, Message = {1}", assess2.Rate, assess2.RateMessage);
            }

            return View();
        }
    }
}
