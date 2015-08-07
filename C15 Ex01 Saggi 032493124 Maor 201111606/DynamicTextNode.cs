namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
	public class DynamicTextNode : ITextNode
	{
		public string Name { get; private set; }

		public string Text { get; set; }

		public DynamicTextNode(string i_Name)
		{
			Text = string.Empty;
			Name = i_Name;
		}
	}
}