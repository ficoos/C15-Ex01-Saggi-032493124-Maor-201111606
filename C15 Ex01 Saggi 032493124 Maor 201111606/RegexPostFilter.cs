
using System.Text.RegularExpressions;

using System.Xml;
using System.Xml.Schema;

using FacebookWrapper.ObjectModel;

namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
	public class RegexPostFilter : IPostFilter
	{
		public Regex Regex { get; set; }

		public bool Enabled { get; set; }

		public override string ToString()
		{
			return Regex.ToString();
		}

		public bool IsMatch(Post i_Post)
		{
			bool result;

			if (i_Post.Name != null)
			{
				result = Regex.Match(i_Post.Name).Success;
			}
			else
			{
				result = false;
			}

			return result;
		}

		public RegexPostFilter()
		{
		}

		public RegexPostFilter(Regex i_Regex)
		{
			Regex = i_Regex;
			Enabled = true;
		}

		public RegexPostFilter(string i_RegexPattern)
			: this(new Regex(i_RegexPattern))
		{
		}

		public XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader i_Reader)
		{
			string rawRegex = i_Reader.GetAttribute("Regex");
			if (rawRegex != null)
			{
				Regex = new Regex(rawRegex);
			}

			string rawEnabled = i_Reader.GetAttribute("Enabled");
			if (rawEnabled == null)
			{
				Enabled = false;
			}
			else
			{
				Enabled = bool.Parse(rawEnabled);	
			}
		}

		public void WriteXml(XmlWriter i_Writer)
		{
			i_Writer.WriteAttributeString("Regex", Regex.ToString());
			i_Writer.WriteAttributeString("Enabled", Enabled.ToString());
		}
	}
}