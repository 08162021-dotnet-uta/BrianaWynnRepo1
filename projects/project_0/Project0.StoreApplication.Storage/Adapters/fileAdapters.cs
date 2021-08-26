using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;


namespace Project0.StoreApplication.Storage.Adapters
{

  public class FileAdapter
  {
    private static FileAdapter _fileAdapterInstance = null;

    public static FileAdapter GetFileAdapterInstance()
    {
      if (_fileAdapterInstance == null)
      {
        _fileAdapterInstance = new FileAdapter();
      }
      return _fileAdapterInstance;
    }

    public List<T> ReadFromFile<T>(string path) where T : class
    {
      if (!File.Exists(path))
      {
        return null;
      }
      //use serialization to open and read data from a xml file
      var xml = new XmlSerializer(typeof(List<T>));
      var textReader = new StreamReader(path);
      //return that data so that it can be used by the program
      return xml.Deserialize(textReader) as List<T>;


    }

    public void WriteToFile<T>(List<T> obj, string path) where T : class
    { //instantiate a copy of the serializer
      var xml = new XmlSerializer(typeof(List<T>)); //needs to know the type of object which we can pass in    
      var writer = new StreamWriter(path);
      //use serialization to write/save your cs data to an xml file
      xml.Serialize(writer, obj);

    }




  }
}