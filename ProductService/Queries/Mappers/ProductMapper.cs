using ProductService.Api.Queries.Dtos;
using ProductService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Queries.Mappers
{
    public static class ProductMapper
    {
        public static IList<CoverDTO> ToCoverDtoList(IList<Cover> covers)
        {
            return covers?.Select(c => ToCoverDto(c)).ToList();
        }

        public static IList<QuestionDTO> ToQuestionDtoList(IList<Question> questions)
        {
            return questions?.Select(q => ToQuestionDto(q)).ToList();
        }

        private static CoverDTO ToCoverDto(Cover cover)
        {
            return new CoverDTO
            {
                Code = cover.Code,
                Name = cover.Name,
                Desctiption = cover.Description,
                Optional = cover.Optional,
                SumInsured = cover.SumInsured
            };
        }

        private static QuestionDTO ToQuestionDto(Question question)
        {
            switch (question.GetType().Name)
            {
                case "NumericQuestion":
                    return new NumericQuestionDTO { QuestionCode = question.Code, Index = question.Index, Text = question.Text };
                case "ChoiceQuestion":
                    return new ChoiceQuestionDTO
                    {
                        QuestionCode = question.Code,
                        Index = question.Index,
                        Text = question.Text,
                        Choices = ((ChoiceQuestion)question).Choices?.Select(c => new ChoideDTO { Code = c.Code, Label = c.Label }).ToList()
                    };
                case "DateQuestion":
                    return new DateQuestionDTO { QuestionCode = question.Code, Index = question.Index, Text = question.Text };

                default:
                    throw new ArgumentOutOfRangeException(question.GetType().Name);
            }
        }
    }
}
