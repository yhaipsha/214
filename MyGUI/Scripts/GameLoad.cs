using UnityEngine;
using System.Collections;
using System.Xml; 
using System.Xml.Serialization; 
using System.IO; 
using System.Text;


namespace Sheep.para
{
	public class GameLoad
	{
		public static string FILE_NAME = "sheep.xml";
		/* The following metods came from the referenced URL */ 
		public static string UTF8ByteArrayToString (byte[] characters)
		{      
			UTF8Encoding encoding = new UTF8Encoding (); 
			string constructedString = encoding.GetString (characters); 
			return (constructedString); 
		}
 
		public static byte[] StringToUTF8ByteArray (string pXmlString)
		{ 
			UTF8Encoding encoding = new UTF8Encoding (); 
			byte[] byteArray = encoding.GetBytes (pXmlString); 
			return byteArray; 
		} 
 
		// Here we serialize our UserData object of myData 
		public static string SerializeObject (object pObject)
		{ 
			string XmlizedString = null; 
			MemoryStream memoryStream = new MemoryStream (); 
			XmlSerializer xs = new XmlSerializer (pObject.GetType()); 
			XmlTextWriter xmlTextWriter = new XmlTextWriter (memoryStream, Encoding.UTF8); 
			xs.Serialize (xmlTextWriter, pObject); 
			memoryStream = (MemoryStream)xmlTextWriter.BaseStream; 
			XmlizedString = UTF8ByteArrayToString (memoryStream.ToArray ()); 
			return XmlizedString; 
		} 
 
		// Here we deserialize it back into its original form 
		public static object DeserializeObject (object objtype, string pXmlizedString)
		{ 
			XmlSerializer xs = new XmlSerializer (objtype.GetType());//typeof(objtype) 
			MemoryStream memoryStream = new MemoryStream (StringToUTF8ByteArray (pXmlizedString)); 
			XmlTextWriter xmlTextWriter = new XmlTextWriter (memoryStream, Encoding.UTF8); 
			return xs.Deserialize (memoryStream); 
		} 
 
		// Finally our save and load methods for the file itself 
		public static void CreateXML (string xmltext)
		{ 
			StreamWriter writer; 
			FileInfo t = new FileInfo (FILE_NAME); 
			writer = t.CreateText ();
//			if (!t.Exists) { 
//				writer = t.CreateText (); 
//			} 
//			else { 
//				t.Delete (); 
//				writer = t.CreateText (); 
//			} 
			writer.Write (xmltext); 
			writer.Close (); 
			Debug.Log ("File written."); 
		}
 
		public static string LoadXML (string fileName)
		{ 
			StreamReader r = File.OpenText (fileName); 
			string _info = r.ReadToEnd (); 
			r.Close (); 			
//			_data = _info; 
//			Debug.Log ("File Read"); 
			return _info;
		} 
		
	}
}
