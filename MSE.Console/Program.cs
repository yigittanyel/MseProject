using MSE.DTO.DTOs.WorkStation;
using System.Net.Http.Json;

var random = new Random(DateTime.Now.Millisecond);
var data = new WorkStationRandomValueDTO
{
    WorkStationId = random.Next(1, 100),
    Temperature = (decimal)Math.Round(random.NextDouble() * 100, 2),
    Pressure = (decimal)Math.Round(random.NextDouble() * 2000, 2),
    Status = random.Next(0, 1) == 1
};


using (var client = new HttpClient())
{
    var content = new FormUrlEncodedContent(new[]
   {
        new KeyValuePair<string, string>("WorkStationId", data.WorkStationId.ToString()),
        new KeyValuePair<string, string>("Temperature", data.Temperature.ToString()),
        new KeyValuePair<string, string>("Pressure", data.Pressure.ToString()),
        new KeyValuePair<string, string>("Status", data.Status.ToString())
    });

    var response = await client.PostAsync("http://localhost:5002/WorkStationRandom/Post", content);

    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine($"Data saved successfully!\n\nWorkStationId:{data.WorkStationId}\nTemperature:{data.Temperature}\nPressure:{data.Pressure}\nStatus:{data.Status}");
    }
    else
    {
        Console.WriteLine("Failed to save data: " + response.StatusCode);
    }
}
Console.ReadLine();
