
using System;
using System.Runtime.Serialization;

namespace NuvoControl.Common.Configuration;

//TODO Fix missing data type: Bitmap

[DataContract]
public class NuvoImage
{
    /// <summary>
    /// The concrete image.
    /// </summary>
    [DataMember]
    private string _picture = null;     // private Bitmap _picture = null;

    /// <summary>
    /// The image path.
    /// </summary>
    [DataMember]
    string _path = null;

    public NuvoImage(string path)
    {
        _path = path;
        _picture = $"Picture: {path}";     // new Bitmap(path);
    }

    //public Bitmap Picture
    //{
    //    get { return _picture; }
    //}

    public override string ToString()
    {
        return String.Format("Path={0}, Size={1}", _path, (_picture == null) ? "null" : _picture.ToString());
        //return String.Format("Path={0}, Size={1}", _path, (_picture==null)?"null":_picture.Size.ToString());
    }
}
