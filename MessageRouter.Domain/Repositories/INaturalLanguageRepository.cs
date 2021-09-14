namespace MessageRouter.Domain.Repositories
{
    public interface INaturalLanguageRepository
    {
        bool GetMachineLearningClassificationOfContent(string messageBody);
    }
}
