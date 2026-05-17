using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _8_Async_Await_Data_Dashboard {
    public class ApiService {
        // Simulates API call that processes user input names
        public async Task<List<string>> FetchDataFromAPIAsync(List<string> inputNames) {
            await Task.Delay(2000); // Simulates network delay

            // Process the input names (simulate API transformation)
            var processedNames = new List<string>();
            foreach (var name in inputNames) {
                await Task.Delay(100);
                processedNames.Add(name.Trim());
            }

            return processedNames;
        }
    }
}