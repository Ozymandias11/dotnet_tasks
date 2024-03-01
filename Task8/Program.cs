using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static async Task Main()
    {
        string apiUrl = "https://restcountries.com/v3.1/all";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Make a GET request to the REST API
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                // Check if the request was successful (status code 200)
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Parse the JSON response
                    JArray countriesArray = JArray.Parse(responseBody);

                    // Process each country in the array
                    foreach (var country in countriesArray)
                    {
                        // Extract required fields
                        string countryName = country["name"]["common"].ToString();
                        string region = country["region"]?.ToString() ?? "N/A";
                        string subregion = country["subregion"]?.ToString() ?? "N/A";
                        string latlng = country["latlng"] != null ? string.Join(", ", country["latlng"]) : "N/A";
                        string area = country["area"]?.ToString() ?? "N/A";
                        string population = country["population"]?.ToString() ?? "N/A";

                        // Create a text document for each country
                        string fileName = $"{countryName}.txt";
                        using (StreamWriter sw = new StreamWriter(fileName))
                        {
                            // Write the information to the file
                            sw.WriteLine($"Country: {countryName}");
                            sw.WriteLine($"Region: {region}");
                            sw.WriteLine($"Subregion: {subregion}");
                            sw.WriteLine($"LatLng: {latlng}");
                            sw.WriteLine($"Area: {area}");
                            sw.WriteLine($"Population: {population}");
                        }

                        Console.WriteLine($"File created: {fileName}");
                    }
                }
                else
                {
                    //raise some error message
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
