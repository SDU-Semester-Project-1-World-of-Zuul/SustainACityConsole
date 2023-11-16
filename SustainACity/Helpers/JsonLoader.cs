using SustainACity.Model;
using System.Text.Json;

namespace SustainACity.Helpers;

public class JsonLoader
{
    private readonly string _roomsFilePath;

    public JsonLoader(string roomsFilePath)
    {
        _roomsFilePath = Path.Combine(AppContext.BaseDirectory, "Data\\" + roomsFilePath);
    }

    public List<Room> LoadRooms()
    {
        try
        {
            string json = File.ReadAllText(_roomsFilePath);
            var rooms = JsonSerializer.Deserialize<List<Room>>(json);
            return rooms ?? new List<Room>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading rooms: {ex.Message}");
            return new List<Room>();
        }
    }
}