using ExaminationSystem.Administration.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ExaminationSystem.Administration.Pages
{
    public class CreateQuizModel : PageModel
    {
        [BindProperty]
        public QuizDto Quiz { get; set; }

        

        public async Task<IActionResult> OnPost()
        {
            String conn = "https://localhost:44302/api/CreateQuiz";
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
}
