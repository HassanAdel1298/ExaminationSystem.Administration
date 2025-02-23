using ExaminationSystem.Administration.Dtos;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ExaminationSystem.Administration.Pages;

public class IndexModel : PageModel
{
    public List<QuizDto> Quizzes { get; set; }

    public IndexModel()
    {
    }

    public async void OnGet()
    {
        String conn = "https://localhost:44302/api/SearchQuizzes";
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
                    Quizzes = resultDTO.Data;
                }
            }
        }
    }
}
