using System.Collections.Generic;

namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
	public class CannedPost
	{
		public string Name { get; set; }

		public Template StatusTextTemplate { get; set; }

		private readonly List<string> r_Categories = new List<string>();

		public List<string> Categories
		{
			get
			{
				return r_Categories;
			}
		}

		public PostInfo GeneratePost(IEnumerable<KeyValuePair<string, string>> i_StatusTemplateReplacementPairs)
		{
			return new PostInfo()
						{
							StatusText = this.StatusTextTemplate == null ? string.Empty : this.StatusTextTemplate.Compile(i_StatusTemplateReplacementPairs)
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