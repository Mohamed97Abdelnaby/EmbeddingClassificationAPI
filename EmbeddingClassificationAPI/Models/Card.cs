namespace EmbeddingClassificationAPI.Models
{
 
        public class Card
        {
            public string? CardName { get; set; }
            public string? SampleText { get; set; }
            public float[]? Embedding { get; set; }
        }
    

}
