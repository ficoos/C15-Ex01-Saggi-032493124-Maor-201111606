using System.Collections.Generic;
using System.Linq;

using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using FacebookWrapper.ObjectModel;

namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
	using System;

	public class PostFilterGroup : IXmlSerializable
    {
        public string Name { get; set; }

        public ePostPriority PostPriority { get; set; }

        private readonly List<IPostFilter> r_PostFilters;

		private static readonly Dictionary<string, XmlSerializer> sr_Serializers;

		static PostFilterGroup()
		{
			sr_Serializers = new Dictionary<string, XmlSerializer>();
			foreach (Type type in getAllPossibleFilterType())
			{
				sr_Serializers.Add(type.Name, new XmlSerializer(type));
			}
		}

	    public IList<IPostFilter> PostFilters
	    {
		    get
		    {
			    return r_PostFilters;
		    }
	    }

	    public bool Enabled { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public bool IsMatch(Post i_Post)
        {
	        return r_PostFilters.Any(i_PostFilter => i_PostFilter.IsMatch(i_Post));
        }

	    public PostFilterGroup() : this(string.Empty)
	    {
	    }

	    public PostFilterGroup(string i_Name, ePostPriority i_PostPriority = ePostPriority.Hidden)
        {
            Name = i_Name;
            PostPriority = i_PostPriority; 
            r_PostFilters = new List<IPostFilter>();
            Enabled = true;
        }

        public void AddPostFilter(IPostFilter i_PostFilter)
        {
			r_PostFilters.Add(i_PostFilter);
        }

	    public void RemovePostFilter(IPostFilter i_PostFilter)
	    {
		    r_PostFilters.Remove(i_PostFilter);
	    }

		public XmlSchema GetSchema()
		{
			return null;
		}

		private static IEnumerable<Type> getAllPossibleFilterType()
		{
			return AppDomain.CurrentDomain.GetAssemblies()
					.SelectMany(i_Assembly => i_Assembly.GetTypes())
					.Where(i_Type => typeof(IPostFilter).IsAssignableFrom(i_Type))
					.Where(i_Type => i_Type.IsClass && !i_Type.IsAbstract);
		}

		public void ReadXml(XmlReader i_Reader)
		{
			Name = i_Reader.GetAttribute("Name");
			ePostPriority postPriority;
			Enum.TryParse(i_Reader.GetAttribute("PostPriority") ?? "hidden", out postPriority);
			PostPriority = postPriority;
			i_Reader.ReadStartElement();
			i_Reader.ReadStartElement("PostFilters");
			
			while (i_Reader.IsStartElement())
			{
				XmlSerializer serializer = sr_Serializers[i_Reader.Name];
				r_PostFilters.Add(serializer.Deserialize(i_Reader) as IPostFilter);
				i_Reader.ReadStartElement();
			}

			i_Reader.ReadEndElement();
			i_Reader.ReadEndElement();
		}

		public void WriteXml(XmlWriter i_Writer)
		{
			i_Writer.WriteAttributeString("Name", Name);
			i_Writer.WriteAttributeString("PostPriority", PostPriority.ToString());
			i_Writer.WriteStartElement("PostFilters");
			foreach (IPostFilter postFilter in r_PostFilters)
			{
				XmlSerializer serializer = new XmlSerializer(postFilter.GetType());
				serializer.Serialize(i_Writer, postFilter);
			}

			i_Writer.WriteEndElement();
		}
    }
}
