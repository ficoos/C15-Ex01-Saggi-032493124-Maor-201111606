using System.Xml.Serialization;

using FacebookWrapper.ObjectModel;

namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
	public interface IPostFilter : IXmlSerializable
	{
		bool IsMatch(Post i_Post);

		bool Enabled { get; set; }
	}
}