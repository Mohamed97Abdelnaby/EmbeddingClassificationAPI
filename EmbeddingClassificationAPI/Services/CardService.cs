using EmbeddingClassificationAPI.Services;
using EmbeddingClassificationAPI.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmbeddingClassificationAPI.Services
{
    public class CardService
    {
        private readonly EmbeddingService _embeddingService;
        private readonly string _filePath;

        public CardService(EmbeddingService embeddingService, IConfiguration configuration)
        {
            _embeddingService = embeddingService;
            _filePath = configuration.GetValue<string>("ExcelFilePath");
        }

        public async Task<string> FindMostSimilarCardAsync(string sampleText)
        {
            var cards = LoadCards();
            var inputEmbedding = await _embeddingService.GetEmbeddingAsync(sampleText);

            // Here, you need to calculate cosine similarity and find the most similar card
            // For simplicity, assume the method FindMostSimilarCard is implemented
            var mostSimilarCard = FindMostSimilarCard(inputEmbedding, cards);
            return mostSimilarCard;
        }

        public async Task AddNewCardAsync(string cardName, string sampleText)
        {
            var cards = LoadCards();
            var newEmbedding = await _embeddingService.GetEmbeddingAsync(sampleText);

            // Add new card and save to file
            cards.Add(new Card
            {
                CardName = cardName,
                SampleText = sampleText,
                Embedding = newEmbedding
            });

            SaveCards(cards);
        }

        private List<Card> LoadCards()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Card>();
            }

            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Card>>(json) ?? new List<Card>();
        }

        private void SaveCards(List<Card> cards)
        {
            var json = JsonConvert.SerializeObject(cards);
            File.WriteAllText(_filePath, json);
        }

        private string FindMostSimilarCard(float[] inputEmbedding, List<Card> cards)
        {
            // Implement the logic to find the most similar card
            // For simplicity, assume this method returns the card with the highest similarity
            return cards.First().CardName;
        }
    }
}
