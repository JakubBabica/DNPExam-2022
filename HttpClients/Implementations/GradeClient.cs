﻿using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class GradeClient:IGradeService
{
    private readonly HttpClient client;

    public GradeClient(HttpClient httpClient)
    {
        this.client = httpClient;
    }
    public async Task<GradeInCourse> CreateAsync(NewGradeDTO dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7119/Grade", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        GradeInCourse grade = JsonSerializer.Deserialize<GradeInCourse>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return grade;
    }

    public async Task<IEnumerable<GradeInCourse>> GetAll()
    {
        HttpResponseMessage response = await client.GetAsync("https://localhost:7119/Grade");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        IEnumerable<GradeInCourse> grades= JsonSerializer.Deserialize<IEnumerable<GradeInCourse>>(result, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        })!;
        return grades;
    }

    public async Task<ICollection<GradeInCourse>> Display(StatisticsOverviewDto dto)
    {
        HttpResponseMessage response = await client.GetAsync("/Grade" + dto);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<GradeInCourse> display = JsonSerializer.Deserialize<ICollection<GradeInCourse>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return display;
    }
}