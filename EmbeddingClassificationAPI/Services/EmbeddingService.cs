using OpenAI;
using OpenAI.Models;
using System.Threading.Tasks;



namespace EmbeddingClassificationAPI.Services
{
    public class EmbeddingService
    {
        private readonly OpenAIClient _client;

        public EmbeddingService(string apiKey)
        {
            _client = new OpenAIClient(apiKey);
        }

        public async Task<float[]> GetEmbeddingAsync(string text)
        {
                        var response = await _client.GetEmbeddingClient("text-embedding-ada-002").GenerateEmbeddingAsync(text);
            return response.Value.Vector.ToArray();
            
        }
    }
}
