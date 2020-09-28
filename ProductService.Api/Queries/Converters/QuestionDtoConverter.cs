using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductService.Api.Queries.Dtos;
using System;


namespace ProductService.Api.Queries.Converters
{
    public class QuestionDtoConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(QuestionDTO));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var target = Create(jsonObject);
            serializer.Populate(jsonObject.CreateReader(), target);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is QuestionDTO questionAnswer)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("index");
                serializer.Serialize(writer, questionAnswer.Index);
                writer.WritePropertyName("questionCode");
                serializer.Serialize(writer, questionAnswer.QuestionCode);
                writer.WritePropertyName("questionType");
                serializer.Serialize(writer, questionAnswer.QuestionType);
                writer.WritePropertyName("text");
                serializer.Serialize(writer, questionAnswer.Text);
                if (questionAnswer is ChoiceQuestionDTO choiceQuestion)
                {
                    writer.WritePropertyName("choices");
                    serializer.Serialize(writer, choiceQuestion.Choices);
                }
                writer.WriteEndObject();
            }
        }

        private static QuestionDTO Create(JObject jsonObject)
        {
            var typeName = Enum.Parse<QuestionType>(jsonObject["questionType"].ToString());
            switch (typeName)
            {
                case QuestionType.Choice:
                    return new ChoiceQuestionDTO
                    {
                        QuestionCode = jsonObject["questionCode"].ToString(),
                        Text = jsonObject["text"].ToString()
                    };
                case QuestionType.Date:
                    return new DateQuestionDTO
                    {
                        QuestionCode = jsonObject["questionCode"].ToString(),
                        Text = jsonObject["text"].ToString()
                    };
                case QuestionType.Numeric:
                    return new NumericQuestionDTO
                    {
                        QuestionCode = jsonObject["questionCode"].ToString(),
                        Text = jsonObject["text"].ToString()
                    };
                default:
                    throw new ApplicationException($"Unexpected question type {typeName}");
            }
        }
    }
}
