using TRAININGMANAGER.Shared.Parameters;
using System.Net.Http.Json;
using System.Net;
using TRAININGMANAGER.Shared.Models;
using TRAININGMANAGER.Shared.Dtos;
using TRAININGMANAGER.Shared.Extensions;
using TRAININGMANAGER.Shared.Responses;
using Newtonsoft.Json;

namespace TRAININGMANAGER.HttpService.Service
{
    public class TrainerService : ITrainerService
    {
        private readonly HttpClient? _httpClient;

        public TrainerService(IHttpClientFactory? httpClientFactory)
        {
            if (httpClientFactory is not null)
            {
                _httpClient = httpClientFactory.CreateClient("TrainingManagerApi");
            }
        }
        public async Task<List<Trainer>> SelectAllTrainerAsync()
        {
            if (_httpClient is not null)
            {
                List<TrainerDto>? result = await _httpClient.GetFromJsonAsync<List<TrainerDto>>("api/Trainer");
                if (result is not null)
                    return result.Select(trainersDto => trainersDto.ToModel()).ToList();
            }
            return new List<Trainer>();
        }

        public async Task<ControllerResponse> UpdateAsync(TrainerDto trainerDto)
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    HttpResponseMessage httpResponse = await _httpClient.PutAsJsonAsync("api/Trainer", trainerDto);
                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        ControllerResponse? response = JsonConvert.DeserializeObject<ControllerResponse>(content);
                        if (response is null)
                        {
                            defaultResponse.ClearAndAddError("A törlés http kérés hibát okozott!");
                        }
                        else return response;
                    }
                    else if (!httpResponse.IsSuccessStatusCode)
                    {
                        httpResponse.EnsureSuccessStatusCode();
                    }
                    else
                    {
                        return defaultResponse;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            defaultResponse.ClearAndAddError("Az adatok frissítés nem lehetséges!");
            return defaultResponse;
        }

        public async Task<ControllerResponse> DeleteAsync(Guid id)
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    HttpResponseMessage httpResponse = await _httpClient.DeleteAsync($"api/Trainer/{id}");
                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        ControllerResponse? response = JsonConvert.DeserializeObject<ControllerResponse>(content);
                        if (response is null)
                        {
                            defaultResponse.ClearAndAddError("A törlés http kérés hibát okozott!");
                        }
                        else return response;
                    }
                    else if (!httpResponse.IsSuccessStatusCode)
                    {
                        httpResponse.EnsureSuccessStatusCode();
                    }
                    else
                    {
                        return defaultResponse;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            defaultResponse.ClearAndAddError("Az adatok törlés nem lehetséges!");
            return defaultResponse;
        }

        public async Task<ControllerResponse> InsertAsync(Trainer trainer)
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
                HttpResponseMessage? httpResponse = null;
                try
                {
                    httpResponse = await _httpClient.PostAsJsonAsync("api/Trainer", trainer);
                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        ControllerResponse? response = JsonConvert.DeserializeObject<ControllerResponse>(content);
                        if (response is null)
                        {
                            defaultResponse.ClearAndAddError("A mentés http kérés hibát okozott!");
                        }
                        else return response;
                    }
                    else if (!httpResponse.IsSuccessStatusCode)
                    {
                        httpResponse.EnsureSuccessStatusCode();
                    }
                    else
                    {
                        return defaultResponse;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            defaultResponse.ClearAndAddError("Az adatok mentése nem lehetséges!");
            return defaultResponse;
        }

        public async Task<List<Trainer>> SearchAndFilterTrainersAsync(TrainerQueryParameters trainerQueryParameters)
        {
            if (_httpClient is not null)
            {
                HttpResponseMessage? httpResponse = null;
                try
                {
                    httpResponse = await _httpClient.PostAsJsonAsync("api/Trainer/queryparameters", trainerQueryParameters.ToDto());
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        List<TrainerDto>? trainers = JsonConvert.DeserializeObject<List<TrainerDto>>(content);
                        if (trainers is not null)
                        {
                            return trainers.Select(trainerDto => trainerDto.ToModel()).ToList();
                        }
                    }
                    else if (!httpResponse.IsSuccessStatusCode)
                    {
                        httpResponse.EnsureSuccessStatusCode();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            return new List<Trainer>();
        }
    }
}
