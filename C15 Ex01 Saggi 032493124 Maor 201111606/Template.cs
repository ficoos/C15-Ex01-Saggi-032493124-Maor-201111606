using System.Collections.Generic;

using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
	using System.Collections;
	using System.Text;
	using System.Text.RegularExpressions;

	public class Template : IEnumerable<KeyValuePair<string, DynamicTextNode>>, IXmlSerializable
	{
		private static readonly Regex sr_DynamicSectionRegex = new Regex(@"{{(?<name>[\w\s_]+)}}", RegexOptions.Multiline);

		private readonly Dictionary<string, DynamicTextNode> r_DynamicTextNodes;

		private readonly List<ITextNode> r_TextNodes;

		public static Template Parse(string i_Input)
		{
			Template template = new Template();
			parseWithExistingTemplate(template, i_Input);
			return template;
		}

		/// <summary>
		/// Used for deserialization since the deserializer already created the template object for us
		/// Assumes a new empty <see cref="Template"/> object
		/// </summary>
		private static void parseWithExistingTemplate(Template i_Template, string i_Input)
		{
			int currentInputIndex = 0;
			foreach (Match match in sr_DynamicSectionRegex.Matches(i_Input))
			{
				if (match.Index > currentInputIndex)
				{
					i_Template.r_TextNodes.Add(new StaticTextNode(i_Input.Substring(currentInputIndex, match.Index - currentInputIndex)));
				}

				DynamicTextNode dynamicTextNode = new DynamicTextNode(match.Groups["name"].Value);
				i_Template.r_TextNodes.Add(dynamicTextNode);
                if (i_Template.r_DynamicTextNodes.ContainsKey(dynamicTextNode.Name) != true) //maor: i changed it casue i got exception already in dictunary
                {
                    i_Template.r_DynamicTextNodes.Add(dynamicTextNode.Name, dynamicTextNode);
                }
				currentInputIndex = match.Index + match.Length;
			}

			if (i_Input.Length > currentInputIndex)
			{
				i_Template.r_TextNodes.Add(new StaticTextNode(i_Input.Substring(currentInputIndex, i_Input.Length - currentInputIndex)));
			}
		}

        public DynamicTextNode GetDynamicTextNodeValueByKey(string i_Key)   //TO SAGGIE: is it not safe?
        {
            DynamicTextNode Result = null;
            if(r_DynamicTextNodes.ContainsKey(i_Key))
            {
                Result = r_DynamicTextNodes[i_Key];
            }
            return Result;
        }

		public IEnumerable<string> Keys
		{
			get
			{
				return r_DynamicTextNodes.Keys;
			}
		}


		
		public string this[string i_Key]
		{
			get
			{
				return r_DynamicTextNodes[i_Key].Text;
			}

			set
			{
				if (!r_DynamicTextNodes.ContainsKey(i_Key))
				{
					throw new KeyNotFoundException(i_Key);
				}

				r_DynamicTextNodes[i_Key].Text = value;
			}
		}

		public IEnumerator<KeyValuePair<string, DynamicTextNode>> GetEnumerator()
		{
			return r_DynamicTextNodes.GetEnumerator();
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			foreach (ITextNode textNode in r_TextNodes)
			{
				builder.Append(textNode.Text);
			}

			return builder.ToString();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		private Template()
		{
			r_DynamicTextNodes = new Dictionary<string, DynamicTextNode>();
			r_TextNodes = new List<ITextNode>();
		}
		
		public string Compile()
		{
			StringBuilder builder = new StringBuilder();
			foreach (ITextNode textNode in r_TextNodes)
			{
				DynamicTextNode node = textNode as DynamicTextNode;
				if (node != null)
				{
					builder.Append(string.Format("{{{{{0}}}}}", node.Name));
				}
				else
				{
					builder.Append(textNode.Text);
				}
			}

			return builder.ToString();
		}

		public XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader i_Reader)
		{
			i_Reader.ReadStartElement();
			parseWithExistingTemplate(this, i_Reader.ReadElementString("StatusTextTemplate"));
			i_Reader.ReadEndElement();
		}

		public void WriteXml(XmlWriter i_Writer)
		{
			i_Writer.WriteElementString("StatusTextTemplate", Compile());
		}

        public static Template DeepCloneWithDummyValuesForDynmicText(Template i_Template)
        {
            Template ClonedTemplate = new Template();
            
            foreach (ITextNode Node in i_Template.r_TextNodes)
            {
                DynamicTextNode CastDynamic = (Node as DynamicTextNode);
                if (CastDynamic != null)
                {
                    if (ClonedTemplate.r_DynamicTextNodes.ContainsKey(CastDynamic.Name) == false)
                    {
                        DynamicTextNode newDynamic = new DynamicTextNode(CastDynamic.Name);
                        newDynamic.Text = "{{" + CastDynamic.Name + "}}";
                        ClonedTemplate.r_TextNodes.Add(newDynamic);
                        ClonedTemplate.r_DynamicTextNodes.Add(newDynamic.Name, newDynamic);
                    }
                    else
                    {
                        ClonedTemplate.r_TextNodes.Add(ClonedTemplate.r_DynamicTextNodes[CastDynamic.Name]);
                    }
                }
                else
                {
                    ClonedTemplate.r_TextNodes.Add(Node);
                }
                
            }

            return ClonedTemplate;
        }
	}
}