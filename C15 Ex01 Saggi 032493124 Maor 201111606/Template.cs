using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
	public class Template : IXmlSerializable
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
		/// Used for deserialization since the deserializer already created the <see cref="Template"/> object for us
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
				if (!i_Template.r_DynamicTextNodes.ContainsKey(dynamicTextNode.Name))
				{
					i_Template.r_DynamicTextNodes.Add(dynamicTextNode.Name, dynamicTextNode);
				}
				else
				{
					dynamicTextNode = i_Template.r_DynamicTextNodes[dynamicTextNode.Name];
				}

				i_Template.r_TextNodes.Add(dynamicTextNode);
				currentInputIndex = match.Index + match.Length;
			}

			if (i_Input.Length > currentInputIndex)
			{
				i_Template.r_TextNodes.Add(new StaticTextNode(i_Input.Substring(currentInputIndex, i_Input.Length - currentInputIndex)));
			}
		}

		public IEnumerable<string> Keys
		{
			get
			{
				return r_DynamicTextNodes.Keys;
			}
		}

		public override string ToString()
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
		
		private Template()
		{
			r_DynamicTextNodes = new Dictionary<string, DynamicTextNode>();
			r_TextNodes = new List<ITextNode>();
		}
		
		public string Compile(IEnumerable<KeyValuePair<string, string>> i_ReplacementPairs)
		{
			foreach (KeyValuePair<string, string> pair in i_ReplacementPairs)
			{
				r_DynamicTextNodes[pair.Key].Text = pair.Value;
			}

			StringBuilder builder = new StringBuilder();
			foreach (ITextNode textNode in r_TextNodes)
			{
				builder.Append(textNode.Text);
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
			/* XML specification forces newline to be '\n'.
			 * This means that when reading the template the newlines might not be the same as the current environment.
			 * We need to normalize the newlines in order for Windows' and Mac's text boxes to work.
			 * See: http://www.w3.org/TR/2008/REC-xml-20081126/#sec-line-ends
			 */
			string templateString = i_Reader.ReadElementString("StatusTextTemplate").Replace("\n", Environment.NewLine);
			parseWithExistingTemplate(this, templateString);
			i_Reader.ReadEndElement();
		}

		public void WriteXml(XmlWriter i_Writer)
		{
			i_Writer.WriteElementString("StatusTextTemplate", ToString());
		}
	}
}