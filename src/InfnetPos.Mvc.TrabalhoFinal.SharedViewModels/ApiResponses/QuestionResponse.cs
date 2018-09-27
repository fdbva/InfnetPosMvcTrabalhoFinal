using System.Runtime.Serialization;

namespace InfnetPos.Mvc.TrabalhoFinal.SharedViewModels.ApiResponses
{
    [DataContract]
    public class QuestionResponse : BaseResponse
    {
        [DataMember]
        public string Text { get; set; }
    }
}