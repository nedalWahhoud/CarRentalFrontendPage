using CarRentalFrontendPage.Models;
using System.Text.Json;

namespace CarRentalFrontendPage.CarF
{
    public class CarService(IWebHostEnvironment env)
    {
        public readonly List<Car> DownloadedCars = [];
        public readonly IWebHostEnvironment _env = env;

        public event Action<int>? OnCarPageChange;
        public void SetCurrentCarId(int id)
        {
            OnCarPageChange?.Invoke(id);
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            if (DownloadedCars.Count > 0)
            {
                return DownloadedCars;
            }
            try
            {
                var filePath = Path.Combine(_env.ContentRootPath, "Data", "cars.json");
                if (File.Exists(filePath))
                {
                    var json = await File.ReadAllTextAsync(filePath);

                    List<Car> cars = JsonSerializer.Deserialize<List<Car>>(json,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        })?
                        .Where(c => c.IsActive)
                        .ToList()
                        ?? [];

                    AddCarToLocal(cars);

                    return cars;
                }
                else
                {
                    Console.WriteLine("Cars data file not found.");
                    return null!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading cars data: {ex.Message}");
                return null!;
            }
        }
        private async Task<Car> GetCarByIdFromJson(int id)
        {
            try
            {
                var filePath = Path.Combine(_env.ContentRootPath, "Data", "cars.json");
                if (File.Exists(filePath))
                {
                    var json = await File.ReadAllTextAsync(filePath);

                    Car cars = JsonSerializer.Deserialize<List<Car>>(json,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        })?
                        .Where(c => c.Id == id && c.IsActive)
                        .FirstOrDefault()
                        ?? new();


                    return cars;
                }
                else
                {
                    Console.WriteLine("Cars data file not found.");
                    return new Car();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading cars data: {ex.Message}");
                return new Car();
            }
        }
        public async Task<GetItems<Car>> GetCarsAsync(GetItems<Car> getItems)
        {
            if (getItems == null)
                return new GetItems<Car>();

            if (getItems.AllItemsLoaded)
                return getItems;
            try
            {

                List<Car> allCar = [];
                if (DownloadedCars.Count > 0)
                    allCar = DownloadedCars;
                else
                    allCar = await GetAllCarsAsync();

                var carsPage = allCar
                    .Where(c => !getItems.excludedCarIds.Contains(c.Id))
                    .OrderBy(_ => Guid.NewGuid())
                    .Take(getItems.PageSize)
                    .ToList();

                if (carsPage.Count > 0)
                    getItems.excludedCarIds.AddRange(carsPage.Select(c => c.Id));


                bool allItemsLoaded = getItems.Items.Count >= allCar.Count;

                getItems.AllItemsLoaded = allItemsLoaded;
                getItems.Items.AddRange(carsPage);

                return getItems;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading cars data: {ex.Message}");
                return null!;
            }
        }
        public async Task<Car> GetCarById(int id)
        {
            return DownloadedCars.FirstOrDefault(c => c.Id == id) ?? await GetCarByIdFromJson(id);
        }
        // local
        public void AddCarToLocal(List<Car> cars)
        {
            if (cars.Count > 0 && DownloadedCars.Count == 0)
            {
                DownloadedCars.AddRange(cars);
                return;
            }

            foreach (var car in cars)
            {
                if (!DownloadedCars.Any(p => p.Id == car.Id))
                {
                    DownloadedCars.Add(car);
                }
            }
        }
        public void AddCarToLocal(Car car)
        {
            if (!DownloadedCars.Any(p => p.Id == car.Id))
            {
                DownloadedCars.Add(car);
            }
        }
    }
}
