using MessageRouter.Domain.Repositories;

namespace MessageRouter.Infrastructure.Repositories
{
    //This class would be a client for another API which can handle natural language processing
    public class NaturalLanguageRepository : INaturalLanguageRepository
    {
        //The Natural language processing server a machine learning model to analyze and classify the message body
        public bool GetMachineLearningClassificationOfContent(string messageBody)
        {
            return true;
        }
    }
}
