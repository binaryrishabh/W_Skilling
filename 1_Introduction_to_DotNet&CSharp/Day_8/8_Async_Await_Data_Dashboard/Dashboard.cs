using _8_Async_Await_Data_Dashboard;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _8_Async_Await_Data_Dashboard {
    public class Dashboard {
        private readonly ApiService _apiService;

        public Dashboard() {
            _apiService = new ApiService();
        }

        public async Task LoadAndDisplayDataAsync(List<string> names) {
            Console.WriteLine("\n📊 Dashboard Loading...");
            Console.WriteLine("⏳ Sending data to API (UI is responsive)...\n");

            List<string> result = await _apiService.FetchDataFromAPIAsync(names);

            Console.WriteLine("✅ Data received from API!\n");
            Console.WriteLine("Indian First Names (processed):");
            Console.WriteLine("------------------------------");

            for (int i = 0; i < result.Count; i++) {
                await Task.Delay(50);
                Console.WriteLine($"{i + 1}. {result[i]}");
            }

            Console.WriteLine($"\n📈 Total {result.Count} names processed.");
        }

        public void ShowResponsiveUI() {
            Console.WriteLine("🎨 Dashboard UI is responsive!");
            Console.WriteLine("💡 You can do other tasks while waiting for API...\n");
        }
    }
}