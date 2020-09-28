namespace ProductService.Domain
{
    public class Choice
    {
        public string Code { get; set; }
        public string Label { get; set; }

        public ChoiceQuestion Question { get; private set; }

        public Choice()
        {
        }

        public Choice(string code, string label)
        {
            Code = code;
            Label = label;
        }
    }
}
