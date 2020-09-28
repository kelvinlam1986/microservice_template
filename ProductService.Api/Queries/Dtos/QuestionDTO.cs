using Newtonsoft.Json;
using ProductService.Api.Queries.Converters;
using System.Collections;
using System.Collections.Generic;

namespace ProductService.Api.Queries.Dtos
{
    [JsonConverter(typeof(QuestionDtoConverter))]
    public abstract class QuestionDTO
    {
        public string QuestionCode { get; set; }
        public int Index { get; set; }
        public string Text { get; set; }
        public abstract QuestionType QuestionType { get; }
    }

    public enum QuestionType
    {
        Choice,
        Date,
        Numeric
    }

    public class ChoiceQuestionDTO : QuestionDTO
    {
        public override QuestionType QuestionType => QuestionType.Choice;
        public IList<ChoideDTO> Choices { get; set; }
    }

    public class DateQuestionDTO : QuestionDTO
    {
        public override QuestionType QuestionType => QuestionType.Date;
    }

    public class NumericQuestionDTO : QuestionDTO
    {
        public override QuestionType QuestionType => QuestionType.Numeric;
    }
}
