using MSE.DTO.DTOs.WorkStation;
using Newtonsoft.Json;
using System.Text;

var random = new Random();

var data = new WorkStationRandomValueDTO
{
    WorkStationId = random.Next(1, 100),
    Temperature = (decimal)Math.Round(random.NextDouble() * 100, 2),
    Pressure = (decimal)Math.Round(random.NextDouble() * 2000, 2),
    Status = random.Next(0, 1) == 1
};
var json = JsonConvert.SerializeObject(data);
var content = new StringContent(json, Encoding.UTF8, "application/json");

using (var client = new HttpClient())
{
    var response = client.PostAsync("http://localhost:5002/WorkStationRandom/Post", content).Result;
    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine("Data saved successfully!");
    }
    else
    {
        Console.WriteLine("Failed to save data: " + response.StatusCode);
    }
}