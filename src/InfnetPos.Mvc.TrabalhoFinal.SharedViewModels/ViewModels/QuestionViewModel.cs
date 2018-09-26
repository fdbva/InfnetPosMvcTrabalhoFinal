using System.Runtime.Serialization;

namespace InfnetPos.Mvc.TrabalhoFinal.SharedViewModels.ViewModels
{
    [DataContract]
    public class QuestionViewModel : BaseViewModel
    {
        [DataMember] public string Text { get; set; }
    }
}