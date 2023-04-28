using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;

namespace ConsoleApp1;

class Program
{
    static async Task Main(string[] args)
    {
        Tas t = new Tas();
        await t.tas1();
        Console.WriteLine("finished");
        Console.ReadKey();
    }
}

public class Tas
{
    public async Task tas1()
    {
        string endpoint = "https://cogniteveservices.cognitiveservices.azure.com/";
        string apiKey = "e4d7376d96d8471cba771af20e6d9110";
        var credential = new AzureKeyCredential(apiKey);
        var client = new DocumentAnalysisClient(new Uri(endpoint), credential);

        
        
        string modelId = "ef1da940-cf12-4858-a4e3-c3d01c222a3e";

        Uri fileUri =
            new Uri(
                "https://user-images.githubusercontent.com/127695615/225075521-b30eb6e6-7b70-4106-9e53-c1cecb10a04e.jpeg");

        AnalyzeDocumentOperation operation =
            await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, modelId, fileUri);
        AnalyzeResult result = operation.Value;

        Console.WriteLine($"Document was analyzed with model with ID: {result.ModelId}");

        foreach (AnalyzedDocument document in result.Documents)
        {
            Console.WriteLine($"Document of type: {document.DocumentType}");

            foreach (KeyValuePair<string, DocumentField> fieldKvp in document.Fields)
            {
                string fieldName = fieldKvp.Key;
                DocumentField field = fieldKvp.Value;

                Console.WriteLine($"Field '{fieldName}': ");

                Console.WriteLine($"  Content: '{field.Content}'");
                Console.WriteLine($"  Confidence: '{field.Confidence}'");
            }
        }
    }
}