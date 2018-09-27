using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace InfnetPos.Mvc.TrabalhoFinal.SharedViewModels.ApiResponses
{
    [DataContract]
    public class BaseResponse
    {
        [Key]
        [DataMember]
        public Guid Id { get; set; }
    }
}