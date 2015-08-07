namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
	public class StaticTextNode : ITextNode
	{
		public string Text { get; private set; }

		public StaticTextNode(string i_Text)
		{
			this.Text = i_Text;
		}
	}
}