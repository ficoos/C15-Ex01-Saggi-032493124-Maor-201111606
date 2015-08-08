using System.Collections.Generic;


namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
	public class CannedPost
	{

		public string Name { get; set; }

		private readonly List<string> r_Categories = new List<string>();

		public Template StatusTextTemplate { get; set; }

		public List<string> Categories
		{
			get
			{
				return r_Categories;
			}
		}

		public PostInfo GeneratePost()
		{
			return new PostInfo()
						{
							StatusText = this.StatusTextTemplate == null ? string.Empty : this.StatusTextTemplate.ToString()
						};
		}

		public CannedPost() : this(string.Empty)
		{
		}

		public CannedPost(string i_Name)
		{
			Name = i_Name;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}