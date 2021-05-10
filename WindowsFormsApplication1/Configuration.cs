using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace VideoSaver
{
    public class Configuration
    {
        public static string filename = "VideoSaver.cfg";

        public bool PlayInRandomOrder = true;
        public bool StartAtRandomLocation = true;
        public string VideoFolder = @"C:\Users\gareth.alldread\Videos\";
        public bool JumpToNextVideoAfterTime = true;
        public int TimeToNextVideo = 30;

        public static Configuration Load()
        {
            try
            {
                using (var stream = System.IO.File.OpenRead(filename))
                {
                    var serializer = new XmlSerializer(typeof(Configuration));
                    return serializer.Deserialize(stream) as Configuration;
                }
            }
            catch
            {
                return new Configuration();
            }
        }

        public bool Save()
        {
            bool ret = true;
            try
            {
                String filename = "VideoSaver.cfg";
                using (var writer = new System.IO.StreamWriter(filename))
                {
                    var serializer = new XmlSerializer(this.GetType());
                    serializer.Serialize(writer, this);
                    writer.Flush();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
    }


}
