using ExaminationSystem.Administration.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ExaminationSystem.Administration.Pages
{
    public class CreateQuestionsModel : PageModel
    {
        public CreateQuizDetails CreateQuizDetails { get; set; }
        public async Task<IActionResult> OnPost()
        {
            String conn = "https://localhost:44302/api/CreateQuizDetails";
            ResultDTO resultDTO = new ResultDTO();

            using (var httpClient = new HttpClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage();

                using (var response = await httpClient.PostAsync(conn, httpRequestMessage.Content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    resultDTO = JsonConvert.DeserializeObject<ResultDTO>(apiResponse);
                    if (resultDTO != null && resultDTO.IsSuccess)
                    {
                        return RedirectToPage("/Index");
                    }
                    return Page();
                }
            }
        }
    }
    public class CreateQuizDetails()
    {
        public int QuizID { get; set; }
        public List<CreateQuestions> Questions { get; set; }
    }

    public class CreateQuestions()
    {
        public string Text { get; set; }
        public int Type { get; set; }
        public List<CreateChoises> Choises { get; set; }
    }

    public class CreateChoises()
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
