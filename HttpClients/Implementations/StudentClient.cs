using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class StudentClient:IStudentService
{
    private readonly HttpClient client;

    public StudentClient(HttpClient httpClient)
    {
        this.client = httpClient;
    }
    public async Task<Student> CreateAsync(NewStudentDTO dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7119/Student", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        Student student = JsonSerializer.Deserialize<Student>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return student;
    }

    public async Task<IEnumerable<Student>> GetAll()
    {
        HttpResponseMessage response = await client.GetAsync("https://localhost:7119/Student");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        IEnumerable<Student> students= JsonSerializer.Deserialize<IEnumerable<Student>>(result, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        })!;
        return students;
    }
}