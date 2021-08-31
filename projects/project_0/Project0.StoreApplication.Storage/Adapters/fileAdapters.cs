using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;


namespace Project0.StoreApplication.Storage.Adapters
{
   /// <summary>
   /// Adapter for storing in xml file
   /// </summary>
  public class FileAdapter
  {
    private static FileAdapter _fileAdapterInstance = null;
    
    /// <summary>
    /// returns singleton of file adapter
    /// </summary>
    /// <returns></returns>
    public static FileAdapter GetFileAdapterInstance()
    {
      if (_fileAdapterInstance == null)
      {
        _fileAdapterInstance = new FileAdapter();
      }
      return _fileAdapterInstance;
    }
    /// <summary>
    /// returns a generic list of developer specified type
    /// reads the list from xml file at developer specified path
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
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
      //textReader.Close();


    }
    /// <summary>
    /// Writes to an xml at a developer specified path
    /// This will write a list of objects
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <param name="path"></param>
    public void WriteToFile<T>(List<T> obj, string path) where T : class
    { //instantiate a copy of the serializer
      var xml = new XmlSerializer(typeof(List<T>)); //needs to know the type of object which we can pass in    
      var writer = new StreamWriter(path);
      //use serialization to write/save your cs data to an xml file
      xml.Serialize(writer, obj);
      //writer.Close();

    }

  }
}